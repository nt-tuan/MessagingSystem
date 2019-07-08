import { authHeader, config } from '../_helpers';

export const UserService = {
  login,
  logout,
  register,
  getAll,
  getById,
  update,
  delete: _delete
};

const fixedRequestOptions = {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' }
};

function login(username, password) {
  const requestOptions = {
    ...fixedRequestOptions,
    body: JSON.stringify({ username, password })
  };
  return fetch(config.apiUrl + '/api/account/login', requestOptions)
    .then(handleResponse, handleError)
    .then(user => {
      // login successful if there's a jwt token in the response
      localStorage.setItem('user', JSON.stringify({
        username: "tuannt",
        roles: ["admin"]
      }));
      //if (user && user.token) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        //localStorage.setItem('user', JSON.stringify({
          //username: "tuannt",
          //roles: ["admin"]
        //}));
      //}
      return user;
    });
}

function logout() {
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' }
  };
  // remove user from local storage to log user out
  return fetch(config.apiUrl + "/api/account/login", requestOptions)
    .then(handleResponse, handleError)
    .then(user => {
      if (user && user.token) {
        localStorage.removeItem('user');
      }
      return user;
    });
}

function getAll() {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(config.apiUrl + '/account/getall', requestOptions).then(handleResponse, handleError);
}

function getById(_id) {
  const requestOptions = {
    method: 'GET',
    headers: authHeader()
  };

  return fetch(config.apiUrl + '/account/' + _id, requestOptions).then(handleResponse, handleError);
}

function register(user) {
  const requestOptions = {
    ...fixedRequestOptions,
    body: JSON.stringify(user)
  };

  return fetch(config.apiUrl + '/account/register', requestOptions).then(handleResponse, handleError);
}

function update(user) {
  const requestOptions = {
    method: 'PUT',
    headers: { ...authHeader(), 'Content-Type': 'application/json' },
    body: JSON.stringify(user)
  };

  return fetch(config.apiUrl + '/account/' + user.id, requestOptions).then(handleResponse, handleError);
}

// prefixed function name with underscore because delete is a reserved word in javascript
function _delete(id) {
  const requestOptions = {
    method: 'DELETE',
    headers: authHeader()
  };

  return fetch(config.apiUrl + '/account/' + id, requestOptions).then(handleResponse, handleError);
}

function handleResponse(response) {
  return new Promise((resolve, reject) => {
    if (response.ok) {
      // return json if it was returned in the response
      response.json().then(json => resolve(json));
    } else {
      // return error message from response body
      response.text().then(text => reject(text));
    }
  });
}

function handleError(error) {
  return Promise.reject(error && error.message);
}
