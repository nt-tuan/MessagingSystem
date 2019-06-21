import React, { Component } from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import DepartmentDetails from './Components/Details';
import EmployeeDetails from '../Employees/Components/Details';
import DepartmentUpdate from './Components/Update';
import DepartmentList from './Components/List';
import { Button, ButtonGroup, Modal, Header, Icon, Confirm } from 'semantic-ui-react';
import MyModal from '../Modals/MyModal';

class Departments extends Component {
  constructor(props) {
    super(props);
    this.state = {
      openEmployeeDetails: false,
      openEmployeeUpdate: false,
      openEmployeeDelete: false,
      confirm: {
        open: false,
        content: false,
        callback: null
      }
    };
    this.tableRef = React.createRef();
    this.selectedRows = null;
    this.selectedRowId = null;
    this.handleSelectionChange = this.handleSelectionChange.bind(this);
    this.handleEmployeeDetailsOpen = this.handleEmployeeDetailsOpen.bind(this);
    this.handleEmployeeUpdateOpen = this.handleEmployeeUpdateOpen.bind(this);
    this.handleConfirm = this.handleConfirm.bind(this);
    this.handleEmployeeDeleteOpen = this.handleEmployeeDeleteOpen.bind(this);
  }

  handleSelectionChange(rows) {
    this.selectedRows = [];
    let selectedRow = null;
    rows.forEach(u => {
      let dup = this.selectedRows.filter(v => v.id === u.id);
      if (!dup || dup.length < 1)
        this.selectedRows.push(u);
    });

    if (this.selectedRows.length > 0)
      selectedRow = this.selectedRows[0];

    this.selectedRowId = selectedRow ? selectedRow.id : null;
  }

  checkSelectedMultipleRows() {
    if (this.selectedRows.length < 1) {
      this.setState({ error: "NO_DEPARTMENT_SELECTED" });
      return true;
    }
    if (this.selectedRows.length > 1) {
      this.setState({ error: "MULTIPLE_DEPARTMENTS_SELECTED" });
      return true;
    }
    return false;
  }

  handleEmployeeDetailsOpen() {
    if (this.state.openDetails || this.checkSelectedMultipleRows())
      return;
    if (!this.selectedRowId)
      return;

    this.setState({
      openDetailsId: this.selectedRowId,
      openDetails: true
    });
  }

  handleEmployeeUpdateOpen() {
    if (this.state.openUpdate || this.checkSelectedMultipleRows())
      return;

    if (!this.selectedRowId)
      return;
    this.setState({
      openUpdateId: this.selectedRowId,
      openUpdate: true
    });
  }

  handleEmployeeDeleteOpen() {
    if (this.selectedRows.length == 0)
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
    console.log(`DELETE ${this.selectedRows.map(u => u.id)}`);
    fetch('/api/hr/dept/delete', {
      method: 'POST',
      body: JSON.stringify({ collection: this.selectedRows.map(u => u.id) }),
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      }
    })
      .then(response => response.json())
      .then(jres => {
        if (jres.message) {
          this.setState({
            error: jres.message
          });
        }
      });
    this.tableRef.current.onQueryChange();
  }

  handleConfirm() {
    if (this.state.confirm.callback) {
      this.state.confirm.callback();
    }
    this.setState({ confirm: { ...this.state.confirm, open: false } });
  }

  render() {
    return (
      <div>
        <Modal open={this.state.openDetails} centered>
          <Modal.Header>DEPARTMENT_DETAILS_HEADER</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              <DepartmentDetails id={this.state.openDetailsId} />
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={() => this.setState({ openDetails: false })}>
              CLOSE
      </Button>
          </Modal.Actions>
        </Modal>

        < Modal open={this.state.openUpdate} centered>
          <Modal.Header>EMPLOYEE_UPDATE_HEADER</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              <DepartmentUpdate id={this.state.openUpdateId} onSuccess={() => { this.setState({ openUpdate: false }); this.tableRef.current.onQueryChange(); }} />
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={() => this.setState({ openUpdate: false })}>
              CLOSE
      </Button>
          </Modal.Actions>
        </Modal>
        <Modal open={this.state.error != null}>
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
        <Modal open={this.state.openAdd}>
          <Modal.Header>ADD_DEPARTMENT</Modal.Header>
          <Modal.Content>
            <Modal.Description>
            </Modal.Description>
          </Modal.Content>
        </Modal>
        <Confirm
          open={this.state.confirm.open}
          content={this.state.confirm.content}
          onCancel={() => { this.setState({ confirm: { ...this.state.confirm, open: false } }) }}
          onConfirm={this.handleConfirm}
        />
        <ButtonGroup>
          <Button onClick={this.handleDepartmentAdd} color="green">New</Button>
          <Button onClick={this.handleEmployeeDetailsOpen} primary>Details</Button>
          <Button onClick={this.handleEmployeeUpdateOpen} primary>Edit</Button>
          <Button primary>Export All</Button>
          <Button onClick={this.handleEmployeeDeleteOpen} color="red">Delete</Button>
        </ButtonGroup>
        <DepartmentList tableRef={this.tableRef} options={{
            debounceInterval: 1000,
            selection: true,
            paging: false,
            defaultExpanded: true
          }}
          onSelectionChange={this.handleSelectionChange} />
      </div>
    );
  }
}

export default Departments;
