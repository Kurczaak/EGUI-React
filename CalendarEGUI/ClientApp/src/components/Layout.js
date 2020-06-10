import React, { Component } from 'react';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div className="container">
                <main role="main" className="pb-3">
                    <div className="container-fluid mt-5">
                        <div className="row">
                            <div className="col-0 col-md-1 col-lg-2 col-xl-3"></div>
                            <div className="col-12 col-md-10 col-lg-8 col-xl-6 calendar-content">
                                {this.props.children}
                            </div>
                            <div className="col-0 col-md-1 col-lg-2 col-xl-3"></div>
                        </div>
                    </div>
                </main>
            </div>
        );
    }
}