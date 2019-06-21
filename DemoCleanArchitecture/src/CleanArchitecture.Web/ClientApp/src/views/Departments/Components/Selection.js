import React, { Component } from 'react';

import { Dropdown, Form, Label } from 'semantic-ui-react';

class Selection extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isFetching: false,
      multiple: true,
      search: true,
      searchQuery: null,
      vvalue: this.props.value,
      options: [],
      placeholder: 'SELECT_DEPARTMENT'
    }

    this.handleChange = (e, { value, name }) => {
      this.setState({ value });
      if (this.props.onChange)
        this.props.onChange(e, { value, name });
    };
    this.handleSearchChange = (e, { searchQuery }) => {
      this.setState({ searchQuery });
      console.log(searchQuery);
      this.loadData();
    };
    this.handleOpen = this.handleOpen.bind(this);
  }

  handleOpen(value) {
    this.loadData();
  }

  loadData() {
    this.setState({
      isFetching: true
    });
    fetch("/api/hr/deptsselection", {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: { searchQuery: this.state.searchQuery }
    }).then(response => {
      if (response.ok)
        return response.text();
      throw new Error(response.statusText);
    })
      .then(res => {
        let json = JSON.parse(res);
        if (json && json.result) {
          this.setState({
            options: json.result,
            isFetching: false
          });
        } else {
          if (json && json.message)
            throw new Error(json.message);
          else
            throw new Error("UNKNOWN_ERROR");
        }
      })
      .catch(error => {
        this.setState({
          options: [],
          isFetching: false,
          error: error.message
        });
      });
  }

  componentDidMount() {
    this.loadData();
    this.setState({
      value : this.props.value
    });
  }

  componentWillReceiveProps(props) {
    this.setState({ value: props.value })
  }

  render() {
    const { multiple, options, isFetching, search, value, placeholder } = this.state;
    return (
      <Form.Field>
        <Label>DEPARTMENT</Label>
        <Dropdown
          name={this.props.name}
          fluid
          selection
          search={search}
          options={options}
          value={value}
          placeholder={placeholder}
          onChange={this.handleChange}
          onSearchChange={this.handleSearchChange}
          onOpen={this.handleOpen}
          loading={isFetching}
          noResultsMessage={this.state.error}
        />
      </Form.Field>
    );
  }
};

export default Selection;
