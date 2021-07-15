import React from "react";
import Main from "./layout/content/Main";
import Footer from "./layout/footer/Footer";
import Header from "./layout/header/Header";
import NavMenu from "./layout/nav/NavMenu";


const Root = () => {
  return (
    <React.Fragment>
      <NavMenu />
      
      <Header/>
      <Main />
      <Footer />
    </React.Fragment>
  );
};

export default Root;
