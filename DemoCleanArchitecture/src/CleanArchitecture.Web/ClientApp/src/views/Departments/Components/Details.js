import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import EmployeeList from '../../Employees/Components/List';
import MyModal from '../../Modals/MyModal';
class DepartmentDetails extends Component {
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
    fetch(`/api/hr/dept/${this.props.id}`, {
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
            dept: jresult.result
          });
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
      let renderParent = this.state.dept.parentId ? (<div><h6>PARENT_DEPARTMENT</h6>
        <h4>
          <MyModal label={this.state.dept.parentName} header={"DEPARTMENT_DETAILS"} component={<DepartmentDetails id={this.state.dept.parentId} />}  />
        </h4></div>): null;
      return (
        <div>
          <h6>DEPARTMENT_CODE</h6>
          <h4><strong>{this.state.dept.code}</strong></h4>
          <h6>DEPARTMENT_NAME</h6>
          <h4><strong>{this.state.dept.name}</strong></h4>
          {renderParent}
          <h6>EMPLOYEES_LIST</h6>
          <EmployeeList filter={{ "DepartmentId": this.props.id }} />
        </div>
        
      );
    }
  }
}

export default DepartmentDetails;
