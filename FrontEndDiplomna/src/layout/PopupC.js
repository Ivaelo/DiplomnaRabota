import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import axios from 'axios';
import Modal from 'react-bootstrap/Modal';
import Cookies from 'js-cookie';
import { useCookies } from 'react-cookie';

function PopupC(props) {
    const [name ,setName] = useState();
    const [description ,setDescription] = useState();
    const [cookies, setCookie] = useCookies(['user']);
    const [file,setFile] = useState();
    axios.defaults.withCredentials = true;



    function handleSubmit(event){
      event.preventDefault();

      console.log("alabala2");
      console.log(name);
      console.log(description);
      const formData = new FormData();
      formData.append('CoursName', name);
      formData.append('Description',description);
      formData.append('userName',cookies.Name);
      formData.append('file',file);
      axios
        .post('https://localhost:7021/CreateCourese',formData,{
          headers: {
              'Content-Type': 'multipart/form-data',
          }
      })
        .then(res => console.log(res))
        .catch(err=> console.error(err));
        console.log(cookies);
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
            Create Cours
            </Modal.Title>
        </Modal.Header>
        <Modal.Body>


            <Form className=''>
              <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Cours Name</Form.Label>
                <Form.Control type="text" placeholder="Enter name" onChange={e => setName(e.target.value)} />

              </Form.Group>

              <Form.Group className="mb-3  " controlId="formBasicDescription">
                <Form.Label >Description</Form.Label>
                <Form.Control  type="text " placeholder="description" onChange={e => setDescription(e.target.value)} />
              </Form.Group>
              <Form.Group className="mb-3  ">
                <Form.Label >Picture</Form.Label>
                <Form.Control type="File" placeholder="file" onChange={e => setFile(e.target.files[0])} />
              </Form.Group>

              <Button variant="primary" type="submit" onClick={e=> handleSubmit(e)}>
                Submit
              </Button>
            </Form> </Modal.Body>
          <Modal.Footer>
              <Button onClick={()=>{props.onHide();window.location.reload();}}>Close</Button>
          </Modal.Footer>
          </Modal>

  );
 
 
}

export default PopupC;