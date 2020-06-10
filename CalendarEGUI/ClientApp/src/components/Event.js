import React, { Component } from 'react';
import { Link } from 'react-router-dom'

export class Event extends Component {
    constructor(props) {
        super(props);
        this.state = {
            day: props.location.day,
            date: props.location.state
        }
    }
    render() {
        return(
            <div>
        <div class="month">
            <ul>
                <li class="prev">
                        &#10094;
                </li>
                <li class="next">
                        &#10095;
                </li>
                <li>11<br/><span>2020</span></li>
                    </ul>
        </div>

            <ul class="desc">
                <li>Time</li>
                    <li style={{ width: 200 }}>Description</li>
                <li></li>
            </ul>

            <form action="saveEvent" method = "post" >

                    <ul class="event">
                        <input type="time" name="time1" value="12:30" style={{fontSize:10, width:120}}/>
                            <textarea name="description">Type your description here</textarea>
                </ul>

                    <div class="asd">
                        <a class="btn btn-outline-info" >save</a>
                            <Link to={{ pathname: "/" }}>
                                    <a class="btn btn-outline-info">
                                    cancel
                                     </a>
                </Link>
                </div>
            </form>
        </div>)
    }
}