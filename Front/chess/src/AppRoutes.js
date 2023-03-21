import React from 'react';
import { Route, Routes } from 'react-router-dom';
import RegistrationPage from "./pages/RegistrationPage/RegistrationPage";
import MainPage from "./pages/MainPage/MainPage";
import { REGISTRATION_ROUTE, LOGIN_ROUTE, MAIN_ROUTE, GAME_ROUTE, GAMEINFO_ROUTE } from "./utils/routes";
import LoginPage from "./pages/LoginPage/LoginPage";
import ChessGamePage from "./pages/ChessGamePage/ChessGamePage";
import GameResultPage from "./pages/GameResultPage/GameResultPage";

const AppRoutes = () => {
    return (
        <Routes>
            <Route path={REGISTRATION_ROUTE} element={<RegistrationPage></RegistrationPage>}></Route>
            <Route path={LOGIN_ROUTE} element={<LoginPage></LoginPage>}></Route>
            <Route path={MAIN_ROUTE} element={<MainPage></MainPage>}></Route>
            <Route path={GAME_ROUTE} element={<ChessGamePage></ChessGamePage>}></Route>
            <Route path={GAMEINFO_ROUTE} element={<GameResultPage></GameResultPage>}></Route>
        </Routes>
    );
};

export default AppRoutes;