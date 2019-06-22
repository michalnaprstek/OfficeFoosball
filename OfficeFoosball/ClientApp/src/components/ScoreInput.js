import React, {Component} from 'react'

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
            <div className="score">
                <h3>Score</h3>
                <input name={`score-${name}`} type="text" tabIndex="2" onChange={this.change} value={value}/>
            </div> 
        );
    }

}