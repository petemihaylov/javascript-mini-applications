import React, {useEffect, useState} from "react";
import Navbar from "react-bootstrap/Navbar";
import { logout } from "../../../actions/auth";
import { connect } from "react-redux";

const Nav = (props) => {
 
 
  const onLogOut = () => {
    const { dispatch, history } = props;

    dispatch(logout());
    window.location.reload();
  };

  return (
    <Navbar bg="light" variant="light" className="justify-content-between">
      <Navbar.Brand href="/admin" className="ml-lg-5">Administration page</Navbar.Brand>
      <button className="btn btn-outline-dark mr-lg-5" onClick={onLogOut}>
      <i className="fas fa-sign-out-alt"></i> Sign out
      </button>
    </Navbar>
  );
};

export default connect(null)(Nav);
