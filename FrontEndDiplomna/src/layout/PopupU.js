import { useEffect,useState } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import axios from 'axios';
import { Dropdown } from 'react-bootstrap';
import { Modal } from 'react-bootstrap';
import NavDropdown from 'react-bootstrap/NavDropdown';

import { useCookies } from 'react-cookie';


function PopupU(props) {
    const [name ,setName] = useState();
    const [description ,setDescription] = useState();
    const [id ,setId] = useState();
    const [cookies, setCookie] = useCookies(['user']);
    const [courses, setCourses] = useState([]);
    const [coursesId, setCoursesId] = useState(0);
    

    axios.defaults.withCredentials = true;

  
  
    const fetchData = () => {
      axios.get(`https://localhost:7021/api/CoursesControler/GetCourses?UserName=${cookies.Name}` ).then(response => {
  
        setCourses(response.data)
      })
      
    }
    
    function handleSubmit(event){
      event.preventDefault();

      console.log("alabala2");
      console.log(name);
      console.log(description);
      axios
        .post('https://localhost:7021/AddUnit',{
          unitName: name,
          userName:cookies.Name,
          courseId: coursesId
        })
        .then(res => console.log(res))
        .catch(err=> console.error(err));
    }
    useEffect(() => {
      fetchData()
    }, [])
    
  return (
    <Modal
    {...props}
    size="lg"
    aria-labelledby="contained-modal-title-vcenter"
    centered
    >
    <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
        Add Unit
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>
    <Form className=''>
    
      <Form.Group className="mb-3" controlId="formBasicEmail">
        <NavDropdown title="Course Manager" id="navbarScrollingDropdown">                  
          <NavDropdown.Item>
          <div>
             {courses.length > 0 && (
              <ul>
                {courses.map(cours => (
                <li key={cours.courseid}><Button onClick={() => setCoursesId(cours.courseid)}>{cours.coursName}</Button></li>
                ))}
              </ul>
              )}  
           </div>
          </NavDropdown.Item>
         </NavDropdown>
      </Form.Group>
      

      <Form.Group className="mb-3  " controlId="formBasicDescription">
        <Form.Label >UnitName</Form.Label>
        <Form.Control  type="text " placeholder="description" onChange={e => setName(e.target.value)} />
      </Form.Group>

      <Button variant="primary" type="submit" onClick={ e => handleSubmit(e)} >
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

export default PopupU;