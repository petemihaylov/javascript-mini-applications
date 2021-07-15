import * as React from "react";
import { useState } from "react";
import { Container } from "react-bootstrap";
import ReactMapGL from "react-map-gl";
import styled from "styled-components";

const Map = () => {
  const [viewport, setViewport] = useState({
    width: "100%",
    height: 400,
    latitude: 42.6977,
    longitude: 23.3219,
    zoom: 12,
  });

  return (
    <StyledContainer>
      <ReactMapGL
        {...viewport}
        onViewportChange={(nextViewport) => setViewport(nextViewport)}
        mapStyle="mapbox://styles/mapbox/light-v10"
        mapboxApiAccessToken={
          "pk.eyJ1IjoicGVwc20iLCJhIjoiY2tobDQxZ2VxMGN2aDJzbG5raXJoN2VqcSJ9.ttIT-eWF2PYMSdxfZxk3Xw"
        }
      />
    </StyledContainer>
  );
};


export default Map;

const StyledContainer = styled.div`
  background-color: #f8f1ec;
  padding-top: 10vh;
  padding-bottom: 4vh;
`;