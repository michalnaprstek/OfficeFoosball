import React, { Component } from 'react'
import ItemSelector from '../item-selector/ItemSelector'

export default class TeamSelector extends Component {

    constructor(props) {
        super(props);

        this.player1Change = this.player1Change.bind(this);
        this.player2Change = this.player2Change.bind(this);
        this.teamChange = this.teamChange.bind(this);
    }

    player1Change(player) {
        if (this.props.onPlayer1Change)
            this.props.onPlayer1Change(player, this.props.name);
    }

    player2Change(player) {
        if (this.props.onPlayer2Change)
            this.props.onPlayer2Change(player, this.props.name);
    }

    teamChange(team) {
        if (this.props.onTeamChange)
            this.props.onTeamChange(team, this.props.name);
    }

    render() {
        const teamName = this.props.teamName;
        const name = this.props.name;
        const players = this.props.players;
        const player1 = this.props.player1;
        const teamMates = this.props.teamMates;
        const player2 = this.props.player2;
        const team = this.props.team;
        const possibleTeams = this.props.possibleTeams;

        return (
            <div>
                <h2>{teamName}</h2>
                <ItemSelector items={players} name={`${name}Player1`} label="Player 1" selectedItem={player1} onChange={this.player1Change} />
                <ItemSelector items={teamMates} name={`${name}Player2`} label="Player 2" selectedItem={player2} onChange={this.player2Change} />
                <ItemSelector items={possibleTeams} name="yellowTeam" label="Team" selectedItem={team} onChange={this.teamChange} />
            </div>
        );
    }

}
