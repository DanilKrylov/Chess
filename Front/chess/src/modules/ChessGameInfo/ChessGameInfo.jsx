import { observer } from 'mobx-react';
import React, { useContext } from 'react';
import { Context } from '../..';
import GamePlayerInfo from '../../components/GamePlayerInfo/GamePlayerInfo';
import DefaultText from '../../components/UI/Texts/DefaultText/DefaultText';
import classes from './ChessGameInfo.module.css'

const ChessGameInfo = observer(() => {
    const {currentGame} = useContext(Context)
    const text = currentGame.isEnded ? 'Winner is: ' + currentGame.winnerPlayerEmail : 'Game is in procces'

    return (
        <div className={classes.chessGameInfo}>
            <GamePlayerInfo player={"opponent"}></GamePlayerInfo>
            <div className={classes.wrapper}>
                <DefaultText text={text}></DefaultText>
            </div>
            <GamePlayerInfo player={"player"}></GamePlayerInfo>
        </div>
    );
});

export default ChessGameInfo;