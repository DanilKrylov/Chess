import React, { useContext, useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Context } from '../..';
import ChessBoard from '../../components/ChessBoard/ChessBoard';
import { getGameInfo } from '../../http/gameAPI';
import { setCurrentGameInfo } from '../ChessGame/chessLogic';

const GameResult = () => {
    const {gameId} = useParams()
    const {currentGame, userInfo} = useContext(Context)
    const navigate = useNavigate()

    useEffect(() => {
        getGameInfo(gameId).then(result => {
            if(!result.isEnded){
                navigate('/game/' + gameId)
            }
            setCurrentGameInfo(currentGame, result, userInfo.user)
        })

        return currentGame.clear()
    }, [])

    return (
        <ChessBoard cageWidth={50} currentGame={currentGame} tryMove={() => false}></ChessBoard>
    );
};

export default GameResult;