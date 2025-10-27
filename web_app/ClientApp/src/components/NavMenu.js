import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Nav,
  NavItem,
  NavLink,
} from "reactstrap";

function NavMenu() {
  const [collapsed, setCollapsed] = useState(true);

  const toggleNavbar = () => setCollapsed(!collapsed);

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <NavbarBrand className="text-dark" href="/">
          OpenPlaybook
        </NavbarBrand>
        <NavbarToggler onClick={toggleNavbar} className="mr-2" />
        <Collapse
          className="d-sm-inline-flex flex-sm-row-reverse"
          isOpen={!collapsed}
          navbar
        >
          <Nav className="flex-grow" navbar>
            <NavItem>
              <NavLink className="text-dark" href="/">
                Home
              </NavLink>
            </NavItem>

            {/* quick test ui for the keyword api */}
            <NavItem>
              <NavLink className="text-dark" href="/keywords">
                Keyword Tool
              </NavLink>
            </NavItem>
          </Nav>
        </Collapse>
      </Navbar>
    </header>
  );
}

export default NavMenu;
