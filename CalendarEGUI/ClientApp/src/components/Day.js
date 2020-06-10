import React, { Component } from 'react';
import { Link } from 'react-router-dom'

export class Day extends Component {
    constructor(props) {
        super(props);
        this.state = {
            day: props.location.day,
            date: props.location.state
        }
    }


    render() {

        return (
            <div>
                <div className="month">
                    <ul>
                        <li>{this.state.day}<br /><span>{this.state.date.today.toLocaleString('default', { month: 'long' })}</span></li>
                    </ul>
                </div>

                <ul className="weekdays">
                    <li>Time</li>
                    <li style={{ marginLeft: 150 }}>Description</li>
                    <li></li>
                </ul>





                <Link to={{ pathname: "event" }}>
                <a className="btn btn-outline-info" style={{ margin: 0}}>
                    add new
                </a>
                </Link>
                <Link to={{pathname: "/"}}>
                <a className="btn btn-outline-info" style={{ margin: 0 }}>
                        close
                </a>
                </Link>
            </div>
        );
    }
}
