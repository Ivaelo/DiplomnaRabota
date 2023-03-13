import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import React, {  useState } from "react"
import axios from 'axios';

function TestPopup(props) {
    const [title ,setTitle] = useState();
    const [file ,setFile] = useState();

    function FetchData(event){
        event.preventDefault();
        console.log(file);
        const formData = new FormData();
        formData.append('unitId',props.unitid);
        formData.append('name',title);
        axios.post('https://localhost:7021/api/Test/CreateTest',formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        })
        .then(res => console.log(res))
        .catch(err=> console.error(err));
    }
    return (
        <Modal
        {...props}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
        >
        <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">
            Modal heading
            </Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form encType='multipart/form-data' onSubmit={(e) => FetchData(e)}>
                <Form.Group className="mb-3" >
                    <Form.Label>Test Title</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setTitle(e.target.value)}/>
                </Form.Group>

                <Button variant="primary" type="submit">
                    Submit 
                </Button>
            </Form>

        </Modal.Body>
        <Modal.Footer>
            <Button onClick={props.onHide}>Close</Button>
        </Modal.Footer>
        </Modal>
    );
}
export default TestPopup