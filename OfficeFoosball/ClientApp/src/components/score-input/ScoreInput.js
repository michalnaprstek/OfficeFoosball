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
                <input className="score-input" name={`score-${name}`} type="number" min="0" max="10" tabIndex="2" onChange={this.change} value={value}/>
        );
    }

}