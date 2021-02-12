import React, { Component } from "react";
import { withRouter } from 'react-router-dom'
import "./MatchList.scss";

class MatchList extends Component {

  navigateToMatchDetail = id => {
    this.props.history.push(`/match-detail/${id}`);
  };

  render = () => {
    const matches = this.props.matches;

    if(!matches || matches.length === 0)
      return "No matches.";

       return matches.map((match, key) => {
                  const yellowClass =
                    match.winner === "yellow" ? 'winner' : 'looser';
                  const redClass =
                    match.winner === "red" ? 'winner' : 'looser';
                  const note = match.note ? `„${match.note}“` : '';
                  return (
                    <div className="match-list-item"
                      key={key}
                      // onClick={() => this.navigateToMatchDetail(match.id)}
                      >
                      <div className="match-list-item__team-name row">
                        <div className={`col-6 ${yellowClass}`}>{match.yellowTeam.name}</div>
                        <div className={`col-6 ${redClass}`}>{match.redTeam.name}</div>
                      </div>
                      <div className="match-list-item__team-members row">
                        <div className={`col-6 ${yellowClass}`}>{match.yellowTeam.player1.name}, {match.yellowTeam.player2.name}</div>
                          <div className={`col-6 ${redClass}`}>{match.redTeam.player1.name}, {match.redTeam.player2.name}</div>
                      </div>
                      
                      <div className="match-list-item__score row">
                        <div className={`col-6 ${yellowClass}`}>{match.yellowScore}</div>
                        <div className={`col-6 ${redClass}`}>{match.redScore}</div>
                      </div>
                      <div className="match-list-item__note">
                      {note}
                      </div>
                      <div className="match-list-item__played">
                        {match.played}
                      </div>
                    </div>
                  );
                });
  };
}

export default withRouter(MatchList)
