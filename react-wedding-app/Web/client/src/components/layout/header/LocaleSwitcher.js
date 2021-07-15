import counterpart from "counterpart";
import styled from "styled-components";
counterpart.setLocale("BG");

const LocaleSwitcher = () => {
 
    function handleChange(e) {
      counterpart.setLocale(e.target.value);
    }
  
    return (
      <p>
        <StyledSelect
          defaultValue={counterpart.getLocale()}
          onChange={handleChange}
        >
          <option>EN</option>
          <option>BG</option>
        </StyledSelect>
      </p>
    );
  };

  export default LocaleSwitcher;

const StyledSelect = styled.select`
  border-radius: 10px;
  decoration: none;
  border: none;
  padding: 2px 6px;
  font-size: 15px;
  color: #2f2f2fc5;
  outline: none;
  text-align:center;
  background-color: transparent;

  &:hover{
    color: black;
  }
`;
  