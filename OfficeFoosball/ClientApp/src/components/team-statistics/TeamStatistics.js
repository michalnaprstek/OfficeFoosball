import React from "react";
import "../Statistics.scss";

export default function TeamStatistics(props) {
    var stats = props.statistics;

    return (
        stats.map((s, index) => {
            return (
                <div className="stats-item row" key={index}>
                    <div className="stats-item__position col-sm-2"><span>{index+1}</span></div>
                    <div className="stats-item__percentage col-sm-4">{s.successPercentage.toFixed(1)}%</div>
                    <div className="stats-item__name col-sm-6">{s.team.name}</div>
                </div>
            );
        })
    );
}