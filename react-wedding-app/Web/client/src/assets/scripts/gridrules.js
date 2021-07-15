import styled from "styled-components";

export const Grid = styled.div``;

export const Row = styled.div`
  display: flex;
  flex: ${(props) => props.size};
  ${(props) =>
    props.collapse &&
    media[props.collapse](`
        flex-direction: column;
        align-items: center;
    `)}
`;

const media = {
  xs: (style) => `
        @media only screen and (max-width: 800px){
            ${style}
        }
    `,
};

export const Col = styled.div`
  flex: ${(props) => props.size};
  ${(props) =>
    props.collapse &&
    media[props.collapse](`
        display: none;
    `)}
`;
