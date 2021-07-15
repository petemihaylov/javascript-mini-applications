import React, { useState, useEffect } from "react";
import ProgressBar from "./ProgressBar";
import styled from "styled-components";
import { connect } from "react-redux";
import { createImage } from "../../actions/imageActions";

const UploadForm = (props) => {
  const [file, setFile] = useState(null);
  const [error, setError] = useState(null);
  const [url, setUrl] = useState(null);

  const types = ["image/png", "image/jpeg", "image/jpg"];

  const handleChange = (e) => {
    let selected = e.target.files[0];

    if (selected && types.includes(selected.type)) {
      setFile(selected);
      setError("");
    } else {
      setFile(null);
      setError("Please select an image file (png or jpg)");
    }
  };

  useEffect(() => {
    console.log(url)
       if(url!=null){
        props.dispatch(createImage(url))  
      }
  },[url])

  return (
    <StyledForm>
      <StyledLabel>
        <StyledInput type="file" onChange={handleChange} />
        <span>+</span>
      </StyledLabel>
      <div className="output">
        {error && <div className="error">{error}</div>}
        {file && <div>{file.name}</div>}
        {file && <ProgressBar file={file} setFile={setFile} setUrl={setUrl} />}
      </div>
    </StyledForm>
  );
};


export default connect()(UploadForm);

const StyledLabel = styled.label`
  display: block;
  width: 40px;
  height: 40px;
  border: 1px solid #ca815afd;
  border-radius: 50%;
  margin: 10px auto;
  line-height: 30px;
  color: #ca815afd;
  font-weight: bold;
  cursor: pointer;
  font-size: 24px;
  &:hover {
    background: #ca815afd;
    color: white;
  }
`;

const StyledInput = styled.input`
  height: 0;
  width: 0;
  opacity: 0;
`;

const StyledForm = styled.form`
  margin: 30px auto 10px;
  text-align: center;
  margin-top: 10vh;
`;
