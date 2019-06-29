import React, { useState, useEffect } from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import MyModal from '../../Modals/MyModal';
import EmployeeDetails from '../../Employees/Components/Details';
export default function AccountList(props) {
  return (
    <MaterialTable
      title="ACCOUNT_LIST"
      tableRef={props.tableRef}
      columns={[
        { title: 'Username', field: 'username' },
        { title: 'Email', field: 'email' },
        {
          title: 'EMPLOYEE', render: rowData => {
            if (rowData.employeeId) {
              return <MyModal label={rowData.employeeName} header="EMPLOYEE_DETAILS" component={<EmployeeDetails id={rowData.employeeId} />} />
            } else
              return "";
          }
        },
        {
          title: 'ROLES', render: rowData => {
            return rowData.roles.join(',');
          }
        }
      ]}
      data={query => new Promise((resolve, reject) => {
        fetch(`/api/account/list`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          }
        }).then(response => {
          if (response.ok)
            return response.json();
          throw new Error(response.statusText);
        })
          .then(res => {
            resolve({
              data: res.result.data,
              page: res.result.page,
              totalCount: res.result.total
            });
          }).catch(error => {
            reject(error.message);
          });
      })}
      options={props.options}
      onSelectionChange={props.onSelectionChange}
    />
    );
}
