import React, { useState, useEffect } from 'react';

import TeamSelector from '../team-selector/TeamSelector'
import './InsertMatch.scss';
import ScoreInput from '../score-input/ScoreInput';
import axiosInstance from '../../utils/axiosInstance';
import { useNavigate } from 'react-router-dom';

const InsertMatch = () => {
    const navigate = useNavigate();
    const [players, setPlayers] = useState([]);
    const [teams, setTeams] = useState([]);
    const [errorMessage, setErrorMessage] = useState('');
    const [team1, setTeam1] = useState(undefined);
    const [team1Score, setTeam1Score] = useState(0);
    const [team1Player1, setTeam1Player1] = useState(undefined);
    const [team1Player2, setTeam1Player2] = useState(undefined);
    const [team1Mates, setTeam1Mates] = useState([]);
    const [team1PossibleTeams, setTeam1PossibleTeams] = useState([]);
    const [team2Player1, setTeam2Player1] = useState(undefined);
    const [team2Player2, setTeam2Player2] = useState(undefined);
    const [team2Mates, setTeam2Mates] = useState([]);
    const [team2PossibleTeams, setTeam2PossibleTeams] = useState([]);
    const [team2Score, setTeam2Score] = useState(0);
    const [team2, setTeam2] = useState(undefined);
    const [note, setNote] = useState('');

    const loadPlayers = async () => {
        const response = await axiosInstance.get('Player/');
        if (response.status === 200) {
            setPlayers(response.data);
        }
    };

    const loadTeams = async () => {
        const response = await axiosInstance.get('Team/');
        if (response.status === 200) {
            setTeams(response.data);
            setTeam1PossibleTeams(response.data);
            setTeam2PossibleTeams(response.data);
        }
    }

    useEffect(() => {
        loadPlayers();
        loadTeams();
    }, []);

    const displayError = (errorMessage) => {
        setErrorMessage(errorMessage);
    }

    const getPlayer = (id) =>
        players ? players.find(p => p.id === id) : null;

    const isPlayerInTeam = (team, player) =>
        player && team.playerIds.some(x => x === player.id);

    const getPossibleTeamMates = (player) => {
        if (!player)
            return players ? players : [];

        let mates = [];

        getPossibleTeams(player, teams)
            .forEach(team => mates.push(getSecondPlayer(team, player, players)));

        return mates
    }

    const getSecondPlayerId = (team, player) => team.player1.id === player.id
        ? team.player2.id
        : team.player1.id;

    const getSecondPlayer = (team, player, players) => players
        ? players.find(p => p.id === getSecondPlayerId(team, player))
        : null;



    const getPossibleTeams = (player, teams) => {
        if (!player)
            return teams ? teams : [];

        return teams
            .filter(x => isPlayerInTeam(x, player));
    }

    const getTeam = (player1, player2, teams) => {
        if (!player1 || !player2)
            return teams;

        return teams
            .find(x => isPlayerInTeam(x, player1) && isPlayerInTeam(x, player2));
    }

    const team1Player1Change = (player) => {
        const possibleTeams = player
            ? teams.filter(t => isPlayerInTeam(t, player))
            : teams;

        const team = possibleTeams && possibleTeams.length === 1
            ? possibleTeams[0]
            : null;


        const mates = getPossibleTeamMates(player);

        const player2 = mates && mates.length === 1
            ? mates[0]
            : null;

        setTeam1(team);
        setTeam1Player1(player);
        setTeam1Player2(player2);
        setTeam1Mates(mates);
        setTeam1PossibleTeams(possibleTeams);
    }

    const team2Player1Change = (player) => {
        const possibleTeams = player
            ? teams.filter(t => isPlayerInTeam(t, player))
            : teams;

        const team = possibleTeams && possibleTeams.length === 1
            ? possibleTeams[0]
            : null;


        const mates = getPossibleTeamMates(player);

        const player2 = mates && mates.length === 1
            ? mates[0]
            : null;

        setTeam2(team);
        setTeam2Player1(player);
        setTeam2Player2(player2);
        setTeam2Mates(mates);
        setTeam2PossibleTeams(possibleTeams);
    }

    const team1Player2Change = (player) => {
        setTeam1Player2(player);
        setTeam1PossibleTeams(teams);
        if (team1Player1) {
            const team = getTeam(team1Player1, player, teams);
            setTeam1(team);
        }
    }

    const team2Player2Change = (player) => {
        setTeam2Player2(player);
        setTeam2PossibleTeams(teams);
        if (team2Player1) {
            const team = getTeam(team2Player1, player, teams);
            setTeam2(team);
        }
    }

    const team1Change = (team) => {
        const player1 = team ? getPlayer(team.player1.id) : null;
        const player2 = team ? getPlayer(team.player2.id) : null;


        setTeam1(team);
        setTeam1Player1(player1);
        setTeam1Player2(player2);
        setTeam1Mates(getPossibleTeamMates(player1));
        setTeam1PossibleTeams(teams);
    }

    const team2Change = (team) => {
        const player1 = team ? getPlayer(team.player1.id) : null;
        const player2 = team ? getPlayer(team.player2.id) : null;


        setTeam2(team);
        setTeam2Player1(player1);
        setTeam2Player2(player2);
        setTeam2Mates(getPossibleTeamMates(player1));
        setTeam2PossibleTeams(teams);
    }

    const team1ScoreChange = (score) => {
        setTeam1Score(score);
        (score !== 1 && score < 10) && setTeam2Score(10);
    }

    const team2ScoreChange = (score) => {
        setTeam2Score(score);
        (score !== 1 && score < 10) && setTeam1Score(10);
    }

    const noteChange = (event) => {
        setNote(event.target.value);
    }

    const save = async () => {

        var match = {
            team1Id: team1.id,
            team1: team1,
            team1Score: team1Score,
            team2Id: team2.id,
            team2: team2,
            team2Score: team2Score,
            note: note
        };

        if (!validate(match))
            return;

        const response = await axiosInstance
            .post('match', match, { headers: { 'Content-Type': 'application/json' } });

        if (response.status === 201) {
            navigate('/')
            return;
        }

        displayError(response.errorMessage);
    }

    const validate = (matchData) =>
        matchData.team1 &&
        matchData.team2 &&
        matchData.team1.id !== matchData.team2.id &&
        (
            (matchData.team2Score === 10 && (matchData.team1Score || matchData.team1Score === 0)) ||
            (matchData.team1Score === 10 && (matchData.team2Score || matchData.team2Score === 0))
        ) &&
        matchData.team2 !== matchData.team1;

    const isDisabled = !validate({ team1, team2, team1Score, team2Score, note });

    return (
        <div className="insert-match">
            <section className="insert-match__teams">
                <div className="yellow row insert-match__team">

                    <div className="insert-match__team-wrapper">
                        <span className="insert-match__team-name">Team 1</span>
                        <TeamSelector
                            teamName="Team 1"
                            name="team1"
                            possibleTeams={team1PossibleTeams}
                            team={team1}
                            players={players}
                            player1={team1Player1}
                            teamMates={team1Mates}
                            player2={team1Player2}
                            onPlayer1Change={team1Player1Change}
                            onPlayer2Change={team1Player2Change}
                            onTeamChange={team1Change} />

                        <ScoreInput name='team1' change={team1ScoreChange} value={team1Score} />
                    </div>
                </div>

                <div className="red row insert-match__team">
                    <div className="insert-match__team-wrapper">
                        <span className="insert-match__team-name">Team 2</span>
                        <TeamSelector
                            teamName="Team 2"
                            name="team2"
                            possibleTeams={team2PossibleTeams}
                            team={team2}
                            players={players}
                            player1={team2Player1}
                            teamMates={team2Mates}
                            player2={team2Player2}
                            onPlayer1Change={team2Player1Change}
                            onPlayer2Change={team2Player2Change}
                            onTeamChange={team2Change} />
                        <ScoreInput name='team2' change={team2ScoreChange} value={team2Score} />
                    </div>
                </div>
            </section>
            <div className="insert-match__note">

                <div className="note">
                    <label htmlFor="note">Note</label>
                    <div>
                        <textarea name="note" tabIndex="3" onChange={noteChange} />
                    </div>
                </div>
            </div>
            <span className="error">{errorMessage}</span>
            <section className="insert-match__buttons">
                <button className="btn btn-primary " tabIndex="4" disabled={isDisabled} onClick={save}>Save</button>
            </section>
        </div>
    );
}

export default InsertMatch;