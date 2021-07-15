import React from "react";
import authService from "../../services/auth.service";
import { connect } from "react-redux";
import { useForm } from "react-hook-form";
import { login } from "../../actions/auth";
import { Redirect } from "react-router";
import styled from "styled-components";
import { BubbleButton } from "../shared/BubbleButton";

const StyledContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100vw;
  height: 100vh;
`;
const StyledForm = styled.form`
  mid-width: 340px;
  padding: 20px;
  padding-top: 60px;
  border: 1px solid rgba(0, 0, 0, 0.3);
  box-shadow: rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
    rgba(60, 64, 67, 0.15) 0px 2px 6px 2px;
  border-radius: 1px;
  text-align: center;
  letter-spacing: 2px;
  height: 350px;
`;
const StyledInput = styled.input`
  height: 24px;
  font-size: 13px;
  letter-spacing: 1px;
  text-decoration: none;
  cursor: pointer;
  border: none;
  width: 240px;
  border-bottom: 1px solid gray;
  border-radius: 0px;
  outline: none;
  &:focus,
  &:active {
    border-color: transparent;
    border-bottom: 1px solid black;
  }
`;
const StyledGroup = styled.div`
  margin-bottom: 5px;
`;
const StyledError = styled.div`
  min-height: 25px;
  font-size: 13px;
  letter-spacing: 0px;
  width: 240px;
  text-align: left;
  color: red;
`;
const StyledWrapper = styled.div`
  height: 70%;
  display: flex;
  flex-direction: column;
  justify-content: center;
`;

const StyledAlert = styled.div`
  position: absolute;
  top: 5vh;
`;

const Login = (props) => {
  const { isLoggedIn, message } = props;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    const { dispatch, history } = props;

    console.log(data);

    dispatch(login(data.username, data.password))
      .then(() => {
        history.push("/admin/dashboard");
        window.location.reload();
      })
      .catch(() => {});
  };

  if (isLoggedIn) return <Redirect to="/admin/dashboard" />;

  return (
    <StyledContainer>
      <StyledForm onSubmit={handleSubmit(onSubmit)}>
        <StyledWrapper>
          <StyledGroup>
            <StyledInput
              ref={register({
                required: true,
              })}
              type="text"
              placeholder="Username"
              className=""
              name="username"
            />
            <StyledError>
              {" "}
              {errors.username && (
                <small className="text-danger"> * The field is required </small>
              )}{" "}
            </StyledError>{" "}
          </StyledGroup>
          <StyledGroup>
            <StyledInput
              ref={register({
                required: true,
              })}
              type="password"
              placeholder="Password"
              className=""
              name="password"
            />
            <StyledError>
              {" "}
              {errors.password && (
                <small className="text-danger"> * The field is required </small>
              )}{" "}
            </StyledError>{" "}
          </StyledGroup>
          <BubbleButton
            style={{
              marginTop: "50px",
            }}
          />{" "}
        </StyledWrapper>{" "}
      </StyledForm>{" "}
      {message && (
        <StyledAlert className="alert alert-danger text-center" role="alert">
          {" "}
          {message}{" "}
        </StyledAlert>
      )}{" "}
    </StyledContainer>
  );
};

function mapStateToProps(state) {
  const { isLoggedIn } = state.auth;
  const { message } = state.message;
  return {
    isLoggedIn,
    message,
  };
}

export default connect(mapStateToProps)(Login);
