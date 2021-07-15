import React from "react";
import styled from "styled-components";

const StyledText = styled.span`
  color: rgba(25, 25, 25, 0.2);
`;
const StyledFooter = styled.footer`
  background-color: #f8f1ec;
`;
const Footer = () => {
  return (
    <StyledFooter className="py-5">
      <div className="container">
        <div className="small text-center text-muted">
          <StyledText>Copyright © 2021 Petar Mihaylov </StyledText>
        </div>
      </div>
    </StyledFooter>
  );
};

export default Footer;
