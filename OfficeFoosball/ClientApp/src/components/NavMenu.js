import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

import './NavMenu.css';
import Auth from '../utils/auth/auth';
import { Redirect } from 'react-router-dom';

export class NavMenu extends Component {
  auth = new Auth();

  state = {
    collapsed: true
  };

  toggleNavbar = () => {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  logout = () => {
    this.auth.logout();
  };

  render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm navbar-dark ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              OfficeFoosball
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                {this.auth.isAuth() ? (
                  <NavItem>
                    <NavLink tag={Link} to="/insert-match">
                      + Insert match
                    </NavLink>
                    <span onClick={this.logout}>Logout</span>
                  </NavItem>
                ) : null}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
