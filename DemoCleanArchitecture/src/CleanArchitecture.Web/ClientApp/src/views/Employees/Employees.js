import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import MaterialTable from 'material-table'
import { Button, ButtonGroup, Modal, Header, Icon, Confirm } from 'semantic-ui-react';
import EmployeeUpdate from './Components/Update';
import EmployeeDetails from './Components/Details'
import EmployeeList from './Components/List'
import EmployeeAdd from './Components/Add';
import MyModal from '../Modals/MyModal';
class EmployeesView extends Component {
  constructor(props) {
    super(props);
    this.state = {
      modal: {

      },
      openModal: false,
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
    this.selectedRows = rows;
    if (rows.length > 0)
      this.selectedRowId = rows[0].id;
    else
      this.selectedRowId = null;
  }

  checkSelectedMultipleRows() {
    if (this.selectedRows.length > 1) {
      this.setState({ error: "YOU_SELECT_TOO_MANY_EMPLOYEE" });
      return true;
    }
    return false;
  }

  handleEmployeeDetailsOpen() {
    if (this.state.openModal || this.checkSelectedMultipleRows() || !this.selectedRowId)
      return;

    const com = <EmployeeDetails id={this.selectedRowId} />;
    const expandLink = `/hr/employees/${this.selectedRowId}`;
    const header = `EMPLOYEE_DETAILS`;

    this.setState({
      modalOpen: true,
      modal: {
        com,
        expandLink,
        header
      }
    });
  }

  handleEmployeeUpdateOpen() {
    if (this.state.openEmployeeUpdate || this.checkSelectedMultipleRows() || !this.selectedRowId)
      return;

    const com = <EmployeeUpdate id={this.selectedRowId} />;
    const expandLink = `/hr/employees/update/${this.selectedRowId}`;
    const header = `EMPLOYEE_UPDATE`;

    this.setState({
      modalOpen: true,
      modal: {com, expandLink, header}
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
    fetch('/api/hr/emp/delete', {
      method: 'POST',
      body: JSON.stringify({ collection: this.selectedRows.map(u => u.id) }),
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
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
        <MyModal open={this.state.modalOpen} component={this.state.modal.com} onClose={() => this.setState({ modalOpen: false })} expandable={this.state.modal.expandLink} header={this.state.modal.header} />

        <Confirm
          open={this.state.confirm.open}
          content={this.state.confirm.content}
          onCancel={() => { this.setState({ confirm: { ...this.state.confirm, open: false } }) }}
          onConfirm={this.handleConfirm}
        />
        <ButtonGroup>
          <Button onClick={() => this.setState({ openAdd: true })} color="green">New</Button>
          <Button onClick={this.handleEmployeeDetailsOpen} primary>Details</Button>
          <Button onClick={this.handleEmployeeUpdateOpen} primary>Edit</Button>
          <Button primary>Export All</Button>
          <Button onClick={this.handleEmployeeDeleteOpen} color="red">Delete</Button>
        </ButtonGroup>
        <EmployeeList tableRef={this.tableRef} onSelectionChange={this.handleSelectionChange} options={{
          debounceInterval: 1000,
          selection: true
        }} />
      </div>
    );
  }
}

export default EmployeesView;
