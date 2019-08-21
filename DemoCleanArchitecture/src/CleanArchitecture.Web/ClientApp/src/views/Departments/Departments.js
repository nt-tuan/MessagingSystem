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
      modalOpen: false,
      modal: {
      },
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
    this.handleDetailsOpen = this.handleDetailsOpen.bind(this);
    this.handleUpdateOpen = this.handleUpdateOpen.bind(this);
    this.handleConfirm = this.handleConfirm.bind(this);
    this.handleDeleteOpen = this.handleDeleteOpen.bind(this);
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

  handleDetailsOpen() {
    if (this.state.openModal || this.checkSelectedMultipleRows())
      return;
    if (!this.selectedRowId)
      return;
    let com = <DepartmentDetails id={this.selectedRowId} />;
    let expandable = `/hr/departments/${this.selectedRowId}`;
    let header = `DEPARTMENT_DETAILS`;

    this.setState({
      modalOpen: true,
      modal: {
        com,
        expandable,
        header
      }
    });
  }

  handleUpdateOpen() {
    if (this.state.openUpdate || this.checkSelectedMultipleRows())
      return;
    if (!this.selectedRowId)
      return;
    let com = <DepartmentUpdate id={this.selectedRowId} />;
    let expandable = `/hr/departments/update/${this.selectedRowId}`;
    let header = `DEPARTMENT_UPDATE`;

    this.setState({
      modalOpen: true,
      modal: {
        com,
        expandable,
        header
      }
    });
  }

  handleDeleteOpen() {
    if (this.selectedRows.length == 0)
      return;
    this.setState({
      confirm: {
        ...this.state.confirm,
        open: true,
        content: 'CONFIRM_DELETE',
        callback: this.deleteDepartments.bind(this)
      }
    });
  }

  deleteDepartments() {
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
            modalOpen: true,
            modal: {
              com: <div>{jres.message}</div>,
              expanable: null,
              header: "ERROR"
            }
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
        <MyModal open={this.state.modalOpen} component={this.state.modal.com} onClose={() => this.setState({ modalOpen: false })} expandable={this.state.modal.expandable} header={this.state.modal.header} />

        <Confirm
          open={this.state.confirm.open}
          content={this.state.confirm.content}
          onCancel={() => { this.setState({ confirm: { ...this.state.confirm, open: false } }) }}
          onConfirm={this.handleConfirm}
        />
        <ButtonGroup>
          <Button onClick={this.handleAddOpen} color="green">New</Button>
          <Button onClick={this.handleDetailsOpen} primary>Details</Button>
          <Button onClick={this.handleUpdateOpen} primary>Edit</Button>
          <Button primary><Link path="/hr/departments">Export All</Link></Button>
          <Button primary>Import</Button>
          <Button onClick={this.handleDeleteOpen} color="red">Delete</Button>
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
