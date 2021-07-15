import React from "react";
import styled from "styled-components";
import flower from "../../../assets/img/flower.png";
import { Row, Col } from "../../../assets/scripts/gridrules";
import { Image } from "react-bootstrap";
import EventCard from "./EventCard";
import EventTitle from "./EventTitle";

import ceremony from "../../../assets/img/ceremony.png";
import party from "../../../assets/img/party.png";
import reception from "../../../assets/img/reception.png";
import basilik from "../../../assets/img/basilika-sofia.jpg";
import golf from "../../../assets/img/golf_club.jpg";
import dinner from "../../../assets/img/dinner.jpeg";

const StyledBase = styled.div`
  margin-top: 8vh;
  font-family: "Alice", serif;
  width: 100%;
  display: flex;
  flex-direction: column;
  padding: 8vh;
  align-items: center;
`;

const EventsContainer = styled(StyledBase)`
  background-color: #f8f1ec;
  min-height: 60vh;
`;

const EventDashboard = () => {
  return (
    <EventsContainer>
      <Image src={flower} width={"40px"} />
      <EventTitle value={"When & Where"} />

      <Row collapse="xs">
        <Col>
          <EventCard
            icon={ceremony}
            background={"white"}
            img={basilik}
            textColor={"black"}
            title={"events.ceremony.title"}
            date={"events.ceremony.date"}
            location={"events.ceremony.location"}
            link={"https://www.google.com/maps/dir//St.+Sophia+Church,+ul.+%22Paris%22+2,+1000+Sofia+Center,+Sofia,+Bulgaria/@42.6965258,23.3290841,17z/data=!4m16!1m6!3m5!1s0x40aa8570fd90e65b:0xf438944892749af8!2sSt.+Sophia+Church!8m2!3d42.6965219!4d23.3312728!4m8!1m0!1m5!1m1!1s0x40aa8570fd90e65b:0xf438944892749af8!2m2!1d23.3312728!2d42.6965219!3e1"}
          />
        </Col>
        <Col>
          <EventCard
            background={"white"}
            textColor={"black"}
            icon={reception}
            img={golf}
            title={"events.party.title"}
            date={"events.party.date"}
            location={"events.party.location"}
          />
        </Col>
        <Col>
          <EventCard
            background={"white"}
            textColor={"black"}
            icon={party}
            img={dinner}
            title={"events.dinner.title"}
            date={"events.dinner.date"}
            location={"events.dinner.location"}
          />
        </Col>
      </Row>
    </EventsContainer>
  );
};

export default EventDashboard;
