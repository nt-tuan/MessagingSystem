import React, { Component } from 'react';

import { Form, Message, Button, Label } from 'semantic-ui-react';
import { default as DepartmentSelection } from './Selection';
import { default as EmployeeSelection } from '../../Employees/Components/Selection';
class DepartmentUpdate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoaded: false,
      formData: {
        code: "",
        name: "",
        alias: "",
        parentId: null,
        managerId: null
      },
      validated: false,
      validationMessage: {
      },
      error: null
    };
    //this.handleChange = this.handleChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
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
            formData: jresult.result
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

  handleChange = (e, { name, value }) => {
    //const value = event.type === 'checkbox' ? target.checked : target.value;
    console.log(`${name}: ${value}`);

    /*let name = e.target.name;*/

    this.setState({
      formData: { ...this.state.formData, [name]: value }
    });
  }

  onSubmit(event) {
    event.preventDefault();
    console.log(this.state.formData);
    fetch(`/api/hr/dept/update/${this.props.id}`, {
      method: "POST",
      headers: {
        Accept: "application/json",
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(this.state.formData)
    }).then(res => {
      if (res.ok)
        return res.text();
      throw new Error(res.statusText);
    })
      .then(res => {
        let json = JSON.parse(res);
        if (json && json.result && this.props.onSuccess) {
          this.props.onSuccess(this.state.formData);
        };
      })
      .catch(error => {
        this.setState({
          validationMessage: { ...this.state.validationMessage, error: error.message }
        });
      });
  }

  componentDidMount() {
    this.loadData();
  }

  render() {
    if (!this.state.isLoaded)
      return <div>loading...</div>

    let validationObject = this.state.validationMessage;
    let errorKeys = Object.keys(validationObject);
    let errorMessages = [];
    errorKeys.forEach(u => errorMessages.push(validationObject[u]));

    return (<div>
      {(errorMessages && errorMessages.length > 0) && <Message header="VALIDATION_ERROR" list={errorMessages}></Message>}
      <Form onSubmit={this.onSubmit}>
        {this.state.error && <Message negative>{this.state.error.message}</Message>}
        <Form.Field>
          <Label>CODE</Label>
          <Form.Input name="code" value={this.state.formData.code} onChange={this.handleChange} error={this.state.validationMessage.code != null} />
        </Form.Field>
        <Form.Field>
          <Label>DEPARTMENT_NAME</Label>
          <Form.Input name="name" value={this.state.formData.name} onChange={this.handleChange} error={this.state.validationMessage.name != null} />
        </Form.Field>
        <Form.Field>
          <Label>DEPARTMENT_ALIAS</Label>
          <Form.Input name="alias" value={this.state.formData.alias || ''} onChange={this.handleChange} error={this.state.validationMessage.alias != null} />
        </Form.Field>

        <Form.Group widths="equal">
          <DepartmentSelection name="parentId" value={this.state.formData.parentId} onChange={this.handleChange}></DepartmentSelection>
        </Form.Group>
        <Form.Group widths="equal">
          <EmployeeSelection name="managerId" value={this.state.formData.managerId} onChange={this.handleChange}></EmployeeSelection>
        </Form.Group>

        <Button type="submit" primary>Update</Button>
      </Form>
    </div>)
  }
}

export default DepartmentUpdate;
