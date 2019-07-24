import React, { Component } from 'react';

export default class AddPlayer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            id: '',
            nick: '',
            message: ''
        };

    }

    validate = (player) =>
        player.id &&
        player.nick 

    submitHandler = (event) => {
        event.preventDefault();

        let player = {
            id: this.state.id,
            name: this.state.nick
        }

        if (!this.validate(player)) {
            alert('Data not valid');

            return;
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

    changeIdHandler = (event) => {
        if (isNaN(event.target.value)) {
            return;
        }

        this.setState({ id: event.target.value });
    }

    render() {
        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new player</h1>
                <label>
                    Id:
                <input
                        type='text'
                        name='username'
                        onChange={this.changeIdHandler}
                    />
                </label>
                <br />
                <label>
                    Name:
                <input
                        type='text'
                        name='username'
                        onChange={this.changeNameHandler}
                    />
                </label><br />
                <input type='submit' value='Add' />
            </form>
        );
    }
}