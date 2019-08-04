import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { InsertMatch } from './components/insert-match/InsertMatch';
import MatchDetail from './components/match-detail/MatchDetail';
import LoginForm from './components/login-form/LoginForm';
import RegisterForm from './components/register-form/RegisterForm';
import PrivateRoute from './components/PrivateRoute';
import AddPlayer from './components/add-player/AddPlayer';
import AddTeam from './components/add-team/AddTeam';
import Auth from './utils/auth/auth';
import "./App.scss";

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
        <PrivateRoute path='/add-player' component={AddPlayer} canActivate={this.auth.isAuth} />
        <PrivateRoute path='/add-team' component={AddTeam} canActivate={this.auth.isAuth} />
      </Layout>
    );
  }
}
