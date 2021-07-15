import React, { useEffect, useState } from "react";
import { Container, Table } from "react-bootstrap";
import { connect } from "react-redux";
import { fetchParticipants, getParticipants } from "../../actions/participantActions";

const ParticipantsList = (props) => {
  const [participants, setParticipants] = useState([]);

  /* Gets notifications from DB */
  useEffect(() => {
    props.dispatch(fetchParticipants());
  }, []);

  useEffect(() => {
    setParticipants(props.items);
  }, [props.items]);

  return (
    <Container>
    <Table striped bordered hover size="sm">
      <thead>
        <tr>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        {participants &&
          participants.map((p, index) => (
            <tr key={index}>
              <td>{p.firstName}</td>
              <td>{p.lastName}</td>
              <td>{p.email}</td>
            </tr>
          ))}
      </tbody>
    </Table>
    </Container>
  );
};

function mapStateToProps(state) {
  const { items } = state.participants;
  return {
    items,
  };
}
export default connect(mapStateToProps)(ParticipantsList);
