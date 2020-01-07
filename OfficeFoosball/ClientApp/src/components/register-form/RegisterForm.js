import React, { Component } from "react";
import { Link } from "react-router-dom";

import "../login-form/LoginForm.scss";
import Auth from '../../utils/auth/auth';


export default class RegisterForm extends Component {
  state = {
    username: "",
    password: "",
    confirmPassword: "",
    email: "",
    accessCode: null,
    success: true,
    errorMessage: ""
  };
  handleSubmit = async event => {
    event.preventDefault();
    const auth = new Auth();
    try {
      const response = await auth.register(this.state.username, this.state.email, this.state.password, this.state.accessCode);
      if (response.ok) {
        this.props.history.push('/');
      } else {
        this.setState({ success: false, errorMessage: response.errorMessage });
      }
    } catch (error) {
      this.setState({ success: false, errorMessage: error });
    }
  };

  render() {
    const success = this.state.success;
    const errorMessage = this.state.errorMessage ? this.state.errorMessage : 'Register failed. Try it again.';
    return (
      <div className="auth">
        <form className="auth__form" onSubmit={this.handleSubmit}>
          <h4 className="mb-3 text-center">Register</h4>
          {
            success ? null : <div className="auth__error-message">{errorMessage}</div>
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
          <div className="form-group">
            <input
              className="form-control"
              type="text"
              name="accessCode"
              value={this.state.accessCode}
              onChange={event =>
                this.setState({ accessCode: event.target.value })
              }
              placeholder="Acceess code"
              required
            />
          </div>
          <input
            className="btn btn-primary w-100"
            type="submit"
            name="submitButton"
            value="Register"
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
