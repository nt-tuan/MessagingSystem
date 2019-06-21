import React, { Component } from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom'
import MyModal from '../../Modals/MyModal';
import EmployeeDetails from './Details';
class EmployeeList extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <MaterialTable
        title="Danh sách nhân viên"
        tableRef={this.props.tableRef}
        columns={[
          { title: 'Mã', field: 'code' },
          { title: 'Họ', field: 'firstname' },
          { title: 'Tên', field: 'lastname' },
          { title: 'Email', field: 'email' },
          { title: 'Ngày sinh', field: 'birthday' },
          {
            title: 'Bộ phận', render: rowData => {
              return <MyModal label={rowData.deptname} header={"EMPLOYEE_DETAILS"} component={<EmployeeDetails id = { rowData.deptid } />} />
            }
          }
        ]}
        data={query => new Promise((resolve, reject) => {
          let postdata = {
            pageSize: query.pageSize,
            page: query.page,
            search: query.search,
            orderBy: query.orderBy ? query.orderBy.field : null,
            orderDirection: query.orderDirection === "asc" ? 0 : 1,
            filter: this.props.filter
          };
          fetch(`/api/hr/emp`, {
            method: 'POST',
            body: JSON.stringify(postdata),
            headers: {
              'Content-Type': 'application/json'
            }
          })
            .then(response => {
              if (response.ok)
                return response.json();
              throw new Error(response.statusText);
            })
            .then(res => {
              console.log(res);
              resolve({
                data: res.result.emps,
                page: postdata.page,
                totalCount: res.result.total
              });
            })
            .catch(error => {

            });
        })}
        options={this.props.options}
        onSelectionChange={this.props.onSelectionChange}
      />
    );
  }
}

export default EmployeeList;
