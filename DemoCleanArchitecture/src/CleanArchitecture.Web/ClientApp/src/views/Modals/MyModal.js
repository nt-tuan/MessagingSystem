import React, { Component } from 'react';
import { Modal, Button } from 'semantic-ui-react';

class MyModal extends Component {
  constructor(props) {
    super(props);
    this.state = {
      openDetails: false
    };
  }

  open = () => this.setState({ openDetails: true })
  close = () => this.setState({ openDetails: false })

  render() {
    return (
      <div>
        <a href="#" onClick={(e) => { e.preventDefault(); this.setState({ openDetails: true }); }}>{this.props.label}</a>
        <Modal open={this.state.openDetails} onOpen={this.open} onClose={this.close} centered>
          <Modal.Header>{this.props.header}</Modal.Header>
          <Modal.Content scrolling>
            <Modal.Description>
              {this.props.component}
            </Modal.Description>
          </Modal.Content>
          <Modal.Actions>
            <Button color='green' onClick={this.close}>
              CLOSE
      </Button>
          </Modal.Actions>
        </Modal></div>);
  }
}

export default MyModal;
