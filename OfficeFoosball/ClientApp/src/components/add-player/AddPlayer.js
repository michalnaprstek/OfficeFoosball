import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../utils/axiosInstance';

const AddPlayer = () => {
    const navigate = useNavigate();
    const [nick, setNick] = useState('');
    const [userId, setUserId] = useState(undefined);
    const [message, setMessage] = useState('');

    // const loadUsers = async () => {
    //     const response = axiosInstance.get('User');
    //     if (response.status === 200) {
    //         setUsers(response.data);
    //     }
    // }

    // useEffect(() => {
    //   loadUsers()
    // }, []);

    const validate = (player) => {
        if (!player.name) return { ok: false, errorMessage: 'Please, let us know name of the lady.' };
        return { ok: true }
    }

    const getPlayer = () => ({
        name: nick,
        userId: userId
    })

    const submitHandler = async (event) => {
        event.preventDefault();

        const player = getPlayer();
        const validationResult = validate(player);
        if (!validationResult.ok) {
            setMessage(validationResult.errorMessage);
            return;
        }

        var response = await axiosInstance.post('Player', player, { headers: { 'Content-Type': 'application/json' } });
        if (response.status === 201) {
            navigate('/');
            return;
        }

        setMessage(response.error);
    }

    const changeNameHandler = (event) => {
        setNick(event.target.value);
    }

    const handleUserChange = (userOption) => {
        setUserId(userOption.id);
    }

    // const users = users;
    // const userOptions = users ? users.map(player => ({ value: player.id, label: player.name })) : [];

    return (
        <form onSubmit={submitHandler}>
            <h1>Add new player</h1>
            <div>
                <input
                    className="form-input"
                    type='text'
                    name='playerName'
                    placeholder='Name'
                    onChange={changeNameHandler}
                />
            </div>
            {/* <Select 
                    className="form-input"
                    options={userOptions}
                    onChange={handleUserChange}
                    placeholder='Link to user..'
                     /> */}
            <input className="btn btn-primary" type='submit' value='Add' />
        </form>
    );
}

export default AddPlayer;