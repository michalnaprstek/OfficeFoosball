import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { InsertMatch } from './components/insert-match/InsertMatch';
import MatchDetail from './components/match-detail/MatchDetail';
import LoginForm from './components/login-form/LoginForm';
import RegisterForm from './components/register-form/RegisterForm';
import AddPlayer from './components/add-player/AddPlayer';
import AddTeam from './components/add-team/AddTeam';
import './App.scss';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/insert-match' component={InsertMatch} />
        <Route path='/match-detail/:id' component={MatchDetail} />
        <Route path='/login' component={LoginForm} />
        <Route path='/register' component={RegisterForm} />
        <Route path='/add-player' component={AddPlayer} />
        <Route path='/add-team' component={AddTeam} />
      </Layout>
    );
  }
}
