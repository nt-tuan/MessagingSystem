import React from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom';
import { Button } from 'reactstrap';

class EmployeesList extends React.Component {
  render() {
    return (
      <MaterialTable title="Danh sách nhân viên" columns={[
        { title: 'Mã', field: 'code' },
        { title: 'Họ', field: 'firstname' },
        {title: 'Tên', field: 'lastname'},
        { title: 'Email', field: 'email' },
        { title: 'Ngày sinh', field: 'birthday' },
        {
          title: 'Bộ phận', render: rowData => {
            return <Link to={`/hr/employees/details/${rowData.deptid}`}>{rowData.deptname}</Link>
          }
        }
      ]} data={query => new Promise((resolve, reject) => {
        let postdata = {
          pageSize: query.pageSize,
          page: query.page,
          search: query.search,
          orderBy: query.orderBy ? query.orderBy.field:null,
          orderDirection: query.orderDirection==="asc"?0:1
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
          debounceInterval: 1000
        }}
      />
    );
  }
}

export default EmployeesList;
