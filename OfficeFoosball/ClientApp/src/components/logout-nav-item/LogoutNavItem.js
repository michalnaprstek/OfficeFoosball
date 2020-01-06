import React, { Component } from 'react';
import { NavItem } from 'reactstrap';
import { withRouter } from 'react-router-dom'
import Auth from '../../utils/auth/auth'

class LogoutNavItem extends Component{
    auth = new Auth();

    logout = () => {
        const logoutCallback = this.props.onLogout;
        this.auth.logout();
        this.props.history.push('/login')
        if(logoutCallback) logoutCallback();
    };

    render = () => (
        <NavItem onClick={this.logout}>
            <span className="nav-link">Logout</span>
        </NavItem>)
}

export default withRouter(LogoutNavItem)