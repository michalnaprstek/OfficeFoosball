import React from 'react'
import PropTypes from 'prop-types'

import './Scoreboard.scss'

//TODO: Make team names clickable (link to team detail)
function Scoreboard(props) {
    return (
        <div className="score-board">
            <div className="score-board__team-name">{props.yellowTeam}</div>
            <div className="score-board__score">
                {props.yellowTeamScore} : {props.redTeamScore}
            </div>
            <div className="score-board__team-name">{props.redTeam}</div>
        </div>
    )
}

Scoreboard.propTypes = {
    yellowTeam: PropTypes.string,
    redTeam: PropTypes.string
}

export default Scoreboard

