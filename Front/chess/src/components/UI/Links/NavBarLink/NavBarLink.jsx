import React from 'react';
import { Link } from 'react-router-dom';
import LinkText from '../../Texts/LinkText/LinkText';
import classes from './NavBarLink.module.css'

const NavBarLink = ({route, text}) => {
    return (
        <Link to={route}>
            <div className={classes.navBarLink}>
                <LinkText text={text}></LinkText>          
            </div>
        </Link>
    );
};

export default NavBarLink;