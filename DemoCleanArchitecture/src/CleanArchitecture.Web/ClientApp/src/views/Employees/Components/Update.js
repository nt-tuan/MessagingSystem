import React, { Component } from 'react';

import { Form, Message, Select } from 'semantic-ui-react';
class EmployeeUpdate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
      },
      validated: false,
      validationMessage: {
        firstname: "EEEE"
      }
    };
    this.onChage = this.onChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  onChange(event) {
    const target = event.target;
    const value = event.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;
    this.setState({
      formData: { ...this.state.formData, [name]: value }
    });
  }

  onSubmit(event) {
  }

  render() {
    let validationObject = this.state.validationMessage;
    let errorKeys = Object.keys(validationObject);
    let errorMessages = errorKeys.map(u => validationObject[u]);
    const options = [
      { text: 'Male', value: 'male' },
      { text: 'Female', value: 'female' },
      { text: 'Other', value: 'other' },
    ];
    return (<div>
      {errorMessages && <Message header="VALIDATION_ERROR" list={errorMessages}></Message>}
      <Form>
        {this.state.error && <Message negative>{this.state.error.message}</Message>}
        <Form.Field label="CODE" id="input-code" control="input" error={this.state.validationMessage.code != null}>
        </Form.Field>
        <Form.Group widths="equal">
          <Form.Field label="FIRSTNAME" id="input-firstname" control="input" error={this.state.validationMessage.firstname != null}>
          </Form.Field>
          <Form.Field label="LASTNAME" id="input-lastname" control="input" error={this.state.validationMessage.lastname != null}>
          </Form.Field>
        </Form.Group>
        <Form.Field label="DEPARTMENT" id="input-dept" control={Select} error={this.state.validationMessage.dept!=null} options={options} >
        </Form.Field>
      </Form>
    </div>)
  }
}

export default EmployeeUpdate;
