import React from 'react';
import classes from './NavBarButton.module.css'

const NavBarButton = ({text, onClick}) => {
    return (
        <div onClick={onClick} className={classes.button}>
            <p className={classes.text}>{text}</p>
        </div>
    );
};

export default NavBarButton;