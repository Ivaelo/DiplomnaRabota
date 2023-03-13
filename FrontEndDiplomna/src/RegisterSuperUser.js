import { Col, Button, Row, Container, Card, Form, Nav } from "react-bootstrap";
import { useState } from "react";
import axios from 'axios';
import { useNavigate } from "react-router-dom"
function RegisterSuperUser(props) {
    const [name ,setName] = useState();
    const [email ,setEmail] = useState();
    const [password ,setPassword] = useState();
    const navigate = useNavigate();

    function handleSubmit(event){
      event.preventDefault();

      console.log("alabala2");
      axios
        .post('https://localhost:7021/superUser',{
          name: name,
          email: email,
          password : password
        })
        .then(() => navigate("/"))
        .catch(err=> console.error(err));
    }
  return (
    <div>
      <Container  >
        <img className="bg" src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img3.webp"/>
        <Row className="vh-100 d-flex justify-content-center align-items-center">
          <Col md={8} lg={6} xs={12}>
            <div className="border border-3 border-primary"></div>
            <Card className="shadow">
              <Card.Body>
                <div className="mb-3 mt-md-4">
                  <h2 className="fw-bold mb-2 text-uppercase ">Register as Teacher</h2>
                  <p className=" mb-5">Please enter your name, email and password!</p>
                  <div className="mb-3">
                    <Form >
                      <Form.Group className="mb-3" controlId="formBasicName">
                        <Form.Label className="text-center">
                          User name 
                        </Form.Label>
                        <Form.Control type="text" placeholder="Enter user name" onChange={e=> setName(e.target.value)} />
                      </Form.Group>

                      <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="text-center">
                          Email
                        </Form.Label>
                        <Form.Control type="text" placeholder="Enter user name" onChange={e=> setEmail(e.target.value)} />
                      </Form.Group>

                      <Form.Group
                        className="mb-3"
                        controlId="formBasicPassword"
                      >
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" onChange={e => setPassword(e.target.value)}  />
                      </Form.Group>
                      <Form.Group
                        className="mb-3"
                        controlId="formBasicCheckbox"
                      >
                      </Form.Group>
                      <div className="d-grid">
                        <Button  variant="primary" type="submit" onClick={e=> handleSubmit(e)} >
                          Signup
                        </Button>
                      </div>
                    </Form>
                    
                  </div>
                </div>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
}
export default  RegisterSuperUser;