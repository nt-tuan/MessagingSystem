import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import MyModal from '../../Modals/MyModal';
import DepartmentDetails from '../../Departments/Components/Details';
import { HRApiService } from '../../../_services/hr';

class EmployeeDetails extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoaded: false,
      error: null
    };
    this.loadData = this.loadData.bind(this);
  }

  componentDidMount() {
    this.loadData();
  }

  componentWillReceiveProps(nextProps) {
    this.loadData();
  }

  loadData() {
    this.setState({
      isLoaded: false
    });
    HRApiService.employeeDetail(this.props.id,
      json => {
        if (json.result == null) {
          this.setState({
            isLoaded: true,
            error: json.message ? json.message : "NOT_FOUND"
          });
        } else {
          this.setState({
            isLoaded: true,
            emp: json.result
          });
          this.props.onSuccess && this.props.onSuccess();
        }
      },
      err => {
        this.setState({
          isLoaded: true,
          error: err
        });
      });
  }

  render() {
    if (this.state.error) {
      if (this.state.error.message)
        return <div>{this.state.error.message}</div>;
      else
        return <div>Unknown error</div>
    }
    else if (!this.state.isLoaded) {
      return (
        <div>Loading...</div>
      );
    } else if (this.state.emp) {
      return (
        <div>
          <h6>Mã nhân viên</h6>
          <h4><strong>{this.state.emp.code}</strong></h4>
          <h6>Tên nhân viên</h6>
          <h4><strong>{this.state.emp.person.fullname}</strong></h4>
          {this.state.emp.dept && <div><h6>Thuộc bộ phận/phòng ban</h6>
            <h4>
              <MyModal label={this.state.emp.dept.name} component={<DepartmentDetails id={this.state.emp.dept.id} />} />
            </h4></div>}
          {this.state.emp.person.email && <div>
            <h6>Email</h6>
            <h4><strong>{this.state.emp.person.email}</strong></h4></div>}
          <h6>Ngày sinh</h6>
          <h4><strong>{this.state.emp.person.birthday}</strong></h4>
        </div>
      );
    } else {
      return <div>{JSON.stringify(this.state)}</div>
    }
  }
}

export default EmployeeDetails;
