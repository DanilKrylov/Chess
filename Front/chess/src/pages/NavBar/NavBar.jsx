import React from 'react';
import NavBarLinks from '../../components/NavBarLinks/NavBarLinks';
import UserInfo from '../../components/UserInfo/UserInfo';
import classes from './NavBar.module.css'

const NavBar = () => {
    return (
        <div className={classes.navBar}>
            <NavBarLinks></NavBarLinks>
            <UserInfo></UserInfo>
        </div>
    );
};

export default NavBar;