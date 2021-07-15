import React from "react";
import styled from "styled-components";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import breakpoint from "../../../assets/scripts/breakpoints";
import Translate from "react-translate-component";


const Quote = () => {
  return (
    <StyledContainer>
      <StyledTopIcon>
        <FontAwesomeIcon icon={["fa", "quote-left"]} />
      </StyledTopIcon>
      <StyledQuoteContainer>
        <QuoteTitle><Translate content="quote.title" component="span" /></QuoteTitle>
        <QuoteAuthor><Translate content="quote.author" component="span" /></QuoteAuthor>
      </StyledQuoteContainer>
      <StyledBottomIcon>
        <FontAwesomeIcon icon={["fa", "quote-left"]} />
      </StyledBottomIcon>
    </StyledContainer>
  );
};

export default Quote;


const StyledContainer = styled.div`
  background-color: #f8f1ec;
  height: 260px;
  width: 100%;
  margin-bottom: 4vh;
  display: flex;
  flex-direction: column;
  align-items: center;
`;
const StyledQuoteContainer = styled.div`
  position: relative;
  top: 110px;
  border: solid 1px #c78664;
  width: 58vw;
  height: 490px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  @media only screen and ${breakpoint.device.sm} {
    width: 80vw;
    height: 200px;
  }
`;

const QuoteTitle = styled.h1`
  font-family: "Alice", serif;
  font-size: 30px;
  width: 40vw;
  text-justify: inter-word;
  text-align: center;
  letter-spacing: 2px;
  color: rgba(0,0,0, 0.8);
  @media only screen and ${breakpoint.device.sm} {
    width: 70vw;
    margin-top: 20px;
    font-size: 20px
  }
`;
const QuoteAuthor = styled.h4`
    color: rgba(0,0,0, 0.4);
    margin-top: 30px;
    font-size: 18px;
    @media only screen and ${breakpoint.device.sm} {
      margin-top: 20px;
      margin-bottom: 20px;
    }
`;
const StyledTopIcon = styled.div`
  width: 60px;
  height: 3px;
  background-color: #f8f1ec;
  position: relative;
  display: flex;
  color: #c78664;
  justify-content: center;
  align-items: center;
  top: 111px;
  font-size: 30px;
  z-index: 1;
`;

const StyledBottomIcon = styled.div`
  width: 60px;
  height: 3px;
  transform: rotate(180deg);
  background-color: #fff;
  position: relative;
  display: flex;
  color: #c78664;
  justify-content: center;
  align-items: center;
  top: 109px;
  font-size: 28px;
  z-index: 1;
  @media only screen and ${breakpoint.device.sm} {
    top: 88px;
    font-size: 25px
  }
`;