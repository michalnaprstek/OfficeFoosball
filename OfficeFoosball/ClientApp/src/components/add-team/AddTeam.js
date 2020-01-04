import React, { Component } from 'react';
import axiosInstance from '../../utils/axiosInstance';
import { withRouter } from 'react-router-dom'
import Select from 'react-select'
import './AddTeam.scss'

export default class AddTeam extends Component {
    constructor(props) {
        super(props);

        this.state = {
            players: [],
            teamName: '',
            teamId: '',
            player1Id: undefined,
            player2Id: undefined,
            error: ''
        };
    }

    componentDidMount = async () => {
        await this.loadPlayers();
    }

    loadPlayers = async () => {
        const response = await axiosInstance.get('Player');
        if(response.status === 200){
            this.setState({ players: response.data })
        }
    }

    validate = (team) => {
        if(!team.name) return { ok: false, errorMessage: 'Please give us your original team name.'};
        if(!team.player1Id) return { ok: false, errorMessage: `Please select first player of ${team.name}.`};
        if(!team.player2Id) return { ok: false, errorMessage: `Did you know that optimal number of players in foosball team is 2? Please select second player of ${team.name}`};
        return { ok: true };
    }

    getTeam = () => {
        return {
            name: this.state.teamName,
            player1Id: this.state.player1Id,
            player2Id: this.state.player2Id
        };
    }

    submitHandler = async (event) => {
        event.preventDefault();

        const team = this.getTeam();

        const validationResult = this.validate(team);
        if (!validationResult.ok) {
            this.setState({ error: validationResult.errorMessage });
            return;
        }

        const response = await axiosInstance.post('Team', team, { headers: { 'Content-Type': 'application/json' }});
        if(response.status === 201){
            this.props.history.push('/');
            return;
        }

        this.setState({ error: response.error })
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

    handleChangePlayer1 = (selectedOption) => {
        const playerId = selectedOption.value;

        this.setState({
            player1Id: playerId,
        });
    }

    handleChangePlayer2 = (selectedOption) => {
        const playerId = selectedOption.value;

        this.setState({
            player2Id: playerId,
        });
    }

    getFilteredPlayerOptions = (playerId) => this.state.players
        .filter(player => player.id !== playerId)
        .map(player => ({ value: player.id, label: player.name }));

    render() {
        const customStyles = {
            menu: (provided, state) => ({
              ...provided,
              color: '#000000',
            })
          }

        const errorMessage = this.state.error;
        const player1Options = this.getFilteredPlayerOptions(this.state.player2Id);
        const player2Options = this.getFilteredPlayerOptions(this.state.player1Id);

        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new team</h1>
                {errorMessage &&
                    <div>
                        <span className="error">{errorMessage}</span>
                    </div>
                }
                <input  className="form-input"
                        type='text'
                        name='teamname'
                        placeholder="Team name"
                        onChange={this.changeNameHandler}/>
                <Select
                    onChange={this.handleChangePlayer1}
                    options={player1Options}
                    placeholder="Player 1"
                    className="form-input"
                    styles={customStyles}
                />
                <Select
                    onChange={this.handleChangePlayer2}
                    options={player2Options}
                    placeholder="Player 2"
                    className="form-input"
                    styles={customStyles}
                />
                <input className="btn btn-primary" type='submit' value='Add' />
            </form>
        );
    }
}