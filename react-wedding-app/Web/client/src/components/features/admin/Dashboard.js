import React from "react";
import { Container } from "react-bootstrap";
import { connect } from "react-redux";
import UploadForm from "../UploadForm";
import Gallery from "../Gallery";
import Nav  from "./Nav";
import ParticipantsList from "../ParticipantsList";

const Dashboard = (props) => {
  

  return (
    <div>
      <Nav/>
      <Container fluid>
        <UploadForm />
        <Container><h3>Gallery</h3></Container>
        <Gallery />
        <Container className="mb-3 mt-5"><h3>Participants</h3></Container>
        <ParticipantsList/>
      </Container>
    </div>
  );
};

export default connect(null)(Dashboard);
