import React, { Component } from 'react';
import MatchList from './MatchList'
import Axios from 'axios';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props)
    this.state = {
      todayMatches: [],
      previousDayMatches: []
    }
  }

  componentDidMount = () => {
    Axios.get('api/Match/today')
      .then(response => response.data)
      .then(data => this.setState({ todayMatches: data }))
      Axios.get('api/match/previousday')
        .then(response => response.data)
        .then(data => this.setState({ previousDayMatches: data }))
  }

  render () {
    const todayMatches = this.state.todayMatches;
    const previousDayMatches = this.state.previousDayMatches;

    return (
      <div>
        <div className="row">
          <div className="col-lg-6">
          <h2>Today Matches</h2>
            <MatchList matches={todayMatches}/>
          <h2>Previous day matches</h2>
            <MatchList matches={previousDayMatches}/>
          </div>
          <div className="col-lg-6">
            <h2>Top Players</h2>
            <h2>Top Teams</h2>
          </div>
        </div>
      </div>
    );
  }
}
