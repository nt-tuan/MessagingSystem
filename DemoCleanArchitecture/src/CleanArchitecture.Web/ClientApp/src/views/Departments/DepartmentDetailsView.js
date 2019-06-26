import React from 'react';
import DepartmentDetails from './Components/Details';
import { Segment } from 'semantic-ui-react';

export default class DepartmentDetailsView extends React.Component{
  render() {
    return (<Segment><DepartmentDetails id={this.props.match.params.id}></DepartmentDetails></Segment>);
  }
}
