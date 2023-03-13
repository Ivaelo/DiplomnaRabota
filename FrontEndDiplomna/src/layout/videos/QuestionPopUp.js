import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import React, {  useState } from "react"
import axios from 'axios';

function QuestionPopUp(props) {
    const [title ,setTitle] = useState();
    const [a ,setA] = useState();
    const [b ,setB] = useState();
    const [c ,setC] = useState();
    const [Question ,setQuestion] = useState();
    const [RightAnswer ,setRightAnswer] = useState();

    function FetchData(event){
        event.preventDefault();
;
        const formData = new FormData();
        formData.append("rightAnser",RightAnswer);
        formData.append('a',a);
        formData.append('b',b);
        formData.append('c',c);
        formData.append('question',Question);
        formData.append('testsId',props.testid);
        axios.post('https://localhost:7021/api/Test/AddQuestion',formData, {
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
                    <Form.Label>A</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setA(e.target.value)}/>
                </Form.Group>
                <Form.Group className="mb-3" >
                    <Form.Label>B</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setB(e.target.value)}/>
                </Form.Group>
                <Form.Group className="mb-3" >
                    <Form.Label>C</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setC(e.target.value)}/>
                </Form.Group>
                <Form.Group className="mb-3" >
                    <Form.Label>Question</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setQuestion(e.target.value)}/>
                </Form.Group>
                <Form.Group className="mb-3" >
                    <Form.Label>RightAnswer</Form.Label>
                    <Form.Control type="text" placeholder="Enter video title" onChange={e => setRightAnswer(e.target.value)}/>
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
export default QuestionPopUp