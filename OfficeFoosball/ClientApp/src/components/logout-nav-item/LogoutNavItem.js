import React from 'react';
import { NavItem } from 'reactstrap';
import { useNavigate } from 'react-router-dom'
import Auth from '../../utils/auth/auth'

const LogoutNavItem = ({ onLogout }) => {
    const navigate = useNavigate();
    const logout = () => {
        const logoutCallback = this.props.onLogout;
        Auth.logout();
        navigate('/login');
        logoutCallback();
        // this.props.history.push('/login')
        // if (logoutCallback) logoutCallback();
    };

    return (
        <NavItem onClick={logout}>
            <span className="nav-link">Logout</span>
        </NavItem>)

}

export default LogoutNavItem