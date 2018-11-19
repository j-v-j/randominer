import React from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Twitch from './components/Twitch';

export default () => (
    <Router>
        <div>
            <ul>
                <li>
                    <Link to="/">Twitch</Link>
                </li>
                <li>
                    <Link to="/Twitch">Twitch</Link>
                </li>
            </ul>

            <hr />
    <Route exact path='/' component={Twitch} />
            <Route path='/twitch' component={Twitch} />
        </div>
    </Router>
);
