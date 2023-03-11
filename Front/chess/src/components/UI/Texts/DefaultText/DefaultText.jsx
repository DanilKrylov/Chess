import React from 'react';
import classes from './DefaultText.module.css'

const DefaultText = ({text}) => {
    return (
        <p className={classes.defaultText}>{text}</p>
    );
};

export default DefaultText;