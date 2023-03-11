import React, { createContext } from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { CurrentGameStore } from './store/CurrentGameStore';
import { UserStore } from './store/UserStore';
import "./styles/nullstyle.css"


export const Context = createContext(null);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Context.Provider value={{
    userInfo: new UserStore(),
    currentGame: new CurrentGameStore()
  }}>
    <App />
  </Context.Provider>
);
