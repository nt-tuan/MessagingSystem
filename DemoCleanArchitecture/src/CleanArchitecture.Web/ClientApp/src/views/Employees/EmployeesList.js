import React, { Component } from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import { Button, ButtonGroup, Modal, Header, Icon, Confirm } from 'semantic-ui-react';
import EmployeeUpdate from './Components/Update';
import EmployeeDetails from './Components/Details'

class EmployeesList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      openEmployeeDetails: false,
      openEmployeeUpdate: false,
      openEmployeeDelete: false,
      selectedRows: null,
      selectedRowId: null,
      confirm: {
        open: false,
        content: false,
        callback: null
      }
    };
    this.tableRef = React.createRef();
    this.handleSelectionChange = this.handleSelectionChange.bind(this);
    this.handleEmployeeDetailsOpen = this.handleEmployeeDetailsOpen.bind(this);
    this.handleEmployeeUpdateOpen = this.handleEmployeeUpdateOpen.bind(this);
    this.handleConfirm = this.handleConfirm.bind(this);
    this.handleEmployeeDeleteOpen = this.handleEmployeeDeleteOpen.bind(this);
  }



  handleSelectionChange(rows) {
    let selectedRow = null;
    if (rows.length > 0)
      selectedRow = rows[0];

    this.setState({
      selectedRows: rows,
      selectedRowId: selectedRow ? selectedRow.id : null
    });
  }

  checkSelectedMultipleRows() {
    if (this.state.selectedRows.length > 1) {
      this.setState({ error: "YOU_SELECT_TOO_MANY_EMPLOYEE" });
      return true;
    }
    return false;
  }

  handleEmployeeDetailsOpen() {
    if (this.state.openEmployeeDetails || this.checkSelectedMultipleRows())
      return;
    
    if (!this.state.selectedRowId)
      return;
    this.setState({
      openEmployeeDetails: true
    });
  }

  handleEmployeeUpdateOpen() {
    if (this.state.openEmployeeUpdate || this.checkSelectedMultipleRows() )
      return;
    
    if (!this.state.selectedRowId)
      return;
    this.setState({
      openEmployeeUpdate: true
    });
  }

  handleEmployeeDeleteOpen() {
    if (this.state.selectedRows.length == 0)
      return;
    this.setState({
      confirm: {
        ...this.state.confirm,
        open: true,
        content: 'CONFIRM_DELETE',
        callback: this.deleteEmployees.bind(this)
      }
    });
  }

  deleteEmployees() {
    console.log(`DELETE ${this.state.selectedRows.map(u => u.id)}`);
    fetch('/api/hr/emps/delete', {
      method: 'POST',
      body: JSON.stringify({collection: this.state.selectedRows.map(u => u.id) }),
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      }
    });
    this.tableRef.current.onQueryChange();
  }

  handleConfirm() {
    if (this.state.confirm.callback) {
      this.state.confirm.callback();
    }
    this.setState({ confirm: {...this.state.confirm, open: false}});
  }

  render() {
    return (
      <div>
        <Modal open={this.state.openEmployeeDetails} centered>
          <Modal.Header>EMPLOYEE_DETAILS_HEADER</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              <EmployeeDetails id={this.state.selectedRowId} />
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={() => this.setState({ openEmployeeDetails: false })}>
              CLOSE
      </Button>
          </Modal.Actions>
        </Modal>
        <Modal open={this.state.openEmployeeUpdate} centered>
          <Modal.Header>EMPLOYEE_UPDATE_HEADER</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              <EmployeeUpdate id={this.state.selectedRowId} onSuccess={() => { this.setState({ openEmployeeUpdate: false }); this.tableRef.current.onQueryChange(); }} />
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={() => this.setState({ openEmployeeUpdate: false })}>
              CLOSE
      </Button>
          </Modal.Actions>
        </Modal>
        <Modal open={this.state.error}>
          <Modal.Header>ERROR</Modal.Header>
          <Modal.Content>
            <Modal.Description>
              {this.state.error}
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color="green" onClick={() => this.setState({ error: null })}>Close</Button>
          </Modal.Actions>
        </Modal>
        <Confirm
          open={this.state.confirm.open}
          content={this.state.confirm.content}
          onCancel={() => { this.setState({ confirm: {...this.state.confirm, open: false}})}}
          onConfirm={this.handleConfirm}
        />
        <ButtonGroup>
          <Button onClick={this.handleEmployeeDetailsOpen} primary>Details</Button>
          <Button onClick={this.handleEmployeeUpdateOpen} primary>Edit</Button>
          <Button primary>Export All</Button>
          <Button onClick={this.handleEmployeeDeleteOpen} color="red">Delete</Button>
        </ButtonGroup>
        <MaterialTable
          title="Danh sách nhân viên"
          tableRef={this.tableRef}
          columns={[
          { title: 'Mã', field: 'code' },
          { title: 'Họ', field: 'firstname' },
          { title: 'Tên', field: 'lastname' },
          { title: 'Email', field: 'email' },
          { title: 'Ngày sinh', field: 'birthday' },
          {
            title: 'Bộ phận', render: rowData => {
              return <Link to={`/hr/depts/details/${rowData.deptid}`}>{rowData.deptname}</Link>
            }
          }
        ]}
          data={query => new Promise((resolve, reject) => {
            let postdata = {
              pageSize: query.pageSize,
              page: query.page,
              search: query.search,
              orderBy: query.orderBy ? query.orderBy.field : null,
              orderDirection: query.orderDirection === "asc" ? 0 : 1
            };
            fetch(`/api/hr/emps`, {
              method: 'POST',
              body: JSON.stringify(postdata),
              headers: {
                'Content-Type': 'application/json'
              }
            })
              .then(response => response.json())
              .then(res => {
                console.log(res);
                resolve({
                  data: res.result.emps,
                  page: postdata.page,
                  totalCount: res.result.total
                });
              })
          })}
          options={{
            debounceInterval: 1000,
            selection: true
          }}
          onSelectionChange={this.handleSelectionChange}
        />
      </div>
    );
  }
}

export default EmployeesList;
