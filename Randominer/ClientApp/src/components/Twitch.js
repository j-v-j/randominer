import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

const TWITCH_EMBED_URL = "https://embed.twitch.tv/embed/v1.js";
const TWITCH_URL = "https://twitch.tv/"
export class Twitch extends Component {

    componentDidMount() {
        const script = document.createElement('script');
        script.setAttribute(
            'src',
            TWITCH_EMBED_URL
        );

        document.body.appendChild(script);
    }

    constructor(props) {
        super(props);
        this.state = { streamData: '', error: '' }

        fetch('api/twitch/RandomStream')
            .then(response => response.json())
            .then(data => {
                this.setState({ streamData: data });
                console.log(data.user_name);
                new window.Twitch.Embed('twitch-embed', {
                    width: 854,
                    height: 480,
                    channel: data.user_name,
                    layout: "video"
                });
            })
            .catch(response => this.setState({ error: response }));
    }

    render() {
        return (
            <div>
                <h1> Random Twitch Stream</h1>
                <a href={ TWITCH_URL + this.state.streamData.user_name}>{this.state.streamData.title}</a>
                <div id="twitch-embed"></div>
            </div>
        );
        
    }
}
export default Twitch;