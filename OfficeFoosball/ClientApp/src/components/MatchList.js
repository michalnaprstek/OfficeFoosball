import React, { Component } from "react";
import { withRouter } from 'react-router-dom'
import "./MatchList.scss";

class MatchList extends Component {

  navigateToMatchDetail = id => {
    this.props.history.push(`/match-detail/${id}`);
  };

  render = () => {
    const matches = this.props.matches;

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
            {matches
              ? matches.map((match, key) => {
                  const yellowClass =
                    match.winner === "yellow" ? { className: "winner" } : {};
                  const redClass =
                    match.winner === "red" ? { className: "winner" } : {};
                  return (
                    <tr
                      key={key}
                      onClick={() => this.navigateToMatchDetail(match.id)}
                    >
                      <td {...yellowClass}>{match.yellowTeam}</td>
                      <td className="score">{match.yellowScore}</td>
                      <td className="score">{match.redScore}</td>
                      <td {...redClass}>{match.redTeam}</td>
                      <td>{match.played}</td>
                      <td className="note">{match.note}</td>
                    </tr>
                  );
                })
              : ""}
          </tbody>
        </table>
      </div>
    );
  };
}

export default withRouter(MatchList)
