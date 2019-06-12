import React from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import { Button, ButtonGroup, Modal, Header, Icon } from 'semantic-ui-react';
import EmployeeUpdate from './Components/Update';
import EmployeeDetails from './Components/Details'

class EmployeesList extends React.Component {
  state = {
    openEmployeeDetail: false
  };

  render() {
    return (
      <div>
        <Modal open={this.state.openEmployeeDetail} centered>
          <Modal.Header>EMPLOYEE_HEADER</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              <EmployeeDetails id={1} />
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={() => this.setState({ openEmployeeDetail: false })}>
              <Icon name='window close' /> CLOSE
      </Button>
          </Modal.Actions>
        </Modal>
        <Modal>
          <EmployeeDetails />
        </Modal>
        <ButtonGroup>
          <Button onClick={() => this.setState({ openEmployeeDetail: true })} primary>Details</Button>
          <Button primary>Edit</Button>
          <Button primary>Export All</Button>
          <Button color="red">Delete</Button>
        </ButtonGroup>
        <MaterialTable title="Danh sách nhân viên" columns={[
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
        />
      </div>
    );
  }
}

export default EmployeesList;
