import React from 'react';
import Moment from 'react-moment';
import { Message } from 'semantic-ui-react';
export const HRApiService = {
  employeeColumns: getEmployeeColumns,
  employeeList: employeesListApi,
  employeeReview: employeeReviewExcelApi,
  employeeDetail,
  employeeUpdate
}

function getEmployeeColumns() {
  const employeeColumns =
    [{
      title: 'Mã',
      field: 'code'
    },
    {
      title: 'Họ',
      render: rowData => rowData.person ? rowData.person.firstname : null
    },
    {
      title: 'Tên',
      render: rowData => rowData.person ? rowData.person.lastname : null
    },
    {
      title: 'Tên nhân viên',
      render: rowData => rowData.person ? rowData.person.fullname : null
    },
    {
      title: 'Tên thường gọi',
      render: rowData => rowData.person ? rowData.person.displayname : null
    },
    {
      'title': 'Trực thuộc', render: rowData => {
        if (rowData.dept) {
          return <strong>{rowData.dept.name}({rowData.dept.code})</strong>;
        }
        return null;
      }
    }, {
      title: 'Ngày sinh', render: rowData => {
        if (rowData.person && rowData.person.birthday) {
          return <Moment date={rowData.person.birthday} format="DD/MM/YYYY" />
        }
      }
    },
    {
      title: 'Email', render: rowData => rowData.person ? rowData.person.email : null
    },
    {
      title: "Lỗi", render: rowData => {
        if (rowData.messages) {
          const rs = [];
          rowData.messages.forEach((value, index) => {
            let color = null;
            if (value.type == "danger")
              color = "red";
            else if (value.type == "warning")
              color = "yellow";
            if (value.key != null && value.key.length > 0) {
              rs.push(<Message key={index} color={color}><strong>{value.key}</strong>: {value.content}</Message>);
            } else {
              rs.push(<Message key={index} color={color}>{value.content}</Message>);
            }
          });
          return <div>{rs}</div>
        } else {
          return null;
        }
      }
    }
    ];
  return employeeColumns;
}

const fixedRequestOptions = {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' }
};

const defaultGetResult = success => {
  return json => {
    success(json);
  };
};

const defaultCatchError = error => {
  return er => {
    error(er.Message);
  }
}

const defaultFetchChain = (fetch, success, error) => {
  fetch
    .then(response => {
      if (response.ok)
        return response.json();
      throw new Error(response.statusText);
    })
    .then(defaultGetResult(success))
    .catch(defaultCatchError(error));
}

function employeesListApi(postdata, success, error) {
  defaultFetchChain(
    fetch(`/api/hr/emp`, {
      ...fixedRequestOptions,
      body: JSON.stringify(postdata),
    }), success, error);
}

function employeeReviewExcelApi(data, success, error) {
  fetch(`/api/hr/ReviewEmployeeExcel`, {
    method: 'POST',
    body: data
  }).then(res => {
    if (res.ok)
      return res.text();
    throw new Error(res.statusText);
  }).then(result => {
    let json = JSON.parse(result);
    success(json.result);
  }).catch(error => {
    error(error.Message);
  });
}



function employeeDetail(id, success, error) {
  defaultFetchChain(
    fetch(`/api/hr/emp/${id}`, { ...fixedRequestOptions }),
      success, error);
}

function employeeUpdate(id, postData, success, error) {
  defaultFetchChain(fetch(`/api/hr/emp/${id}`, { ...fixedRequestOptions, body: postData }),success, error);
}
