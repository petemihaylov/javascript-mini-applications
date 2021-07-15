import React from "react";
import Story from "./Story";
import Quote from "./Quote";
import Gallery from "./Gallery";
import EventDashboard from "./EventDashboard";
import MailForm from "./MailForm";
import Map from "./Map";

const Main = () => {
  return (
    <div>
      <Story />
      <MailForm />
      {/* <Quote/> */}
      <Gallery />
      <EventDashboard />
      {/*<Map/>*/}
    </div>
  );
};

export default Main;
