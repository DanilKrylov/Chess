import React from 'react';
import classes from './FormWrapper.module.css'

const FormWrapper = ({children}) => {
    return (
        <div className={classes.formWrapper}>{children}</div>
    );
};

export default FormWrapper;