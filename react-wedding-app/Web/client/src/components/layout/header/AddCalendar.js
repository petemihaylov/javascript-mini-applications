import AddToCalendarHOC from "react-add-to-calendar-hoc";
import moment from "moment";
import React from "react";
import counterpart from "counterpart";
import Translate from "react-translate-component";
import EN from "../../../assets/lang/en";
import BG from "../../../assets/lang/bg";
import Dropdown from './Dropdown';
import Button from './Button';
import Modal from './Modal';

counterpart.registerTranslations("EN", EN);
counterpart.registerTranslations("BG", BG);
counterpart.setLocale("EN");

const AddCalendar = () => {
  const AddToCalendarDropdown = AddToCalendarHOC(Button, Modal);

  return (
    <AddToCalendarDropdown
      event={event}
      buttonText={<Translate content="header.btn" component="span" />}
      items={['Google','Yahoo']}
    />
  );
};

export default AddCalendar;


const startDatetime = moment("2021-06-05" + " " + "16:00");
const endDatetime = moment("2021-06-05" + " " + "23:59");
const duration = moment.duration(endDatetime.diff(startDatetime)).asHours();

const event = {
  description:
    "St. Sophia Church (Храм „Света София“) - 16:00h \nSt. Sofia Golf & Spa (Св. София голф клуб и спа)  - 17:30 \nDinner Sofia Golf Club (вечеря)- 19:00 ",
  duration,
  endDatetime: endDatetime.format("YYYYMMDDTHHmmssZ"),
  location: "ul. Paris 2, 1000 Sofia Center, Sofia, Bulgaria",
  startDatetime: startDatetime.format("YYYYMMDDTHHmmssZ"),
  title: "Wedding 5th of June",
};
