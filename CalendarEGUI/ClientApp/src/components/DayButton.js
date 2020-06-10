import React, { Component } from 'react';
import { Link } from 'react-router-dom'



function DayButton(props) {
    if (props.click) {
        if (props.weekday === 6 || props.weekday === 0) {
            return (
                <Link to={{ pathname: "day", day: props.day, state: props.state }}>
                    <li>
                        <div className="btn btn-outline-danger">
                            {props.day}
                        </div>
                    </li>
                </Link>
            )
        }


        return (
            <Link to={{ pathname: "day", day: props.day, state: props.state }}>
                <li>
                    <div className="btn btn-outline-primary">
                        {props.day}
                    </div>
                </li>
            </Link>
        )
    }
    else {
        return (
            <li>
                <div className="btn btn-outline-secondary">
                    {props.day}
                </div>
            </li>
        )
    }
}

export default DayButton