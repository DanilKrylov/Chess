import React from 'react';
import MainWrapper from '../../components/MainWrapper/MainWrapper';
import ChessGameInfo from '../../modules/ChessGameInfo/ChessGameInfo';
import GameResult from '../../modules/GameResult/GameResult';

const GameResultPage = () => {
    return (
        <MainWrapper>
            <GameResult></GameResult>
            <ChessGameInfo></ChessGameInfo>
        </MainWrapper>
    );
};

export default GameResultPage;