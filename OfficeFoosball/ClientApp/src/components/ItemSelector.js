import React, { Component } from 'react'

export default class ItemSelector extends Component{

    constructor (props){
        super(props);
        this.change = this.change.bind(this);
    }

    change (event) {
        const selectedItemId = parseInt(event.target.value, 10);
        const items = this.props.items;
        const selectedItem = items.find(x => x.id === selectedItemId);

        if(this.props.onChange) 
            this.props.onChange(selectedItem);
    }

    render () {
        const items = this.props.items;
        const identifier = this.getIdentifier();
        const selectedItem = this.props.selectedItem;
        const selectedItemId = selectedItem ? selectedItem.id : 0;

        return (
            <div>
                <label htmlFor={identifier}>{this.props.label}</label>
                <select name={identifier} tabIndex="1" onChange={this.change} value={selectedItemId}>
                    <option/>
                    {items ? items.map((item, key) => 
                        <option key={key} value={item.id}>{item.name}</option>
                    ) : ''}
                </select>
        </div>  
        );
    }

    getIdentifier() {
        const identifier = this.props.name;
        return identifier;
    }

}
