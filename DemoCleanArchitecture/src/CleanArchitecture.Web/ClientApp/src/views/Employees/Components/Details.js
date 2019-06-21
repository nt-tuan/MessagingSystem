import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import MyModal from '../../Modals/MyModal';
import DepartmentDetails from '../../Departments/Components/Details';

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
    fetch(`/api/hr/emp/${this.props.id}`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
      }
    }).then(res => {
      if (res.ok)
        return res.text();
      throw new Error(res.statusText);
    })
      .then(result => {
        let jresult = JSON.parse(result);
        if (jresult.result == null) {

          this.setState({
            isLoaded: true,
            error: jresult.message ? jresult.message : "NOT_FOUND"
          });
        } else {
          this.setState({
            isLoaded: true,
            emp: jresult.result
          });
          this.props.onSuccess && this.props.onSuccess();
        }
      }).catch(error => {
        console.log(error);
        this.setState({
          isLoaded: true,
          error: error
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
    } else {
      return (
        <div>
          <h6>Mã nhân viên</h6>
          <h4><strong>{this.state.emp.code}</strong></h4>
          <h6>Tên nhân viên</h6>
          <h4><strong>{`${this.state.emp.firstname} ${this.state.emp.lastname}`}</strong></h4>
          <h6>Thuộc bộ phận/phòng ban</h6>
          <h4>
            <MyModal label={this.state.emp.deptname} component={<DepartmentDetails id={this.state.emp.deptid} />} />
          </h4>
          <h6>Email</h6>
          <h4>{this.state.emp.email}</h4>
          <h6>Ngày sinh</h6>
          <h4>{this.state.emp.birthday}</h4>
        </div>
      );
    }
  }
}

export default EmployeeDetails;
