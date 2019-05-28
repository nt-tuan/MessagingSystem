import React from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import { Button } from 'reactstrap';

class EmployeesList extends React.Component {
  render() {
    return (
      <MaterialTable title="Danh sách nhân viên" columns={[
        { title: 'Mã', field: 'code' },
        { title: 'Họ và tên', field: 'fullName' },
        { title: 'Email', field: 'email' },
        { title: 'Ngày sinh', field: 'birthday' },
        { title: 'Bộ phận', field: 'dept' }
      ]} data={query => new Promise((resolve, reject) => {
        fetch(`/api/hr/employees?perpage=${query.pageSize}&page=${query.page}&search=${query.search}&orderBy=${query.orderBy}&direction=${query.orderDirection}`, { method: 'GET' })
          .then(response => response.json())
          .then(result => {
            console.log(result);
            resolve({
              data: result.data,
              page: result.page,
              totalCount: result.total
            });
          })
      })}
        options={{
          debounceInterval: 1000
        }}
      />
    );
  }
}

export default EmployeesList;
