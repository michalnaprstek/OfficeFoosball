import React from 'react';
import { NavItem } from 'reactstrap';
import { useNavigate } from 'react-router-dom'
import Auth from '../../utils/auth/auth'

const LogoutNavItem = ({ onLogout }) => {
    const navigate = useNavigate();
    const auth = new Auth();
    const logout = () => {
        auth.logout();
        navigate('/login');
        onLogout();
    };

    return (
        <NavItem onClick={logout}>
            <span className="nav-link">Logout</span>
        </NavItem>)

}

export default LogoutNavItem