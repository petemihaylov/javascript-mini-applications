import React from "react";
import styled from "styled-components";
import { useForm } from "react-hook-form";
import breakpoint from "../../../assets/scripts/breakpoints";
import { Form, Row, Col } from "react-bootstrap";
import ParticipantService from "../../../services/participants.service";
import Participant from "../../../entities/Participant";
import Translate from "react-translate-component";

const MailForm = () => {
  const {
    register,
    handleSubmit,
    reset,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    let participant = new Participant(
      data.email,
      data.firstName,
      data.lastName
    );
    ParticipantService.addParticipant(participant);
    // alert(JSON.stringify(participant));
    reset();
  };

  return (
    <StyledContainer>
      <StyledFormContainer>
        <Row>
          <StyledTitle>
            <Translate content="mail.title" component="span" />
          </StyledTitle>
        </Row>
        <Form onSubmit={handleSubmit(onSubmit)}>
          <Row>
            <Col>
              <Form.Group>
                <Form.Control
                  placeholder="First Name"
                  type="text"
                  id="firstName"
                  name="firstName"
                  defaultValue=" "
                  ref={register({
                    required: "* Enter your your first name",
                  })}
                />
                <Form.Text className="text-muted">
                  {errors.firstName && (
                    <p className="error">{errors.firstName.message}</p>
                  )}
                </Form.Text>
              </Form.Group>
            </Col>
            <Col>
              <Form.Group>
                <Form.Control
                  placeholder="Last Name"
                  type="text"
                  id="lastName"
                  name="lastName"
                  defaultValue=" "
                  ref={register({
                    required: "* Please enter your last name",
                  })}
                />
                <Form.Text className="text-muted">
                  {errors.lastName && (
                    <p className="error">{errors.lastName.message}</p>
                  )}
                </Form.Text>
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group>
                <Form.Control
                  placeholder="E-mail"
                  type="email"
                  id="email"
                  name="email"
                  defaultValue=" "
                  ref={register({
                    required: "* Please enter your e-mail",
                    pattern: {
                      value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i,
                      message: "* Enter a valid e-mail address",
                    },
                  })}
                />
                <Form.Text className="text-muted">
                  {errors.email && (
                    <p className="error">{errors.email.message}</p>
                  )}
                </Form.Text>
              </Form.Group>
            </Col>
          </Row>
          <Row>
            <Col>
              <Form.Group>
                <StyledButton type="submit">
                  <i class="fas fa-envelope"></i>
                </StyledButton>
              </Form.Group>
            </Col>
          </Row>
        </Form>
      </StyledFormContainer>
    </StyledContainer>
  );
};

export default MailForm;

const StyledTitle = styled.h1`
  font-size: 45px;
  margin-top: 25px;
  margin-bottom 3vh;
  color: #333333;
  font-family: "Marck Script", cursive;
  @media only screen and ${breakpoint.device.sm} {
    
    font-size: 30px;
    font-weight: 100;
  }
`;

const StyledContainer = styled.div`
  background-color: #f8f1ec;
  height: 300px;
  width: 100%;
  margin-bottom: 4vh;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const StyledFormContainer = styled.div`
  position: relative;
  top: 110px;
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
  width: 40vw;
  background: white;
  text-align: center;
  height: 500px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  @media only screen and ${breakpoint.device.sm} {
    width: 95vw;
    padding-left: 4vw;
    padding-right: 4vw;
    height: 280px;
    border: solid 1px #f4f4f4;
    box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
  }
`;

const StyledButton = styled.button`
  width: 50%;
  height: 40px;
  font-size: 22px;
  color: #595959;
  margin: 30px 0px 0px 0px;
  background-color: rgba(236, 236, 236, 0);
  border: 1px solid rgba(236, 236, 236, 0.9);
  border-radius: 4px;
  cursor: pointer;
  border-radius: 1px;
  letter-spacing: 3px;
  font-weight: 400;
  text-transform: uppercase;
  transition: ease-in-out 0.2s;

  &:hover {
    transition: ease-in-out 0.2s;
    border-radius: 3px;
    color: #60cf89;
    border: 1px dashed #60cf89;
  }
  @media only screen and ${breakpoint.device.sm} {
    margin: 5px 0px 0px 0px;
    height: 35px;
  }
`;
