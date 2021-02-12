import React from 'react'
import "./StatsPosition.scss";

export default function StatsPosition (props) {
  const position = props.position;
  const hasRanking = props.hasRanking;
  const title = hasRanking ? '' : props.noRakingMessage;

  return (
    <div className='stats-item__position'><span title={title}>{hasRanking ? position : ''}</span></div>
  );
}