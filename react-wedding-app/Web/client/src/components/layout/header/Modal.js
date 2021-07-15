import React, { useState } from "react";
import Button from "./Button";
import { Modal } from "react-bootstrap";

export default function CalendarModal({ children, isOpen, onRequestClose }) {
  const [show, setShow] = useState(isOpen);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <Modal
      show={show}
      onHide={handleClose}
      size="sm"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton><i className="fas fa-calendar-alt"></i> {children}</Modal.Header>

    </Modal>
  );
}
