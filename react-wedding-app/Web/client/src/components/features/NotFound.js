import React from 'react'
import { Container } from 'react-bootstrap';
import styled from "styled-components";

const StyledContainer = styled.div`
    width: 100%;
    height: 100vh;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    font-family: "Alice", serif;
    letter-spacing: 4px;
`;

const NotFound = () => {
    return (
        <StyledContainer>
            <h1>404 NOT FOUND</h1>
        </StyledContainer>
    )
}

export default NotFound
