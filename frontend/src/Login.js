import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";
import { useRef, useState } from "react";
import axios from 'axios';
function Login(props) {
    const nameRef = useRef();
    const passwordRef = useRef();

    const [name ,setName] = useState();
    const [password ,setPassword] = useState();
    function submitHandler(event){
        console.log("alabala");
        event.preventDefault();
        const enteredName = event.target.value;
        const enteredPassword = event.target.value;

        setName(enteredName);
        setPassword(enteredPassword);
        handleSubmit(event);
        


    }
    function handleSubmit(event){
      event.preventDefault();

      console.log("alabala2");
      axios
        .post('https://localhost:7021/api/identity',{
          name: name,
          password : password
        })
        .then(res => console.log(res))
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
                  <h2 className="fw-bold mb-2 text-uppercase ">Study</h2>
                  <p className=" mb-5">Please enter your name and password!</p>
                  <div className="mb-3">
                    <Form onSubmit={submitHandler}>
                      <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="text-center">
                          User name 
                        </Form.Label>
                        <Form.Control type="text" placeholder="Enter user name" ref = {nameRef} />
                      </Form.Group>

                      <Form.Group
                        className="mb-3"
                        controlId="formBasicPassword"
                      >
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" ref = {passwordRef}  />
                      </Form.Group>
                      <Form.Group
                        className="mb-3"
                        controlId="formBasicCheckbox"
                      >
                        <p className="small">
                          <a className="text-primary" href="#!">
                            Forgot password?
                          </a>
                        </p>
                      </Form.Group>
                      <div className="d-grid">
                        <Button variant="primary" type="submit">
                          Login
                        </Button>
                      </div>
                    </Form>
                    <div className="mt-3">
                      <p className="mb-0  text-center">
                        Don't have an account?{" "}
                        <a href="{''}" className="text-primary fw-bold">
                          Sign Up
                        </a>
                      </p>
                    </div>
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
export default Login;