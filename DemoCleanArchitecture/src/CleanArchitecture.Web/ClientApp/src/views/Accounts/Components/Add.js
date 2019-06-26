import React from 'react';
import { Segment, Form, DropDown, Message, Label, ButtonGroup, Button, Divider } from 'semantic-ui-react';
import { default as EmployeeSelection } from '../../Employees/Components/Selection';

export default class AddAccount extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {},
      validationMessage: {},
      messages: []
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleEmployeeChange = this.handleEmployeeChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(e, { name, value }) {
    console.log(`${name}: ${value}`);
    this.setState({
      formData: { ...this.state.formData, [name]: value }
    });
  }

  handleEmployeeChange(e, { name, value }) {
    fetch(`/api/hr/emp/${value}`, { method: "POST" })
      .then(response => {
        if (response.ok)
          return response.json();
        throw new Error(response.statusText);
      })
      .then(result => {
        if (result && result.result) {
          this.setState({
            formData: {...this.state.formData, email: result.result.email}
          });
        }
      })
      .catch(error => this.setState({ message: error.message }));
    this.handleChange(e, { name, value });
  }

  handleSubmit(event) {
    event.preventDefault();
    console.log(this.state.formData);
    fetch(`/api/hr/account/add`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(this.state.formData)
    })
      .then(res => {
        if (res.ok) {
          return res.json();
        }
        throw new Error(res.statusText);
      })
      .then(res => {
        if (res && res.result && this.props.onSuccess)
          this.props.onSuccess(this.state.formData);
      })
      .catch(error => this.setState({message: error.message}));
  }

  render() {
    return (
      <Segment>
        <ButtonGroup>
          <Button onClick={this.handleSubmit} primary>ADD</Button>
        </ButtonGroup>
        <Divider />
        {this.state.message && <Message error>{this.state.message}</Message>}
        <Form>
          <Form.Field>
            <EmployeeSelection name="employeeId" value={this.state.formData.employeeId} onChange={this.handleEmployeeChange} />
          </Form.Field>
          <Form.Field>
            <Label>USERNAME</Label>
            <Form.Input name="username" onChange={this.handleChange} />
          </Form.Field>
          <Form.Field>
            <Label>EMAIL</Label>
            <Form.Input name="email" onChange={this.handleChange} />
          </Form.Field>
          <Form.Field>
            <Label>PASSWORD</Label>
            <Form.Input type="password" name="password" onChange={this.handleChange} />
          </Form.Field>
          <Form.Field>
            <Label>PASSWORD CONFIRM</Label>
            <Form.Input type="password" name="passwordConfirm" onChange={this.handleChange} />
          </Form.Field>
        </Form>
      </Segment>)
  }
}
