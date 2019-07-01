import React, { Component } from "react";
import { Redirect } from "react-router-dom";

import "./MatchList.scss";

export default class MatchList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      matches: [],
      matchDetailId: null
    };
  }

  componentDidMount() {
    fetch("api/Match")
      .then(response => response.json())
      .then(data => this.setState({ matches: data }));
  }

  navigateToMatchDetail = id => {
    this.setState({ matchDetailId: id });
  };

  render = () => {
    const matches = this.state.matches;
    if (this.state.matchDetailId !== null) {
      return <Redirect to={"/match-detail/" + this.state.matchDetailId} />;
    }

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
