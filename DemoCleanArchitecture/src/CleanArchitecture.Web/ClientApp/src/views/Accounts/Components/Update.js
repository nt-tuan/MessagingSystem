import React from 'react';
import { Segment, Form, DropDown, Label, ButtonGroup, Button, Divider } from 'semantic-ui-react';
import { default as EmployeeSelection } from '../../Employees/Components/Selection';
import { default as Message } from '../../Base/Messages/Message';

export default class UpdateAccount extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
        employeeId: null,
        username: "",
        email: ""
      },
      validationMessage: {},
      messages: []
    };
    //this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.loadData();
  }

  loadData() {
    fetch(`/api/account/details/${this.props.id}`, {
      method: 'POST'
    })
      .then(response => {
        if (response.ok)
          return response.json();
        throw new Error(response.statusText);
      })
      .then(response => {
        if (response && response.result && response.result.data) {
          console.log(response.result.data);
          this.setState({
            formData: response.result.data
          });
        }
      })
      .catch(error => this.setState({ message: error.message }));
  }

  handleChange = (e, { name, value }) => {
    console.log(`${name}: ${value}`);
    this.setState({
      formData: { ...this.state.formData, [name]: value }
    });
  }

  handleSubmit(event) {
    event.preventDefault();
    console.log(this.state.formData);
    fetch(`/api/hr/account/update/${this.props.id}`, {
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
        if (res && res.result && this.props.onSuccess) {
          this.props.onSuccess(this.state.formData);
        }
      })
      .catch(error => this.setState({ message: error.message }));
  }

  render() {
    return (
      <Segment>
        <ButtonGroup>
          <Button onClick={this.handleSubmit} primary>UPDATE</Button>
        </ButtonGroup>
        <Divider />
        {this.state.message && <Message error message={this.state.message} messages={this.state.messages} />}
        <Form>
          <Form.Field>
            <EmployeeSelection name="employeeId" value={this.state.formData.employeeId} onChange={this.handleChange} />
          </Form.Field>
          <Form.Field>
            <Label>USERNAME</Label>
            <Form.Input name="username" value={this.state.formData.username} onChange={this.handleChange} />
          </Form.Field>
          <Form.Field>
            <Label>EMAIL</Label>
            <Form.Input name="email" value={this.state.formData.email} onChange={this.handleChange} />
          </Form.Field>
        </Form>
      </Segment>)
  }
}
