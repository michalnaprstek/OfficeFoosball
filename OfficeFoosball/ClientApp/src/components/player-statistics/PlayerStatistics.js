import React from 'react';
import '../Statistics.scss';
import StatsPosition from '../stats-position/StatsPosition';
import PercentageDisplay from '../percentage-display/PercentageDisplay';

export default function PlayerStatistics(props) {
  const { statistics, noRankingMessage } = props;

  return (
    statistics.map((s, index) => {
      return (
        <div className='stats-item' key={index}>
          <div className='row'>
            <StatsPosition position={index + 1} hasRanking={s.hasRanking} noRakingMessage={noRankingMessage} />
            <div className='stats-item__name'>{s.player.name}</div>
            <PercentageDisplay
              percentage={s.successPercentage}
              hasRanking={s.hasRanking}
              totalMatchCount={s.totalMatchCount}
              matchCountInRanking={s.matchCountInRanking}
              noRakingMessage={noRankingMessage} />
          </div>
        </div>
      );
    })
  );
}