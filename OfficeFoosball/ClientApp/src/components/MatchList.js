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
      return "Žádné zápasy";

       return matches.map((match, key) => {
                  const yellowClass =
                    match.winner === "yellow" ? 'winner' : '';
                  const redClass =
                    match.winner === "red" ? 'winner' : '';
                  return (
                    <div className="match-list-item"
                      key={key}
                      onClick={() => this.navigateToMatchDetail(match.id)}>
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
                        {match.note}
                      </div>
                      <div className="match-list-item__played">
                        {match.played}
                      </div>
                    </div>
                  );
                });

    // return (
    //   <div>
    //     <table>
    //       <thead>
    //         <tr>
    //           <th>Yellow team</th>
    //           <th className="score">Yellow score</th>
    //           <th className="score">Red score</th>
    //           <th>Red team</th>
    //           <th>Played</th>
    //           <th>Note</th>
    //         </tr>
    //       </thead>
    //       <tbody>
    //         {matches
    //           ? matches.map((match, key) => {
    //               const yellowClass =
    //                 match.winner === "yellow" ? { className: "winner" } : {};
    //               const redClass =
    //                 match.winner === "red" ? { className: "winner" } : {};
    //               return (
    //                 <tr
    //                   key={key}
    //                   onClick={() => this.navigateToMatchDetail(match.id)}
    //                 >
    //                   <td {...yellowClass}>{match.yellowTeam}</td>
    //                   <td className="score">{match.yellowScore}</td>
    //                   <td className="score">{match.redScore}</td>
    //                   <td {...redClass}>{match.redTeam}</td>
    //                   <td>{match.played}</td>
    //                   <td className="note">{match.note}</td>
    //                 </tr>
    //               );
    //             })
    //           : ""}
    //       </tbody>
    //     </table>
    //   </div>
    // );
  };
}

export default withRouter(MatchList)
