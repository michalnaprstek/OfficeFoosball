import React, { Component } from 'react'
import './MatchList.css'

export default class MatchList extends Component {
    constructor(props){
        super(props);

        this.state = {matches:  []};
        fetch("api/Match")
        .then(response => response.json())
        .then(data => this.setState({ matches: data }));
    }

    render = () => {
        var matches = this.state.matches;

        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Yellow team</th>
                            <th className="score">Yellow score</th>
                            <th className="score">Red score</th>
                            <th>Red team</th>
                            <th>Played</th>
                            <th>Note</th>
                        </tr>
                    </thead>
                    <tbody>
                    {matches ? matches.map((match, key) => 
                    {
                        const yellowClass = match.winner === 'yellow' ? { className: 'winner'} : {};
                        const redClass = match.winner === 'red' ? { className: 'winner'} : {};
                        return (
                            <tr key={key}>
                                <td {...yellowClass}>{match.yellowTeam}</td>
                                <td className="score">{match.yellowScore}</td>
                                <td className="score">{match.redScore}</td>
                                <td {...redClass}>{match.redTeam}</td>
                                <td>{match.played}</td>
                                <td className="note">{match.note}</td>
                            </tr>
                        ) 
                    }) : ''
                    }
                    </tbody>
                </table>
            </div>
        );
    }
}