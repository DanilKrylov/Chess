import React from 'react';
import Input from '../UI/Inputs/Input/Input';
import InputText from '../UI/Texts/InputText/InputText';
import classes from './InputBlock.module.css'

const InputBlock = ({type, text, value, setValue}) => {
    return (
        <div className={classes.inputBlock}>
            <InputText text={text}></InputText>
            <Input type={type} value={value} setValue={setValue}></Input>
        </div>
    );
};

export default InputBlock;