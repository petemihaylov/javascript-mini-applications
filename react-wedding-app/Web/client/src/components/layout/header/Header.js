import React from "react";
import styled from "styled-components";
import img from "../../../assets/img/background.jpeg";
import breakpoint from "../../../assets/scripts/breakpoints";
import { Container, Row, Col } from "react-bootstrap";
import OutlineButton from "../../shared/OutlineButton";
import Overlay from "../../shared/Overlay";
import counterpart from "counterpart";
import Translate from "react-translate-component";
import EN from "../../../assets/lang/en";
import BG from "../../../assets/lang/bg";
import AddCalendar from "./AddCalendar";

counterpart.registerTranslations("EN", EN);
counterpart.registerTranslations("BG", BG);
counterpart.setLocale("BG");

const Header = ({ title, subtitle, date }) => {
  return (
    <StyledHeader>
      <Overlay />
      <Container className="d-flex align-items-center justify-content-center text-center">
        <Row xs={1}>
          <Col>
            <StyledSubtitle>
              <Translate content="header.subtitle" component="span" />
            </StyledSubtitle>
            <StyledTitle>
              <Translate content="header.title" component="span" />
            </StyledTitle>
            <Row>
              <Col>
                <StyledLine className="divider my-4" />
              </Col>
              <Col>
                <StyledSave>
                  <Translate content="header.saveDate" component="span" />
                </StyledSave>
              </Col>
              <Col>
                <StyledLine className="divider my-4" />
              </Col>
            </Row>
          </Col>
          <Col className="w-100">
            <StyledDate>
              <Translate content="header.date" component="span" />
            </StyledDate>

           <AddCalendar/>
          </Col>
        </Row>
      </Container>
    </StyledHeader>
  );
};

Header.defaultProps = {
  title: "Title",
  subtitle: "Subtitle",
  date: "Date",
};

const StyledHeader = styled.header`
  height: 100vh;
  width: 100%;
  left: 0;
  display: flex;
  justify-content: center;
  font-family: "Alice", serif;
  letter-spacing: 2px;
  color: white;

  &::before {
    content: "";
    position: absolute;
    top: 0;
    bottom: 0;
    right: 0;
    opacity: 1;
    left: 0;
    background: url(${img}) no-repeat center center fixed;
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: cover;
  }
`;

const StyledSubtitle = styled.small`
  text-transform: uppercase;
  opacity: 0.8;
  font-family: "Alice", serif;
  font-size: 1.2rem;
`;

const StyledTitle = styled.h1`
  font-size: 100px;

  font-family: 'Marck Script', cursive;
  @media only screen and ${breakpoint.device.sm} {
    font-size: 40px;
    font-weight: 900;
  }
`;

const StyledLine = styled.hr`
  background: white;
  opacity: 0.8;
`;

const StyledSave = styled.div`
  opacity: 0.8;
  margin-top: 15px;
  text-transform: uppercase;
  font-weight: 300;
  font-family: "Alice", serif;
  @media only screen and ${breakpoint.device.sm} {
    margin-top: 18px;
    font-size: 14px;
    display: none;
  }
`;

const StyledDate = styled.h1`
  margin-top: 50px;
  font-size: 40px;

  font-family: 'Marck Script', cursive;
  @media only screen and ${breakpoint.device.sm} {
    font-size: 30px;
  }
`;

export default Header;
