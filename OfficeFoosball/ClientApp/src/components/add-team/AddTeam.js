import React, { Component } from 'react';

export default class AddTeam extends Component {
    constructor(props) {
        super(props);

        this.state = {
            players: [],
            teamName: '',
            teamId: '',
            player1: {
                id: '',
                name: ''
            },
            player2: {
                id: '',
                name: ''
            },
            selectedPlayers: {
                player1Name: null,
                player2Name: null
            }
        };

        fetch('api/Player/')
            .then(response => response.json())
            .then(data => {
                this.setState({ players: data });
            });
    }

    validate = (team) =>
        team.id &&
        team.name &&
        team.player1Id &&
        team.player2Id &&
        team.player1Id !== team.player2Id

    submitHandler = (event) => {
        event.preventDefault();

        let team = {
            id: this.state.teamId,
            name: this.state.teamName,
            player1Id: this.state.player1.id,
            player2Id: this.state.player2.id
        }

        if (!this.validate(team)) {
            alert('Data not valid');

            return;
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

    changeIdHandler = (event) => {
        if (isNaN(event.target.value)) {
            return;
        }

        this.setState({ teamId: event.target.value });
    }

    handleChangePlayer1 = (event) => {
        let playerName = event.target.value;
        let playerId = this.state.players.filter(p => p.name === playerName).map(player => player.id)[0];

        this.setState({
            player1: { id: playerId, name: playerName },
            selectedPlayers: { player1Name: playerName }
        });
    }

    handleChangePlayer2 = (event) => {
        let playerName = event.target.value;
        let playerId = this.state.players.filter(p => p.name === playerName).map(player => player.id)[0];

        this.setState({
            player2: { id: playerId, name: playerName },
            selectedPlayers: { player2Name: playerName }
        });
    }

    render() {
        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new team</h1>
                <label>
                    Id:
                <input
                        type='text'
                        name='username'
                        onChange={this.changeIdHandler}
                    />
                </label>
                <br/>
                <label>
                    Name:
                <input
                        type='text'
                        name='username'
                        onChange={this.changeNameHandler}
                    />
                </label>
                <br />
                <label>
                    Player 1:
                    <select value={this.state.selectedPlayers.player1Name} onChange={this.handleChangePlayer1}>
                        <option value=''></option>
                        {this.state.players.map((x, y) => <option key={y}>{x.name}</option>)}
                    </select>
                </label>
                <label>
                    Player 2:
                    <select value={this.state.selectedPlayers.player2Name} onChange={this.handleChangePlayer2}>
                        <option value=''></option>
                        {this.state.players.map((x, y) => <option key={y}>{x.name}</option>)}
                    </select>
                </label>
                <input type='submit' value='Add' />
            </form>
        );
    }
}