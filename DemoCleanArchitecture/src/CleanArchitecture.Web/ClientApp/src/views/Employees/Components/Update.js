import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Badge, Card, CardBody, CardHeader, Col, Row, Table, Modal, Input, InputGroup, Form, Alert, FormGroup, Label } from 'reactstrap';
import Select from 'react-select';
class EmployeeUpdate extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
      }
    }
    this.onChage = this.onChange.bind(this);
  }

  onChange(event) {
    const target = event.target;
    const value = event.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;
    this.setState({
      formData: { ...this.state.formData, [name]: value }
    });
  }

  render() {
    return (<div>
      <Form action="createUser" method="post" onSubmit={this.onSubmit}>
        {this.state.error && <Alert color="danger">{this.state.error.message}</Alert>}
        <FormGroup>
          <Label htmlFor="input-code">Mã nhân viên</Label>
          <Input type="text" id="input-code" name="code" value={this.state.formData.code} onChange={this.onChange}>
          </Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="input-firstname">Họ</Label>
          <Input type="text" id="input-firstname" name="firstname" value={this.state.formData.firstname} onChange={this.onChange}></Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="input-lastname">Tên</Label>
          <Input type="text" id="input-lastname" name="lastname" value={this.state.formData.lastname} onChange={this.onchange}></Input>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="input-dept">Phòng ban/bộ phận</Label>
          <Select options={[{ value: 1, label: 'A' }, {value: 2, label: 'B'}]}>
          </Select>
        </FormGroup>
        <FormGroup>
          <Label htmlFor="input-email">Email</Label>
          <Input type="text" id="input-email" name="email" value={this.state.formData.email} onChange={this.onChange}></Input>
        </FormGroup>
      </Form>
    </div>)
  }
}

export default EmployeeUpdate;
