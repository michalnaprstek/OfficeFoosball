import React from "react";
import "../Statistics.scss";
import { percentageClassification } from '../team-statistics/TeamStatistics';

export default function PlayerStatistics(props) {
    const stats = props.statistics;

    return (
        stats.map((s, index) => {
            return (
                <div className="stats-item" key={index}>
                    <div className="row">
                        <div className="stats-item__position"><span>{index+1}</span></div>
                        <div className="stats-item__name">{s.player.name}</div>
                      <div className="stats-item__percentage"><span className={percentageClassification(s.successPercentage)}>{s.successPercentage.toFixed(1)}%</span> | {s.totalMatchCount}</div>
                    </div>
                </div>
            );
        })
    );
}