import React, {Component} from 'react'

export default class ScoreInput extends Component{
    constructor(props){
        super(props);

        this.change = this.change.bind(this);
    }

    change(event){
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
        const errorMessage = this.props.errorMessage;
        const title = errorMessage ? errorMessage : 'score';
        const className = errorMessage ? '' : 'invalid';

        return (
            <div className="score">
                <h3>Score</h3>
                <input name={`score-${name}`} type="text" tabIndex="2" className={className} title={title} onChange={this.change} value={value}/>
            </div> 
        );
    }

}