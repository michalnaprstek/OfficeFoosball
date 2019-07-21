import React, { Component } from 'react';

export default class AddPlayer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            nick: '',
            message: ''
        };

    }

    submitHandler = (event) => {
        event.preventDefault();

        let player = {
            name: this.state.nick,
            id: 1000
        }

        fetch('api/Player', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(player)
        }).then(() => window.location = './');
    }

    changeNameHandler = (event) => {
        this.setState({ nick: event.target.value });
    }

    render() {
        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new player</h1>
                <p>Name:</p>
                <input
                    type='text'
                    name='username'
                    onChange={this.changeNameHandler}
                />
                <input type='submit' value='Add' />
            </form>
        );
    }
}