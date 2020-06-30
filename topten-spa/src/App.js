import React from 'react';
import logo from './logo.svg';
import './App.css';
import FetchWordList from './FetchWordList';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1>Top ten words!</h1>
          <FetchWordList></FetchWordList>
      </header>
    </div>
  );
}

export default App;
