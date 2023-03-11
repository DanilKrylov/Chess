import React from 'react';
import classes from './Flex.module.css'

const Flex = ({children}) => {
    return (
        <div className={classes.flex}>
            {children}
        </div>
    );
};

export default Flex;