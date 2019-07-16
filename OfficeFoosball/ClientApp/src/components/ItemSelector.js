import React, { Component } from 'react'

export default class ItemSelector extends Component{

    change = (event) => {
        const selectedItemId = parseInt(event.target.value, 10);
        const items = this.props.items;
        const selectedItem = items.find(x => x.id === selectedItemId);

        if(this.props.onChange) 
            this.props.onChange(selectedItem);
    }

    render () {
        const items = this.props.items;
        const name = this.props.name;
        const selectedItem = this.props.selectedItem;
        const selectedItemId = selectedItem ? selectedItem.id : 0;

        return (
            <div>
                <label htmlFor={name}>{this.props.label}</label>
                <select name={name} tabIndex="1" onChange={this.change} value={selectedItemId}>
                    <option/>
                    {items ? items.map((item, key) => 
                        <option key={key} value={item.id}>{item.name}</option>
                    ) : ''}
                </select>
        </div>  
        );
    }

}
