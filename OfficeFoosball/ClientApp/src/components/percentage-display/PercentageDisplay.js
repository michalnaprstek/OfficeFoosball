import React from 'react';
import './PercentageDisplay.scss';

export default function PercentageDisplay(props) {
  const {
    percentage,
    totalMatchCount,
    matchCountInRanking,
    hasRanking,
    noRakingMessage
  } = props;

  const title = hasRanking ? '' : noRakingMessage;
  const percentageStr = hasRanking ? `${percentage.toFixed(1)}%` : '-';
  const classificationClass = hasRanking ? percentage >= 50 ? 'good' : 'bad' : '';

  return (
    <div className='stats-item__percentage'>
      <span className={classificationClass} title={title}>{percentageStr}</span> | <span title="Number of matches in last 21 days">{matchCountInRanking}</span> | <span title="Total number of matches">{totalMatchCount}</span>
    </div>
  );
}