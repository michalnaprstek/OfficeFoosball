import React, { Component } from 'react';

export default class AddTeam extends Component {
    constructor(props) {
        super(props);

        this.state = {
            players: [],
            teamName: '',
            player1Id: '',
            player2Id: ''
        };

        fetch('api/Player/')
            .then(response => response.json())
            .then(data => {
                this.setState({ players: data });
            });
    }

    submitHandler = (event) => {
        event.preventDefault();

        let team = {
            name: this.state.teamName,
            player1Id: this.state.player1Id,
            player2Id: this.state.player2Id
        }

        fetch('api/Team', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(team)
        }).then(() => window.location = './');
    }

    changeNameHandler = (event) => {
        this.setState({ teamName: event.target.value });
    }

    render() {
        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new team</h1>
                <p>Name:</p>
                <input
                    type='text'
                    name='username'
                    onChange={this.changeNameHandler}
                />
                <input type='submit' value='Add' />
            </form>
        );
    }
}