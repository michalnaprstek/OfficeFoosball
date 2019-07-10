import React, { Component } from "react";
import "./LoginForm.scss";

export default class LoginForm extends Component {
  state = {
    username: null,
    password: null
  };

  handleSubmit = (event) => {
    fetch("api/Auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        name: this.state.username,
        password: this.state.password
      })
    });
  }

  render() {
    return (
      <form className="login-form" onSubmit={this.handleSubmit}>
        <div className="form-group">
          <input
            className="form-control"
            type="text"
            name="username"
            value={this.state.username}
            onChange={(event) => this.setState({name: event.target.value})}
            placeholder="Username"
          />
        </div>
        <div className="form-group">
          <input
            className="form-control"
            type="password"
            name="password"
            value={this.state.password}
            onChange={(event) => this.setState({password: event.target.value})}
            placeholder="Password"
          />
        </div>
        <input className="btn btn-primary" type="submit" name="submitButton" />
      </form>
    );
  }
}
