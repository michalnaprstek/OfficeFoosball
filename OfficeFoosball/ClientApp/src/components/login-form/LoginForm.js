import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import './LoginForm.scss';
import Auth from '../../utils/auth/auth';

export default class LoginForm extends Component {
  state = {
    username: '',
    password: '',
    success: true
  };

  handleSubmit = async event => {
    event.preventDefault();
    const auth = new Auth();
    try {
      await auth.login(this.state.username, this.state.password);
      this.props.history.push('/');
    } catch(error) {
      this.setState({success : false});
      console.log(error);
    }
  };

  render() {
    return (
      <div className="auth">
        <form className="auth__form" onSubmit={this.handleSubmit}>
          <h4 className="mb-3 text-center">Login to your account</h4>
          {
            this.state.success ? null : <div className="auth__error-message">Login failed.</div>
          }
          <div className="form-group">
            <input
              className="form-control"
              type="text"
              name="username"
              value={this.state.username}
              onChange={event =>
                this.setState({ username: event.target.value })
              }
              placeholder="Username"
              required
            />
          </div>
          <div className="form-group">
            <input
              className="form-control"
              type="password"
              name="password"
              value={this.state.password}
              onChange={event =>
                this.setState({ password: event.target.value })
              }
              placeholder="Password"
              required
            />
          </div>
          <input
            className="btn btn-primary w-100"
            type="submit"
            name="submitButton"
            value="Login"
          />
          <div className="d-flex justify-content-between mt-3">
            <small className="form-text text-muted">Not registred?</small>
              <Link to="/register">Register</Link>
          </div>
        </form>
      </div>
    );
  }
}
