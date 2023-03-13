import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import React, {  useState } from "react"
import axios from 'axios';
function CertificatPopup(props){
    const [name ,setName] = useState();
    const [file ,setFile] = useState();

    function FetchData(event){
        event.preventDefault();
        console.log(file);
        const formData = new FormData();
        formData.append('Name',name);
        formData.append('CoursId',props.CoursId);
        formData.append('file',file);
        axios.post('https://localhost:7021/UpoladCertificat',formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        })
        .then(res => console.log(res))
        .catch(err=> console.error(err));
    }

    return(
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
                    <Form.Label>Video Title</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setName(e.target.value)}/>
                </Form.Group>

                <Form.Group className="mb-3" >
                    <Form.Label>Add Video File </Form.Label>
                    <Form.Control type="File" placeholder="file" onChange={e => setFile(e.target.files[0])} />
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
    )
}
export default CertificatPopup