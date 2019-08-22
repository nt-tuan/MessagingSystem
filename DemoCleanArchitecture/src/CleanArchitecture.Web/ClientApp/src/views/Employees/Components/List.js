import React, { Component } from 'react';
import MaterialTable from 'material-table';
import { Link } from 'react-router-dom'
import MyModal from '../../Modals/MyModal';
import EmployeeDetails from './Details';
import { HRApiService } from '../../../_services/hr';
class EmployeeList extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    const columnDef = HRApiService.employeeColumns();
    columnDef.pop();
    return (
      <MaterialTable
        title="Danh sách nhân viên"
        tableRef={this.props.tableRef}
        columns={columnDef}
        data={query => new Promise((resolve, reject) => {
          let postdata = {
            pageSize: query.pageSize,
            page: query.page,
            search: query.search,
            orderBy: query.orderBy ? query.orderBy.field : null,
            orderDirection: query.orderDirection === "asc" ? 0 : 1,
            filter: this.props.filter
          };
          HRApiService.employeeList(postdata,
            result => {
              resolve({
                data: result.result.emps,
                page: postdata.page,
                totalCount: result.result.total
              });
            },
            error => {
              alert(error);
            });
        })}
        options={this.props.options}
        onSelectionChange={this.props.onSelectionChange}
      />
    );
  }
}

export default EmployeeList;
