import React from 'react';
import { BrowserRouter as Router, Route } from "react-router-dom";
import './App.css';

import { Provider } from "react-redux"; 
import createStore from "./store";
const { store } = createStore();

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <Router>
          <>
           
          </>
        </Router>
      </Provider>
    </div>
  );
}

export default App;
