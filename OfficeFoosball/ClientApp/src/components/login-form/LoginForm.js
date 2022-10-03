import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

import './LoginForm.scss';
import Auth from '../../utils/auth/auth';

const LoginForm = () => {
  const navigate = useNavigate();

  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [success, setSuccess] = useState(true);

  const handleSubmit = async event => {
    event.preventDefault();
    const auth = new Auth();
    try {
      await auth.login(userName, password);
      navigate('/');
    } catch (error) {
      setSuccess(false);
      console.log(error);
    }
  };

  return (
    <div className="auth">
      <form className="auth__form" onSubmit={handleSubmit}>
        <h4 className="mb-3 text-center">Login to your account</h4>
        {
          success ? null : <div className="auth__error-message">Login failed.</div>
        }
        <div className="form-group">
          <input
            className="form-control"
            type="text"
            name="username"
            value={userName}
            onChange={event =>
              setUserName(event.target.value)
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
            value={password}
            onChange={event =>
              setPassword(event.target.value)
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

export default LoginForm;
