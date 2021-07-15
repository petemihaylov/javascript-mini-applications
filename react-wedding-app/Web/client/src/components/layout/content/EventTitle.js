import React from "react";
import Translate from "react-translate-component";
import styled from "styled-components";
import breakpoint from "../../../assets/scripts/breakpoints";

const StyledTitle = styled.h1`
  font-size: 50px;
  width: 40vw;
  text-align: center;
  margin-top: 10px;
  margin-bottom: 30px;
  color: rgba(0, 0, 0, 0.7);
  @media only screen and ${breakpoint.device.sm} {
    font-size: 32px;
    width: 80vw;
  }
`;

const EventTitle = ({value}) => {
  return <StyledTitle><Translate content="events.title" component="span" /></StyledTitle>;

};

EventTitle.defaultProps = {
    value: "Title"
}

export default EventTitle;
