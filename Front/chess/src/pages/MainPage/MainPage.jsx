import React from 'react';
import MainWrapper from '../../components/MainWrapper/MainWrapper';
import GameSearchBar from '../../modules/GameSearch/GameSearchBar';

const MainPage = () => {
    return (
        <MainWrapper>
            <GameSearchBar></GameSearchBar>
        </MainWrapper>
    );
};

export default MainPage;