import React, { Component } from 'react';
import MatchList from './MatchList'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Office Foosball League</h1>
        <MatchList/>
      </div>
    );
  }
}
