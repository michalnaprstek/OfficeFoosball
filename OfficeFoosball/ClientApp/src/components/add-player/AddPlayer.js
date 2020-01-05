import React, { Component } from 'react';
import axiosInstance from '../../utils/axiosInstance';
//import Select from 'react-select'

export default class AddPlayer extends Component {
    constructor(props) {
        super(props);

        this.state = {
            nick: '',
            userId: undefined,
            message: '',
            //users: []
        };

    }

    componentDidMount = async () => {
        //await this.loadUsers();
    }

    loadUsers = async () => {
        const response = axiosInstance.get('User');
        if(response.status === 200){
            this.setState({ users: response.data });
        }
    }

    validate = (player) => {
        if(!player.name) return { ok: false, errorMessage: 'Please, let us know name of the lady.' };
        return { ok: true }
    }

    getPlayer = () => ({
        name: this.state.nick,
        userId: this.state.userId
    })

    submitHandler = async (event) => {
        event.preventDefault();

        const player = this.getPlayer();
        const validationResult = this.validate(player);
        if (!validationResult.ok) {
            this.setState({message: validationResult.errorMessage});
            return;
        }

        var response = await axiosInstance.post('Player', player, {headers: { 'Content-Type': 'application/json' }});
        if(response.status === 201){
            this.props.history.push('/');
            return;
        }

        this.setState({ error: response.error });
    }

    changeNameHandler = (event) => {
        this.setState({ nick: event.target.value });
    }

    handleUserChange = (userOption) => {
        this.setState({ userId: userOption.id});
    }

    render() {
        // const users = this.state.users;
        // const userOptions = users ? users.map(player => ({ value: player.id, label: player.name })) : [];

        return (
            <form onSubmit={this.submitHandler}>
                <h1>Add new player</h1>
                <div>
                <input
                    className="form-input"
                    type='text'
                    name='playerName'
                    placeholder='Name'
                    onChange={this.changeNameHandler}
                    />
                </div>
                {/* <Select 
                    className="form-input"
                    options={userOptions}
                    onChange={this.handleUserChange}
                    placeholder='Link to user..'
                     /> */}
                <input className="btn btn-primary" type='submit' value='Add' />
            </form>
        );
    }
}