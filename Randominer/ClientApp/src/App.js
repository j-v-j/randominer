import React from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Twitch from './components/Twitch';
import NavMenu from './components/NavMenu';

export default () => (
    <Router>
        <div className="text-center">
            <Route exact path='/' component={Twitch} />
            <Route path='/twitch' component={Twitch} />
        </div>
    </Router>
);
