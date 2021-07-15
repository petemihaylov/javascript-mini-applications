import React from "react";
import { Col, Image, Row } from "react-bootstrap";
import styled from "styled-components";
import flower from "../../../assets/img/flower.png";
import couple from "../../../assets/img/about-couple.jpeg";
import SocialBar from "./SocialBar";
import breakpoint from "../../../assets/scripts/breakpoints";
import Translate from "react-translate-component";

const Story = () => {
  return (
    <StyledContainer>
      <StyledBase>
        <StyledIntro>
          <Image src={flower} width={"40px"} />
          <StyledTitle>
            {" "}
            <Translate content="story.title" component="span" />{" "}
          </StyledTitle>
          <StyledDescription>
            <Translate content="story.storyDesc" component="span" />
          </StyledDescription>
        </StyledIntro>
      </StyledBase>
      <Row
        className="mt-lg-5  p-lg-4 d-flex-column align-items-center w-100"
        lg="3"
        sm="1"
      >
        <StyledCol>
          <RightSubtitle>
            <Translate content="story.herName" component="span" />
          </RightSubtitle>
          <StyledDescription>
            <Translate content="story.herStory" component="span" />
          </StyledDescription>
          <SocialBar justifyContent={"flex-end"} />
        </StyledCol>
        <Col style={{ textAlign: "center" }}>
          <StyledImage src={couple} />
        </Col>
        <StyledCol>
          <StyledSubtitle>
            <Translate content="story.hisName" component="span" />
          </StyledSubtitle>
          <StyledDescription>
            <Translate content="story.hisStory" component="span" />
          </StyledDescription>
          <SocialBar />
        </StyledCol>
      </Row>
    </StyledContainer>
  );
};
export default Story;

const StyledIntro = styled.div`
  @media only screen and ${breakpoint.device.sm} {
    display: none;
  }
`;

const StyledBase = styled.div`
  margin-top: 8vh;
  font-family: "Marck Script", cursive;
  background: white;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
`;

const StyledContainer = styled(StyledBase)`
  min-height: 100vh;
`;

const StyledTitle = styled.h1`
  font-size: 50px;
  font-weight: 900;
  width: 20vw;
  text-align: center;
  margin-top: 5px;
  @media only screen and ${breakpoint.device.sm} {
    font-size: 32px;
    width: 40vw;
  }
`;

const StyledSubtitle = styled.h2`
  font-size: 40px;
  margin-top: 5px;
  width: 20vw;
`;
const RightSubtitle = styled(StyledSubtitle)`
  text-align: center;
  @media only screen and ${breakpoint.device.sm} {
    width: 80vw;
    text-align: center;
  }
`;
const StyledDescription = styled.div`
  font-size: 16px;
  font-family: "Mulish", sans-serif;
  text-align: center;
  color: gray;
  letter-spacing: 1px;
  width: 20vw;
  text-justify: inter-word;
  @media only screen and ${breakpoint.device.sm} {
    width: 80vw;
    text-align: justify;
  }
`;

const StyledCol = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  @media only screen and ${breakpoint.device.sm} {
    margin-top: 10vh;
    margin-bottom: 10vh;
    width: 100%;
  }
`;

const StyledImage = styled.img`
  width: 300px;
  border-radius: 80%;
  @media only screen and ${breakpoint.device.sm} {
    width: 200px;
  }
`;
