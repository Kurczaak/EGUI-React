import React, { Component } from 'react';
import  DayButton  from './DayButton';


export class Calendar extends Component {
    constructor(props) {
        super(props);

        this.state = props.location.state;
        if (this.state === undefined || this.state === null) {
            let date = new Date();
            this.state = {
                today: date,
                firstDay: new Date(date.getFullYear(), date.getMonth(), 1).getDay()
            }
        }
    }

    goNextMonth() {
        let date = this.state.today
        let nextMonth = new Date(date.getFullYear(), date.getMonth() + 1, 1)
        this.setState({ today: nextMonth, firstDay: new Date(nextMonth.getFullYear(), nextMonth.getMonth(), 1).getDay() })
    }

    goPrevMonth() {
        let date = this.state.today
        let prevMonth = new Date(date.getFullYear(), date.getMonth() - 1, 1)
        this.setState({ today: prevMonth, firstDay: new Date(prevMonth.getFullYear(), prevMonth.getMonth(), 1).getDay() })
    }

    createDays() {
        let element = [];
        console.log("dupa dupa", element.length)

        for (let i = 0; i < 6; ++i) {
            for (let j = 0; j < 7; ++j) {
                let firstDay = this.state.firstDay;
                let day = new Date(this.state.today.getFullYear(), this.state.today.getMonth(), i * 7 + j - firstDay + 2);
                let month = day.getMonth();
                let weekday = day.getDay();
                day = day.getDate();
                let click
                if (month === this.state.today.getMonth()) {
                    click = true;
                }
                else {click = false}
                element.push(<DayButton key={i * 10 + j} day={day} state={this.state} click={click} weekday={weekday} />)
            }
        }
        console.log("dupa dupa", element.length)
        return element;
    }

 

    render() {
        return (
            <div>
                <div className="month">
                    <ul>
                        <li className="prev">
                            <a className="btn" onClick={this.goPrevMonth.bind(this)}>&#10094;</a>
                        </li>
                        <li className="next">
                            <a className="btn" onClick={this.goNextMonth.bind(this)}>&#10095;</a>
                        </li>
                        <li>{this.state.today.toLocaleString('default', { month: 'long' })}<br /><span>{this.state.today.getFullYear()}</span></li>
                     </ul>
                </div>

                    <ul className="weekdays">
                        <li>Mo</li>
                        <li>Tu</li>
                        <li>We</li>
                        <li>Th</li>
                        <li>Fr</li>
                        <li>Sa</li>
                        <li>Su</li>
                    </ul>
                <ul className="days">
                        {this.createDays()}
                </ul>
            </div>
        );
    }
}
