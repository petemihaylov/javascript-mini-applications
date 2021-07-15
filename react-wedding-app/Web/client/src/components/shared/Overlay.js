import React from "react";
import styled from "styled-components";

const Overlay = ({opacity}) => {

  const StyledOverlay = styled.div`
    position: absolute;
    height: 100%;
    width: 100%;
    background-color: black;
    opacity: ${opacity};
  `;


  return (
    <React.Fragment>
      <StyledOverlay />
    </React.Fragment>
  );
};

Overlay.defaultProps = {
    opacity: "0.3"
}

export default Overlay;
