import React, {Component} from 'react'
import './ScoreInput.scss'

export default class ScoreInput extends Component{ 

    change = (event) => {
        var score = parseInt(event.target.value, 10);
        if(score && (score < 0 || score > 10)){
            return;
        }
        if(this.props.change)
            this.props.change(score, this.props.name);
    }

    render(){
        const name = this.props.name;
        const value = this.props.value;

        return (
            <div>
                <label for={`score-${name}`}>Score</label>
                <select className="score-input" name={`score-${name}`} tabIndex="2" onChange={this.change} value={value}>
                    <option value="0">0</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                </select>
            </div>
        );
    }

}