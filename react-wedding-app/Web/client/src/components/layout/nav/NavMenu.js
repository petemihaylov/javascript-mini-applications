import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import LocaleSwitcher from "../header/LocaleSwitcher";

const NavMenu = () => {
  return (
    <Navbar fixed="top" variant="light">
      <Navbar.Brand href="#"></Navbar.Brand>
      <Navbar.Toggle />
      <Navbar.Collapse className="justify-content-end">
        <LocaleSwitcher />
      </Navbar.Collapse>
    </Navbar>
  );
};
export default NavMenu;
