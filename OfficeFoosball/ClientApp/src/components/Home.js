import React, { Component } from 'react';
import MatchList from './match-list/MatchList'
import PlayerStatistics from './player-statistics/PlayerStatistics'
import TeamStatistics from './team-statistics/TeamStatistics'
import axiosInstance from '../utils/axiosInstance';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props)
    this.state = {
      todayMatches: [],
      previousDayMatches: [],
      playerStatistics: [],
      teamStatistics: []
    }
  }

  componentDidMount = () => {
    axiosInstance.get('match/today')
      .then(response => response.data)
      .then(data => this.setState({ todayMatches: data }))
      axiosInstance.get('match/previousday')
        .then(response => response.data)
        .then(data => this.setState({ previousDayMatches: data }))
      axiosInstance.get('stats/team-success-rates')
          .then(response => response.data)
          .then(data => this.setState({ teamStatistics: data }))
          axiosInstance.get('stats/player-success-rates')
              .then(response => response.data)
              .then(data => this.setState({ playerStatistics: data }))
  }

  render () {
    const todayMatches = this.state.todayMatches;
    const previousDayMatches = this.state.previousDayMatches;
    const playerStatistics = this.state.playerStatistics;
    const teamStatistics = this.state.teamStatistics;
    const noRankingMessage = 'You have to play 5 matches in last 21 days to be ranked.';

    return (
      <div>
        <div className="row">
          <div className="col-lg-6">
          <h2>Today Matches</h2>
            <MatchList matches={todayMatches}/>
          <h2>Previous day Matches</h2>
            <MatchList matches={previousDayMatches}/>
          </div>
          <div className="col-lg-6">
            <h2>Top Players</h2>
              <PlayerStatistics statistics={playerStatistics} noRankingMessage={noRankingMessage} />
            <h2>Top Teams</h2>
              <TeamStatistics statistics={teamStatistics} noRankingMessage={noRankingMessage} />
          </div>
        </div>
      </div>
    );
  }
}
