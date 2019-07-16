import React, { Component } from 'react';
import MatchList from './MatchList'
import Axios from 'axios';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props){
    super(props)
    this.state = {
      matches: []
    }
  }

  componentDidMount = () => {
    Axios.get('api/Match')
      .then(response => response.data)
      .then(data => this.setState({ matches: data }))
  }

  render () {
    const matches = this.state.matches;

    return (
      <div>
        <h1>Office Foosball League</h1>
        <MatchList matches={matches}/>
      </div>
    );
  }
}
