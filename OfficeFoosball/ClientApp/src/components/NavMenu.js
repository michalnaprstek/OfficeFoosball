import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

import './NavMenu.css';
import LogoutNavItem from './logout-nav-item/LogoutNavItem';

export class NavMenu extends Component {

  state = {
    collapsed: true
  };

  toggleNavbar = () => {
    const isLogged = this.props.isAuth;

    this.setState({
      collapsed: !isLogged || !this.state.collapsed,
    });
  }

  closeNavBar = () => {
    this.setState({ collapsed: true })
  }

  onLogout = () =>{
    this.closeNavBar();
  }

  render() {
    const isLogged = this.props.isAuth;

    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm navbar-light ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              OfficeFoosball
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
            {isLogged ? (
              <ul className="navbar-nav flex-grow">
                  <NavItem>
                    <NavLink tag={Link} to="/insert-match" onClick={this.closeNavBar}>
                      Insert match
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} to="/add-player" onClick={this.closeNavBar}>
                      Add player
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} to="/add-team" onClick={this.closeNavBar}>
                      Add team
                    </NavLink>
                  </NavItem>
                  <LogoutNavItem onLogout={this.onLogout} />
              </ul>
                ) : null}
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
