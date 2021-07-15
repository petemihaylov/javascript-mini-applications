import React from "react";
import styled from "styled-components";
import flower from "../../../assets/img/flower.png";
import { Image } from "react-bootstrap";
import breakpoint from "../../../assets/scripts/breakpoints";
import Translate from "react-translate-component";

const EventCard = ({
  background,
  textColor,
  icon,
  img,
  title,
  date,
  location,
  link,
}) => {
  const StyledContainer = styled.a`
    width: 30vw;
    margin: 10px;
    height: 330px;
    box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
    border-top: transparent;
    background: ${background};
    border-radius: 2px;
    display: flex;
    flex-direction: column;
    align-items: center;
    color: ${textColor};
    transition-duration: 0.6s;
    @media only screen and ${breakpoint.device.sm} {
      width: 96vw;
      border: 1px solid transparent;
    }
    &:hover {
      text-decoration: none;
      color: ${textColor};
      -ms-transform: scale(1.05); /* IE 9 */
      -webkit-transform: scale(1.05); /* Safari 3-8 */
      transform: scale(1.05);
      transition-duration: 1s;  
    }
  `;

  const StyledTitle = styled.h1`
    font-size: 24px;
    letter-spacing: 2px;
    margin-bottom: 10px;
    margin-top: 10px;
  `;
  const StyledDescription = styled.div`
    font-size: 14px;
    color: ${textColor};
    opacity: 0.8;
    font-family: "Mulish", sans-serif;
    text-align: center;
    letter-spacing: 2px;
    width: 20vw;
    text-justify: inter-word;
    @media only screen and ${breakpoint.device.sm} {
      width: 70vw;
    }
  `;

  const StyledImage = styled.img`
    width: 30vw;
    height: 100%;
    object-fit: cover;
    @media only screen and ${breakpoint.device.sm} {
      width: 96vw;
    }
  `;
  const StyledImgContainer = styled.div`
    width: 30vw;
    height: 145px;
    @media only screen and ${breakpoint.device.sm} {
      width: 96vw;
    }
  `;

  const StyledIcon = styled.img`
    width: 65px;
    margin-top: -28px;
    border-radius: 50%;
  `;

  return (
    <StyledContainer href={link} target="_blank">
      <StyledImgContainer>
        <StyledImage src={img} />
      </StyledImgContainer>
      <StyledIcon src={icon} width={"60px"} />
      <StyledTitle>
        <Translate content={title} component="span" />
      </StyledTitle>
      <StyledDescription>
        <Translate content={date} component="span" /> <br />{" "}
        <Translate content={location} component="span" />
      </StyledDescription>
    </StyledContainer>
  );
};

EventCard.defaultProps = {
  background: "#c78664",
  textColor: "white",
  img: flower,
  link: "http://google.com/",
  icon: flower,
  title: "",
  date: "",
  location: "",
};

export default EventCard;
