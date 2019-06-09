import React, { Component } from 'react';

import { Form, Message } from 'semantic-ui-react';
class EmployeeUpdate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
      },
      validated: false
    }
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
    return (<div>
      <Form>
        {this.state.error && <Message negative>{this.state.error.message}</Message>}
        <Form.Group widths="equal">
          <Form.Field label="Code" id="input-code" control="input">
          </Form.Field>
        </Form.Group>
      </Form>
    </div>)
  }
}

export default EmployeeUpdate;
