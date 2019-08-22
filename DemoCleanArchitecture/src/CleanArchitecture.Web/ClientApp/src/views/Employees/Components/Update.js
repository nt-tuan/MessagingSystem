import React, { Component } from 'react';

import { Form, Message, Button, Label } from 'semantic-ui-react';
import { default as DeparmentSelection } from '../../Departments/Components/Selection';
import { HRApiService } from '../../../_services/hr';
class EmployeeUpdate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
        code: "",
        person: {
          firstname: "",
          lastname: "",
          displayname: "",
          birthday: "",
          identityNumber: ""
        },
        deptid: ""
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
    HRApiService.employeeDetail(this.props.id, jresult => {
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
    }, error => {
      this.setState({
        isLoaded: true,
        error
      });
    });
  }

  handleChange = (e, { name, value }) => {
    //const value = event.type === 'checkbox' ? target.checked : target.value;
    console.log(`${name}: ${value}`);

    /*let name = e.target.name;*/
    var nameParts = name.split('.');
    if (nameParts[0] == 'person' && nameParts.length > 1) {
      this.setState({
        formData: {
          ...this.state.formData, person: {
            ...this.state.formData.person,
            [nameParts[1]]: value
          }
        }
      });
    } else {
      this.setState({
        formData: { ...this.state.formData, [name]: value }
      });
    }
  }

  onSubmit(event) {
    event.preventDefault();
    console.log(this.state.formData);
    HRApiService.employeeUpdate(this.props.id, JSON.stringify(this.state.formData),
      json => {
        if (json && json.result && this.props.onSuccess) {
          this.props.onSuccess(this.state.formData);
        };
      },
      error => {
        this.setState({
          validationMessage: { ...this.state.validationMessage, error: error.message }
        });
      });
  }

  componentDidMount() {
    this.loadData();
  }

  render() {
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
          <Form.Input value={this.state.formData.code} name="code" onChange={this.handleChange} id="input-code" error={this.state.validationMessage.code != null} />
        </Form.Field>
        <Form.Field>
          <Label>IDENTITYNUMBER</Label>
          <Form.Input value={this.state.formData.person.identityNumber} onChange={this.handleChange} id="input-identityNumber" name="person.identityNumber" error={this.state.validationMessage.identityNumber != null} />
        </Form.Field>
        <Form.Group widths="equal">
          <Form.Field>
            <Label>FIRSTNAME</Label>
            <Form.Input value={this.state.formData.person.firstname} onChange={this.handleChange} id="input-firstname" name="person.firstname" error={this.state.validationMessage.firstname != null} />
          </Form.Field>
          <Form.Field>
            <Label>LASTNAME</Label>
            <Form.Input value={this.state.formData.person.lastname} onChange={this.handleChange} id="input-lastname" name="person.lastname" error={this.state.validationMessage.lastname != null} />
          </Form.Field>
        </Form.Group>
        <Form.Field>
          <Label>DISPLAYNAME</Label>
          <Form.Input value={this.state.formData.person.displayname} onChange={this.handleChange} id="input-displayname" name="person.displayname" error={this.state.validationMessage.displayname != null} />
        </Form.Field>
        <Form.Field>
          <Label>EMAIL</Label>
          <Form.Input value={this.state.formData.person.email} onChange={this.handleChange} id="input-email" name="person.email" error={this.state.validationMessage.email != null} />
        </Form.Field>
        <Form.Field>
          <Label>BIRTHDAY</Label>
          <Form.Input value={this.state.formData.person.birthday} onChange={this.handleChange} id="input-birthday" name="person.birthday" error={this.state.validationMessage.birthday != null} />
        </Form.Field>
        <Form.Group widths="equal">
          <DeparmentSelection name="deptid" value={this.state.formData.deptid} onChange={this.handleChange} />
        </Form.Group>

        <Button type="submit" primary>Update</Button>
      </Form>
    </div>)
  }
}

export default EmployeeUpdate;
