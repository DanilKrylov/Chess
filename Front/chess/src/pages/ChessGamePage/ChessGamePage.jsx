import React from 'react';
import ChessGame from '../../modules/ChessGame/ChessGame';
import MainWrapper from '../../components/MainWrapper/MainWrapper';
import ChessGameInfo from '../../modules/ChessGame/ChessGameInfo/ChessGameInfo';

const ChessGamePage = () => {
    return (
        <MainWrapper>
            <ChessGame></ChessGame>
            <ChessGameInfo></ChessGameInfo>
        </MainWrapper>
    );
};

export default ChessGamePage;