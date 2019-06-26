import React from 'react';
import { Segment, Message, Divider } from 'semantic-ui-react';
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

  }

  loadAccount() {
    fetch(`/api/account/details/${this.props.id}`, {
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
        if (result.account) {
          this.setState({
            isLoading: false,
            data: result.data
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
          <h6>ACCOUNT_NAME</h6>
          <h4>{this.state.data.username}</h4>
          <h6>EMAIL</h6>
          <h4>{this.state.data.email}</h4>
          <h6>LAST_ACTIVE_TIME</h6>
          <h4>{this.state.lastActiveTime}</h4>
          <Divider />
          {this.state.data.employeeid && <EmployeeDetails id={this.state.data.employeeid} />}
        </div>}
      </Segment>
    );
      }
    }
    
    
