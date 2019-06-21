import React from 'react';
import { Segment, Message } from 'semantic-ui-react';

export default class AccountDetails extends ReactComponent {
  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
      data: null
    };
  }

  componentDidMount() {
    fetch(`/api/account/${this.props.id}`, {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    })
      .then(response => {
        if (response.ok) {
          return response.json();
        }
        throw new Error(repsonse.statusText);
      })
      .then(result => {
        if (result.account) {
          this.setState({
            isLoading: false,
            data: result.account
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
        </div>}
      </Segment>
    );
  }
}


