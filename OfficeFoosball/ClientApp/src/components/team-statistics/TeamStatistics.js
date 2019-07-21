import React from "react";
import "../Statistics.scss";

export default function TeamStatistics(props) {
    var stats = props.statistics;

    return (
        stats.map((s, index) => {
            return (
                <div className="stats-item row" key={index}>
                    <div className="stats-item__position"><span>{index+1}</span></div>
                    <div className="row stats-item__container">
                        <div className="stats-item__percentage">{s.successPercentage.toFixed(1)}%</div>
                        <div className="stats-item__name">{s.team.name}</div>
                    </div>
                </div>
            );
        })
    );
}