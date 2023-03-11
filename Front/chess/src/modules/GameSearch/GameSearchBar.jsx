import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Context } from '../..';
import SearchModalWindow from '../../components/SearchModalWindow/SearchModalWindow';
import StartSearchButton from '../../components/UI/Buttons/StartSearchButton/StartSearchButton';
import DefaultText from '../../components/UI/Texts/DefaultText/DefaultText';
import { finishSearch, startSearch } from '../../http/searchAPI';

const GameSearchBar = () => {
    const {userInfo} = useContext(Context)
    const navigate = useNavigate()
    const [isInSearch, setIsInSearch] = useState(false)
     
    function onFinishSearch(game) {
        localStorage.setItem('game', game.gameId)
        navigate('/game/' + game.gameId)
    }

    function start(){
        setIsInSearch(true)
        startSearch(onFinishSearch)
    }

    async function stop(){
        setIsInSearch(false)
        await finishSearch()
    }

    if(!userInfo.isAuth){
        return (
            <DefaultText text='Please sign in'></DefaultText>
        )
    }


    return (
        <div>
            {isInSearch && <SearchModalWindow stopSearch={stop}></SearchModalWindow>}
            {!isInSearch && <StartSearchButton onClick={start}></StartSearchButton>}
        </div>
    );
};

export default GameSearchBar;