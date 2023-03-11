import React, { useContext, useEffect, useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { observer } from 'mobx-react'
import NavBar from "./pages/NavBar/NavBar";
import RegistrationPage from "./pages/RegistrationPage/RegistrationPage";
import MainPage from "./pages/MainPage/MainPage";
import { REGISTRATION_ROUTE, LOGIN_ROUTE, MAIN_ROUTE, GAME_ROUTE } from "./utils/consts";
import LoginPage from "./pages/LoginPage/LoginPage";
import { Context } from ".";
import { check } from './http/userAPI'
import ChessGamePage from "./pages/ChessGamePage/ChessGamePage";

const App = observer(() => {
  const {userInfo} = useContext(Context)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    check().then(data => {
      if(!data)
        return;
      userInfo.setIsAuth(true)
      userInfo.setUser(data)
    }).finally(() => setLoading(false))
  }, [])

  if(loading){
    return
  }

  return (
    <BrowserRouter>
      <NavBar></NavBar>
      <Routes>
        <Route path={REGISTRATION_ROUTE} element={<RegistrationPage></RegistrationPage>}></Route>
        <Route path={LOGIN_ROUTE} element={<LoginPage></LoginPage>}></Route>
        <Route path={MAIN_ROUTE} element={<MainPage></MainPage>}></Route>
        <Route path={GAME_ROUTE} element={<ChessGamePage></ChessGamePage>}></Route>
      </Routes>
    </BrowserRouter>
  );
})

export default App;
