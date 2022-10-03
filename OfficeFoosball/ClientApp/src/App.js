import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import InsertMatch from './components/insert-match/InsertMatch';
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

  render() {
    const isAuth = this.auth.isAuth();

    return (
      <Layout isAuth={isAuth}>
        <Routes>
          <Route path='/login' element={<LoginForm />} />
          <Route path='/register' element={<RegisterForm />} />
          <Route exact path='/' element={<Home />} />

          {this.auth.isAuth && <Route path='/insert-match' element={<InsertMatch />} />}
          {this.auth.isAuth && <Route path='/match-detail/:id' element={<MatchDetail />} />}
          {this.auth.isAuth && <Route path='/add-player' element={<AddPlayer />} />}
          {this.auth.isAuth && <Route path='/add-team' element={<AddTeam />} />}
        </Routes>
      </Layout>
    );
  }
}
