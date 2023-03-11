import React from 'react';
import classes from './SubmitButton.module.css'

const SubmitButton = ({text, onClick}) => {
    return (
        <button onClick={onClick} className={classes.button}>{text}</button>
    );
};

export default SubmitButton;