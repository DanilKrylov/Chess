import { observer } from 'mobx-react';
import React, { useContext } from 'react';
import { Context } from '../..';
import { BLACK, WHITE } from '../../utils/colors';
import DefaultText from '../UI/Texts/DefaultText/DefaultText';
import classes from './GamePlayerInfo.module.css'

const GamePlayerInfo = observer(({player}) => {
    if(player !== "player" && player !== "opponent")
        throw new Error("invalid player color on GamePlayerInfo");

    const {currentGame} = useContext(Context)
    let isPlayerMove = false

    if(currentGame.playerRole !== BLACK && currentGame.moveTurn === WHITE){
        isPlayerMove = true
    }

    if(currentGame.playerRole === BLACK && currentGame.moveTurn === BLACK){
        isPlayerMove = true
    }
    
    if(player === "player"){
        return (
            <div className={[classes.playerInfo, isPlayerMove && classes.onMoveTurn].join(' ')}>
                <DefaultText text={currentGame.playerEmail}></DefaultText>
            </div>
        );
    }

    if(player === "opponent"){
        return (
            <div className={[classes.playerInfo, !isPlayerMove && classes.onMoveTurn].join(' ')}>
                <DefaultText text={currentGame.opponentEmail}></DefaultText>
            </div>
        );
    }
});

export default GamePlayerInfo;