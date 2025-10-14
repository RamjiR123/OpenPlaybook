import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Your Team's Digital Playbook</h1>
        <p className="lead">
          Welcome to <strong>OpenPlaybook</strong>, the central place to create, share, and execute your team's strategies.
          Whether for sports, business, or gaming, this is where your plans come to life.
        </p>
        <hr />
        <p>Click the button below to see all the current plays.</p>
        <Link className="btn btn-primary btn-lg" to="/playbook">Get Started</Link>
      </div>
    );
  }
}
