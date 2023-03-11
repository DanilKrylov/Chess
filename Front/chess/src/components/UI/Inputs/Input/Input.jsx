import React from 'react';
import classes from './Input.module.css'

const Input = ({type, value, setValue}) => {
    return (
        <input type={type} value={value} onChange={event => setValue(event.target.value)} className={classes.input}/>
    );
};

export default Input;