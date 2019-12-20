import React from "react";
import "../Statistics.scss";

export default function TeamStatistics(props) {
    var stats = props.statistics;

    return (
        stats.map((s, index) => {
            return (
                <div className="stats-item" key={index}>
                    <div className="row">
                        <div className="stats-item__position"><span>{index+1}</span></div>
                        <div className="stats-item__name">{s.team.name}</div>
                        <div className="stats-item__percentage">{s.successPercentage.toFixed(1)}%</div>
                    </div>
                </div>
            );
        })
    );
}