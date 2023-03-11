import React from 'react';
import classes from './InputText.module.css'

const InputText = ({text}) => {
    return (
        <p className={classes.inputText}>{text}</p>
    );
};

export default InputText;