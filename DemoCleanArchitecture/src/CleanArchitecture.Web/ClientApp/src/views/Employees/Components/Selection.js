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
      value: this.props.value,
      options: [],
      placeholder: 'SELECT_EMPLOYEE'
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
    this.selected = null;
  }

  

  handleOpen(value) {
    this.loadData();
  }

  loadCurrentValue() {
    fetch(`/api/hr/emp/${this.state.value}`, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
      }
    }).then(res => {
      if (res.ok)
        return res.text();
      throw new Error(res.statusText);
    })
      .then(result => {
        let jresult = JSON.parse(result);
        
        if (jresult.result == null) {
          this.selected = null;
        } else {
          let emp = jresult.result;
          this.selected = {
            text: `${emp.code} - ${emp.firstname} ${emp.lastname}`,
            value: emp.id
          };
          let emps = this.state.options;
          if (this.selected) {
            if (emps.filter(u => u.value === this.selected.value).length === 0) {
              emps.push({
                text: this.selected.text,
                value: this.selected.value
              });
            }
          }
          this.setState({
            options: emps,
            value: this.props.value
          });
        }
      }).catch(error => {
        console.log(error);
        this.selected = null;
      });
  }

  loadData() {
    this.setState({
      isFetching: true
    });
    fetch("/api/hr/emp", {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        search: this.state.searchQuery,
        page: 0,
        pageSize: 100,
        orderBy: 'lastname',
        orderDirection: 0
      })
    }).then(response => {
      if (response.ok)
        return response.text();
      throw new Error(response.statusText);
    })
      .then(res => {
        let json = JSON.parse(res);
        if (json && json.result) {
          let emps = json.result.emps.map(u => {
            return {
              text: `${u.code} - ${u.firstname} ${u.lastname}`,
              value: u.id
            };
          });
          this.setState({
            options: emps,
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
    this.loadCurrentValue();
    this.setState({
      value: this.props.value
    });
  }

  componentWillReceiveProps(props) {
    this.setState({ value: props.value })
  }

  render() {
    const { multiple, options, isFetching, search, value, placeholder } = this.state;
    return (
      <Form.Field>
        <Label>{this.props.label && 'EMPLOYEE'}</Label>
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
