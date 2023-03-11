import React from 'react';
import classes from './StartSearchButton.module.css'

const StartSearchButton = ({onClick}) => {
    return (
        <div onClick={onClick} className={classes.button}>
            <p className={classes.text}>Start Search</p>
        </div>
    );
};

export default StartSearchButton;