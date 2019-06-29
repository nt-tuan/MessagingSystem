import React from 'react';
import { Segment, Message, Divider, Label, List } from 'semantic-ui-react';
import EmployeeDetails from '../../Employees/Components/Details';
export default class AccountDetails extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
      data: null
    };
  }

  componentDidMount() {
    this.loadAccount();
  }

  loadAccount() {
    fetch(`/api/account/details/${this.props.id}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    })
      .then(response => {
        if (response.ok) {
          return response.json();
        }
        throw new Error(response.statusText);
      })
      .then(result => {
        if (result && result.result) {
          this.setState({
            isLoading: false,
            data: result.result.data
          });
        } else {
          this.setState({
            isLoading: false,
            data: null,
            message: result.message
          });
        }
      })
      .catch(error => this.setState({ message: error.message }));
  }

  render() {
    return (
      <Segment loading={this.state.isLoading}>
        {this.state.message && <Message error>{this.state.message}</Message>}
        {this.state.data && <div>
          <List divided selection>
            <List.Item>
              <Label horizontal color="blue">ACCOUNT_NAME</Label>{this.state.data.username}
            </List.Item>
            <List.Item>
              <Label horizontal color="blue">EMAIL</Label>
              {this.state.data.email}
            </List.Item>
          </List>
          <Divider />
          {this.state.data.employeeId &&
            <div>
              <h6>EMPLOYEE_DETAILS</h6>
              <EmployeeDetails id={this.state.data.employeeId} /></div>}
        </div>
        }
      </Segment>
    );
  }
}


