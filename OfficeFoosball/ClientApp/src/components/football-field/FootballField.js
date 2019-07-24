import React from "react";

import "./FootballField.scss";
import field from "../../assets/images/field.png";
import profilePicture from "../../assets/images/profile-picture.jpg";

//TODO: Pass props from a higher-order componets
export default function FootballField(props) {
  return (
    <section className="field">
      <div className="line-up">
        <a className="goalkeeper-yellow-team" href="">
          <img src={profilePicture} alt="profile" />
        </a>
        <a className="striker-yellow-team">
          <img src={profilePicture} alt="profile" />
        </a>
        <a className="goalkeeper-red-team">
          <img src={profilePicture} alt="profile" />
        </a>
        <a className="striker-red-team">
          <img src={profilePicture} alt="profile" />
        </a>
        <img className="field" src={field} alt="Football field" />
        <div className="team-name">
          <div>Home Team</div>
          <div>Away Team</div>
        </div>
      </div>
    </section>
  );
}
