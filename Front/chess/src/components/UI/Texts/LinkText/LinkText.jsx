import React from 'react';
import classes from './LinkText.module.css'

const LinkText = ({text}) => {
    return (
        <p className={classes.linkText}>{text}</p>
    );
};

export default LinkText;