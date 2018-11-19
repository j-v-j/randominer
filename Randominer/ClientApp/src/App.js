import React from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { Col, Grid, Row } from 'react-bootstrap';
import Twitch from './components/Twitch';
import NavMenu from './components/NavMenu';

export default () => (
    <Router>
        <div className="text-center">
            <NavMenu />
            <Route exact path='/' component={Twitch} />
            <Route path='/twitch' component={Twitch} />
        </div>
    </Router>
);
