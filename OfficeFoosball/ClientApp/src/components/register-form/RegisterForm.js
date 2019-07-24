import React, { Component } from "react";
import { BrowserRouter as Router, Link } from "react-router-dom";

import "../login-form/LoginForm.scss";
import Auth from '../../utils/auth/auth';


export default class RegisterForm extends Component {
  state = {
    username: "",
    password: "",
    confirmPassword: "",
    email: "",
    success: true
  };
  handleSubmit = async event => {
    event.preventDefault();
    const auth = new Auth();
    await auth.register(this.state.username, this.state.email, this.state.password);
  };

  render() {
    return (
      <div className="auth">
        <form className="auth__form" onSubmit={this.handleSubmit}>
          <h4 className="mb-3 text-center">Register</h4>
          {
            this.state.success ? null : <div className="auth__error-message">Register failed. Try it again.</div>
          }
          <div className="form-group">
            <input
              className="form-control"
              type="text"
              name="username"
              value={this.state.username}
              onChange={event => this.setState({ username: event.target.value })}
              placeholder="Username"
              required
            />
          </div>
          <div className="form-group">
            <input
              className="form-control"
              type="email"
              name="email"
              value={this.state.email}
              onChange={event => this.setState({ email: event.target.value })}
              placeholder="Email"
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
          <div className="form-group">
            <input
              className="form-control"
              type="password"
              name="confirmPassword"
              value={this.state.confirmPassword}
              onChange={event =>
                this.setState({ confirmPassword: event.target.value })
              }
              placeholder="Confirm password"
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
            <small className="form-text text-muted">
              Do you have an account?
            </small>
            <Link to="/login">Log in</Link>
          </div>
        </form>
      </div>
    );
  }
}
