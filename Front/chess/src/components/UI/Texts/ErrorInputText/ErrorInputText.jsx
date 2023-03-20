import React from 'react';
import classes from './ErrorInputText.module.css'

const ErrorInputText = ({text}) => {
    return (
        <p className={classes.errorInputText}>{text}</p>
    );
};

export default ErrorInputText;