import React, { Component } from 'react'
import './AccessCode.scss'
import { FaClipboardCheck } from "react-icons/fa";

export default class AccessCode extends Component {

    constructor (props){
        super(props);
        this.state = { copied: false }
    }

    copyToClipboard = () =>{
        navigator.clipboard.writeText(this.props.accessCode);
        this.setState({ copied: true });
        setTimeout(() => this.setState({ copied: false }), 1000);
    }

    render = () => {
        const accessCode = this.props.accessCode;
        if(!accessCode) return '';

        return (
            <div  className="access-code">
                <span>Access code: </span><span className="access-code__code">{this.props.accessCode}</span>
                <button className="access-code__copy-button" onClick={this.copyToClipboard} title="Copy to clipboard" >
                    Copy
                </button>
                {this.state.copied && <span className="access-code__copy-icon"><FaClipboardCheck /></span> }
            </div>
        );
    }
}
