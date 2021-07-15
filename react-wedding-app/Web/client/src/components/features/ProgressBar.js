import React, { useEffect } from "react";
import useStorage from "../../hooks/useStorage";
import styled from "styled-components";
import { Container } from "react-bootstrap";

const ProgressBar = ({ file, setFile, setUrl }) => {
  const { url, progress } = useStorage({ file });

  useEffect(() => {
    if (url) {
      setUrl(url);
      setFile(null);
    }
  }, [url, setFile]);

  return (
    <Container>
      <StyledProgressBar
        className="progress-bar"
        style={{ width: progress + "%" }}
      ></StyledProgressBar>
    </Container>
  );
};

export default ProgressBar;

const StyledProgressBar = styled.div`
  height: 4px;
  background: #ca815afd;
  margin-top: 20px;
`;
