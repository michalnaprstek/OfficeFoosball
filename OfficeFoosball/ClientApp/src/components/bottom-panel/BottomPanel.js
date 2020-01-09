import React from 'react'
import './BottomPanel.scss'
import AccessCode from '../access-code/AccessCode'

const BottomPanel = (props) => {
    return <div className="bottom-panel">
        <AccessCode accessCode={props.accessCode}/>
    </div>
};

export default BottomPanel