import React, { Component } from 'react';
import MaterialTable from 'material-table';
import {Link} from 'react-router-dom'
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
            orderDirection: query.orderDirection === "asc" ? 0 : 1,
            filter: this.props.filter
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
        options={this.props.options}
        onSelectionChange={this.props.onSelectionChange}
      />
    );
  }
}

export default EmployeeList;
