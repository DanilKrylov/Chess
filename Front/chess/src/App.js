import React, { useContext, useEffect, useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { observer } from 'mobx-react'
import NavBar from "./pages/NavBar/NavBar";
import { Context } from ".";
import { check } from './http/userAPI'
import AppRoutes from "./AppRoutes";

const App = observer(() => {
  const {userInfo} = useContext(Context)
  const [loading, setLoading] = useState(true)
  const checkUserAuth = (data) => {
    if(!data)
        return;
    userInfo.setIsAuth(true)
    userInfo.setUser(data)
  }

  useEffect(() => {
    check().then(checkUserAuth).finally(() => setLoading(false))
  }, [])

  if(loading){
    return
  }

  return (
    <BrowserRouter>
      <NavBar></NavBar>
      <AppRoutes></AppRoutes>
    </BrowserRouter>
  );
})

export default App;
