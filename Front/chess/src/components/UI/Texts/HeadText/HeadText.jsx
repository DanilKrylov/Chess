import React from 'react';
import classes from './HeadText.module.css'

const HeadText = ({text}) => {
    return (
        <p className={classes.headText}>{text}</p>
    );
};

export default HeadText;