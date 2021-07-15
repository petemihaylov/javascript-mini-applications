import React from "react";
import styled from "styled-components";
import breakpoint from "../../assets/scripts/breakpoints";


const OutlineButton = ({
  value,
  width,
  height,
  fontSize,
  color,
  margin,
  background,
  backgroundHover,
  borderHover,
  border,
}) => {

  const StyledButton = styled.button`
    color: ${color};
    width: ${width};
    height: ${height};
    font-size: ${fontSize};
    margin: ${margin};
    background: ${background};
    border: ${border};
    cursor: pointer;
    border-radius: 1px;
    letter-spacing: 3px;
    font-weight: 400;
    text-transform: uppercase;
    transition: ease-in-out 0.2s;

    &:hover {
      border: ${borderHover};
      transition: ease-in-out 0.2s;
      background: ${backgroundHover};
    }

    @media only screen and ${breakpoint.device.sm} {
      width: 240px;
      font-size: 10px;
    }
  `;

  return (
    <React.Fragment>
      <StyledButton>{value} </StyledButton>
    </React.Fragment>
  );
};

OutlineButton.defaultProps = {
  value: "Submit",
  width: "300px",
  height: "40px",
  fontSize: "10px",
  color: "white",
  margin: "30px 0px 0px 0px",
  background: "rgba(255, 255, 255, 0.2)",
  border: "1px solid rgba(255, 255, 255, 0.8)",
  borderHover: "1px solid white",
  backgroundHover: "rgba(255, 255, 255, 0.3)"
};

export default OutlineButton;
