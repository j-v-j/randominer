import React, { Component } from 'react';
import { Glyphicon } from 'react-bootstrap'

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

    handleClick() {
        this.fetchVideo();
    }

    fetchVideo() {
        fetch('api/twitch/RandomStream')
            .then(response => response.json())
            .then(data => {
                this.setState({ streamData: data });
                console.log(data.user_name);
                if (!this.embedPlayer) {
                    this.embedPlayer = new window.Twitch.Embed('twitch-embed', {
                        width: 854,
                        height: 480,
                        channel: data.user_name,
                        layout: "video"
                    });
                }
                else {
                    let player = this.embedPlayer.getPlayer();
                    player.setChannel(data.user_name);
                }                
            })
            .catch(response => this.setState({ error: response }));
    }

    constructor(props) {
        super(props);
        this.state = { streamData: '', error: '' }

        this.handleClick = this.handleClick.bind(this);

        this.fetchVideo();
    }

    render() {
        return (
            <div>
                <h1> Random Twitch Stream</h1>
                <a href={ TWITCH_URL + this.state.streamData.user_name}>{this.state.streamData.title}</a>
                <div id="twitch-embed"></div>
                <button className="btn btn-primary" onClick={this.handleClick}><Glyphicon glyph="refresh" /> Reroll</button>
            </div>
        );
        
    }
}
export default Twitch;