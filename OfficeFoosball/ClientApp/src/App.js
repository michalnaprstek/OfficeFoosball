import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { InsertMatch } from './components/InsertMatch';
import MatchDetail from './components/match-detail/MatchDetail';
import LoginForm from './components/login-form/LoginForm';
import RegisterForm from './components/register-form/RegisterForm';
import PrivateRoute from './components/PrivateRoute';
import './App.scss';
import Auth from './utils/auth/auth';

export default class App extends Component {
  static displayName = App.name;
  auth = new Auth();

  render () {
    return (
      <Layout>
        <Route path='/login' component={LoginForm} />
        <Route path='/register' component={RegisterForm} />
        <PrivateRoute exact path='/' component={Home} canActivate={this.auth.isAuth} />
        <PrivateRoute path='/insert-match' component={InsertMatch} canActivate={this.auth.isAuth} />
        <PrivateRoute path='/match-detail/:id' component={MatchDetail} canActivate={this.auth.isAuth} />
      </Layout>
    );
  }
}
