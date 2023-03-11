import React from 'react';
import classes from './RedirectLinkText.module.css'

const RedirectLinkText = ({text}) => {
    return (
        <p className={classes.redirectLinkText}>{text}</p>
    );
};

export default RedirectLinkText;