import React, { Component } from "react";
import FootballField from "../football-field/FootballField";
import Scoreboard from "../scoreboard/Scoreboard";

const mockMatch = {};

export default class MatchDetail extends Component {
  render() {
    return (
      <div>
        <div>
          <Scoreboard
            yellowTeam="Big Dicks"
            redTeam="Dve lamy na pastve"
            yellowTeamScore="5"
            redTeamScore="10"
          />
        </div>
        <p>Esse enim nisi laborum dolore id occaecat ut labore ullamco. Amet ullamco amet sit ea ut. Aliquip quis ex id pariatur incididunt ex. Mollit ad velit in deserunt Lorem Lorem exercitation ea eu eu. Sint ad aliqua id elit.</p>
        {/* <h4>Team Line Up</h4> */}
        <div>
            <FootballField />
        </div>
      </div>
    );
  }
}
