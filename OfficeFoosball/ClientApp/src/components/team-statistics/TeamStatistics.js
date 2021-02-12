import React from 'react';
import '../Statistics.scss';

export default function TeamStatistics(props) {
  const stats = props.statistics;

  return (
    stats.map((s, index) => {
      return (
        <div className='stats-item' key={index}>
          <div className='row'>
            <div className='stats-item__position'><span>{index + 1}</span></div>
            <div className='stats-item__names'>
              <div className='stats-item__name'>{s.team.name}</div>
              <div className='stats-item__player-names'>{s.team.player1.name}, {s.team.player2.name}</div>
            </div>
            <div className='stats-item__percentage' ><span className={percentageClassification(s.successPercentage)}>{s.successPercentage.toFixed(1)}%</span> | {s.totalMatchCount}</div>
          </div>
        </div>
      );
    })
  );
}

export const percentageClassification = (percentage) => percentage >= 50 ? 'good' : 'bad';
