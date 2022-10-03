import React, { useState, useEffect } from 'react';
import axiosInstance from '../../utils/axiosInstance';
import Select from 'react-select'
import { useNavigate } from 'react-router-dom';

const AddTeam = () => {
    const navigate = useNavigate();

    const [players, setPlayers] = useState([]);
    const [teamName, setTeamName] = useState('');
    const [teamId, setTeamId] = useState('');
    const [player1Id, setPlayer1Id] = useState(undefined);
    const [player2Id, setPlayer2Id] = useState(undefined);
    const [error, setError] = useState('');

    const loadPlayers = async () => {
        const response = await axiosInstance.get('Player');
        if (response.status === 200) {
            setPlayers(response.data);
        }
    }

    useEffect(() => {
        loadPlayers();
    }, []);

    const validate = (team) => {
        if (!team.name) return { ok: false, errorMessage: 'Please give us your original team name.' };
        if (!team.player1Id) return { ok: false, errorMessage: `Please select first player of ${team.name}.` };
        if (!team.player2Id) return { ok: false, errorMessage: `Did you know that optimal number of players in foosball team is 2? Please select second player of ${team.name}` };
        return { ok: true };
    }

    const getTeam = () => {
        return {
            name: teamName,
            player1Id: player1Id,
            player2Id: player2Id
        };
    }

    const submitHandler = async (event) => {
        event.preventDefault();

        const team = getTeam();

        const validationResult = validate(team);
        if (!validationResult.ok) {
            setError(validationResult.errorMessage);
            return;
        }

        const response = await axiosInstance.post('Team', team, { headers: { 'Content-Type': 'application/json' } });
        if (response.status === 201) {
            navigate('/');
            return;
        }

        setError(response.error);
    }

    const changeNameHandler = (event) => {
        setTeamName(event.target.value);
    }

    const changeIdHandler = (event) => {
        if (isNaN(event.target.value)) {
            return;
        }

        setTeamId(event.target.value);
    }

    const handleChangePlayer1 = (selectedOption) => {
        setPlayer1Id(selectedOption.value);
    }

    const handleChangePlayer2 = (selectedOption) => {
        setPlayer2Id(selectedOption.value);
    }

    const getFilteredPlayerOptions = (playerId) => players
        .filter(player => player.id !== playerId)
        .map(player => ({ value: player.id, label: player.name }));


    const customStyles = {
        menu: (provided, state) => ({
            ...provided,
            color: '#000000',
        })
    }

    const errorMessage = error;
    const player1Options = getFilteredPlayerOptions(player2Id);
    const player2Options = getFilteredPlayerOptions(player1Id);

    return (
        <form onSubmit={submitHandler}>
            <h1>Add new team</h1>
            {errorMessage &&
                <div>
                    <span className="error">{errorMessage}</span>
                </div>
            }
            <input className="form-input"
                type='text'
                name='teamname'
                placeholder="Team name"
                onChange={changeNameHandler} />
            <Select
                onChange={handleChangePlayer1}
                options={player1Options}
                placeholder="Player 1"
                className="form-input"
                styles={customStyles}
            />
            <Select
                onChange={handleChangePlayer2}
                options={player2Options}
                placeholder="Player 2"
                className="form-input"
                styles={customStyles}
            />
            <input className="btn btn-primary" type='submit' value='Add' />
        </form>
    );

}

export default AddTeam;