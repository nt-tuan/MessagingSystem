import React, { Component } from 'react';
import MaterialTable from 'material-table';
import DepartmentDetails from './Details'
import EmployeeDetails from '../../Employees/Components/Details';
import MyModal from '../../Modals/MyModal';

class DepartmentsList extends Component {
  render() {
    return (
      <div>
        <MaterialTable
          title="Danh sách nhân viên"
          tableRef={this.props.tableRef}
          columns={[
            { title: 'Mã', field: 'code' },
            { title: 'Tên bộ phận/ phòng ban', field: 'name' },
            {
              'title': 'Trực thuộc', render: rowData => {
                if (rowData.parentId) {
                  return <MyModal component={<DepartmentDetails id={rowData.parentId} />} label={rowData.parentName} />
                }
                return null;
              }
            },
            {
              title: 'Quản lí', render: rowData => {
                return <MyModal label={rowData.managerName} header={"EMPLOYEE_DETAILS"} component={<EmployeeDetails id={rowData.managerId} />} />
              }
            }
          ]}
          data={query => new Promise((resolve, reject) => {
            let postdata = {
              pageSize: 1000,
              page: 0,
              search: query.search,
              orderBy: query.orderBy ? query.orderBy.field : null,
              orderDirection: query.orderDirection === "asc" ? 0 : 1
            };
            fetch(`/api/hr/depts`, {
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
                  data: res.result.depts,
                  page: 0,
                  totalCount: res.result.total
                });
              })
          })}
          parentChildData={(row, rows) => rows.find(a => a.id === row.parentId)}
          options={this.props.options}
          onSelectionChange={this.props.onSelectionChange}
        />
      </div>
    );
  }
}

export default DepartmentsList;
