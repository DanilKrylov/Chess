import React from 'react';
import ChessGame from '../../modules/ChessGame/ChessGame';
import MainWrapper from '../../components/MainWrapper/MainWrapper';

const ChessGamePage = () => {
    return (
        <MainWrapper>
            <ChessGame></ChessGame>
        </MainWrapper>
    );
};

export default ChessGamePage;