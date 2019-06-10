import React, { Component} from 'react';

import { Dropdown } from 'semantic-ui-react';

class DepartmentSelection extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isFetching: false,
      multiple: true,
      search: true,
      searchQuery: null,
      value: "asfasf",
      options: []
    }

    this.handleChange = (e, { value }) => {
      this.setState({ value });
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
        Accept: 'application/json'
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
  }

  render() {
    const { multiple, options, isFetching, search, value } = this.state;
    return (
      <Dropdown
        fluid
        selection
        search={search}
        options={options}
        value={value}
        placeholder='Add Users'
        onChange={this.handleChange}
        onSearchChange={this.handleSearchChange}
        onOpen={this.handleOpen}
        loading={isFetching}
        noResultsMessage={this.state.error}
      />
    );
  }
};

export default DepartmentSelection;
