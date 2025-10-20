import React from 'react';
import { Nav, NavItem, NavLink } from 'reactstrap';

export function Footer() {
  return (
    <footer className="footer border-top text-muted bg-light footer-fixed">
      <div className="container">
        <Nav className="w-100">
          <NavItem>
            <span className="navbar-text">
              &copy; 2025 OpenPlaybook
            </span>
          </NavItem>
          <NavItem className="ms-auto">
            <NavLink href="#">Back to Top</NavLink>
          </NavItem>
        </Nav>
      </div>
    </footer>
  );
}