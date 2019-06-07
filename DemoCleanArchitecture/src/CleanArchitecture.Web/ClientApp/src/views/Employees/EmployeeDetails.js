import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Row, Col, Button, Card, CardBody, CardHeader, ButtonGroup, ButtonToolbar, UncontrolledButtonDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import EmployeeDetails from '../Employees/Components/Details';

class EmployeeDetailsView extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: this.props.match.params.id,
      isLoaded: false,
      error: null
    };

    this.loadData = this.loadData.bind(this);
  }

  loadData() {
    this.setState({
      id: this.props.match.params.id
    });
    console.log("asgagasgasg");
  }

  render() {
    return (
      <Row>
        <Col sm="8" lg="6" sx="12">
          <div>
            <Card>
              <CardHeader>
                <ButtonToolbar className="justify-content-between">
                  <h3>Thông tin nhân viên</h3>
                  {
                    (!this.props.hideFunctions) && (<ButtonGroup>
                      <Button onClick={this.loadData}>
                        <i className="fa fa-refresh"></i>
                      </Button>
                      <Button>
                        <i className="fa fa-edit"></i>
                      </Button>
                      <Button>
                        <i className="fa fa-trash"></i>
                      </Button>
                      <UncontrolledButtonDropdown>
                        <DropdownToggle caret>
                          <i className="fa fa-user"></i>
                        </DropdownToggle>
                        <DropdownMenu>
                          <DropdownItem><i className="fa fa-plus"></i> Add login account</DropdownItem>
                          <DropdownItem><i className="fa fa-close"></i> Remove login account</DropdownItem>
                        </DropdownMenu>
                      </UncontrolledButtonDropdown>
                    </ButtonGroup>)
                  }
                </ButtonToolbar>
              </CardHeader>
              <CardBody>
                <EmployeeDetails id={this.state.id}></EmployeeDetails>
              </CardBody>
            </Card>
          </div>
        </Col>
      </Row>
    );
  }
}

export default EmployeeDetailsView;
