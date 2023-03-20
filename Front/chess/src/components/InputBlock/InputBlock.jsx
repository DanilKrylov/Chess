import React from 'react';
import Input from '../UI/Inputs/Input/Input';
import ErrorInputText from '../UI/Texts/ErrorInputText/ErrorInputText';
import InputText from '../UI/Texts/InputText/InputText';
import classes from './InputBlock.module.css'

const InputBlock = ({type, text, value, setValue, errors}) => {
    return (
        <div className={classes.inputBlock}>
            <InputText text={text}></InputText>
            <Input type={type} value={value} setValue={setValue}></Input>
            {!!errors.length && <ErrorInputText text={errors[0]}></ErrorInputText>}
        </div>
    );
};

export default InputBlock;