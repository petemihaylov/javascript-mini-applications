import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import breakpoint from "../../../assets/scripts/breakpoints";
import styled from "styled-components";

const SocialBar = ({ justifyContent }) => {
  const StyledItem = styled.a`
    width: 38px;
    height: 38px;
    font-size: 16px;
    border-radius: 50%;
    background-color: #f8f1ec;
    color: #c78664;
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 10px;
    margin-right: 18px;
    &:hover {
      color: #c78664;
    }
    @media only screen and ${breakpoint.device.sm} {
      width: 50px;
      height: 50px;
      font-size: 14px;
    }
  `;

  const StyledBar = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: ${justifyContent};
    width: 20vw;
    @media only screen and ${breakpoint.device.sm} {
      width: 80vw;
      justify-content: center;
      margin-top: 2vh;
    }
  `;

  return (
    <StyledBar>
      <StyledItem href="#">
        <i class="fab fa-facebook-f"></i>
      </StyledItem>
      <StyledItem href="#">
        <i class="fab fa-twitter"></i>
      </StyledItem>
      <StyledItem href="#">
        <i class="fab fa-instagram"></i>
      </StyledItem>
    </StyledBar>
  );
};

SocialBar.defaultProps = {
  justifyContent: "flex-start",
};

export default SocialBar;
