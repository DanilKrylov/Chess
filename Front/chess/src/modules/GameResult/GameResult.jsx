import React, { useContext, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Context } from '../..';
import ChessBoard from '../../components/ChessBoard/ChessBoard';
import { getGameInfo } from '../../http/gameAPI';
import { setCurrentGameInfo } from '../ChessGame/chessLogic';

const GameResult = () => {
    const {gameId} = useParams()
    const {currentGame, userInfo} = useContext(Context)

    useEffect(() => {
        getGameInfo(gameId).then(result => {
            console.log(result)
            setCurrentGameInfo(currentGame, result, userInfo.user)
        })

        return currentGame.clear()
    }, [])

    return (
        <ChessBoard cageWidth={50} currentGame={currentGame} tryMove={() => false}></ChessBoard>
    );
};

export default GameResult;