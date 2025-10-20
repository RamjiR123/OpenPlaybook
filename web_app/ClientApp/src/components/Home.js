import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Your Team's Digital Playbook</h1>
        <br></br>
        <h3>Beyond the Box Score</h3>

<p>Traditional sports statistics tell you <em>what</em> happened, but not <em>how</em>. OpenPlaybook is an innovative open-source tool that reveals the story behind the numbers. Using <strong>natural language processing</strong> and <strong>vector search</strong>, we transform raw play-by-play data into a powerful, searchable narrative.</p>

<p>Coaches, analysts, and fans can now go beyond the box score and find specific in-game moments with simple, intuitive queries like, <em>"Show me all basketball plays where the defense collapsed and led to a corner three."</em> By embedding each play into a vector space, our platform uncovers semantic similarities, clustering related plays to reveal deeper strategic insights that were previously hidden in the data.</p>

<h3>The Future of Sports Analytics</h3>

<p>Our goal is to deliver a full-stack web application with intuitive <strong>search, filtering, and visualization</strong> features, making advanced sports analytics accessible to everyone. Looking ahead, we plan to integrate <strong>computer vision</strong> to analyze video clips, allowing for a more complete and dynamic understanding of player performance. OpenPlaybook is reshaping how we understand and analyze the game.</p>
        <div className="text-center">
          <hr />
          <p>Click the button below to see all the current plays.</p>
          <Link className="btn btn-primary btn-lg" to="/playbook">Get Started</Link>
        </div>
      </div>
    );
  }
}
