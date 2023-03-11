import React from 'react';
import DefaultText from '../UI/Texts/DefaultText/DefaultText';
import classes from './SearchModalWindow.module.css'
import SubmitButton from '../UI/Buttons/SubmitButton/SubmitButton'

const SearchModalWindow = ({stopSearch}) => {
    return (
        <div className={classes.searchModal}>
            <DefaultText text={'Searching players...'}></DefaultText>
            <SubmitButton onClick={stopSearch} text={'Stop search'}></SubmitButton>
        </div>
    );
};

export default SearchModalWindow;