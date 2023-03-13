import { Link } from "react-router-dom";
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Card from 'react-bootstrap/Card';
import Offcanvas from 'react-bootstrap/Offcanvas';
import { useState, useEffect  } from 'react';
import { useNavigate } from "react-router-dom"
import PopupC from "./PopupC";
import PopupU from "./PopupU";
import axios from "axios";
import { Cookies, useCookies } from 'react-cookie';
import Surch from "./videos/Surch";
function NavBar(){
    const [isOpen,setIsOpen] = useState(false)
    const [isOpenUnits,setIsOpenUnits] = useState(false)
    const [surch,setSurch]= useState()
    const [surchValue,setSurchValue]= useState([])
    const [cookies, setCookie,removeCookie] = useCookies(['user']);
    const navigate = useNavigate();
    
    function handlePopupC(){
        setIsOpen(!isOpen);
    }
    function handlePopupU (){
      setIsOpenUnits(!isOpenUnits);
    }
    function HandleSurch(value){
      axios.get(`https://localhost:7021/api/CoursesControler/SurchCours?coursName=${surch}` ).then(response => {
    
          setSurchValue(response.data)
        })
        navigate(`/Surch/${surchValue}`)
    }
    function clearCoookies(){
      removeCookie("Name");
      removeCookie("Role");
      window.location.reload();
      
    }
    function NavBarPerUser(){
      if(cookies.Role ==='SuperUser'){
        return(
          <Nav  className="me-auto my-2 my-lg-0"
          style={{ maxHeight: '100px' }}
          navbarScroll>
            <Nav.Link href="/">HomePage</Nav.Link>
            <Nav.Link href="/Profile">Profile</Nav.Link>
            
            <NavDropdown title="Course Manager" id="navbarScrollingDropdown">
                  <NavDropdown.Item ><Button onClick={handlePopupC}>Create Coures</Button></NavDropdown.Item>
                  
                  <NavDropdown.Item>
                  <Button onClick={handlePopupU}>Add Unit</Button>
                  </NavDropdown.Item>
                  <NavDropdown.Divider />
                 
                    <Nav.Link href="/AddVideos">AddVideos</Nav.Link>
                  
                </NavDropdown>
                <Button variant="outline-success" onClick={()=>clearCoookies()}>Log out</Button>
                </Nav>
        )
      }
      if(cookies.Role === 'AverageUser'){
          return(
            <Nav className="me-auto my-2 my-lg-0"
            style={{ maxHeight: '100px' }}
            navbarScroll>

            <Nav.Link href="/">HomePage</Nav.Link>
            <Nav.Link href="/Profile">Profile</Nav.Link>
            <Button variant="outline-success" onClick={()=>clearCoookies()}>Log out</Button>
          </Nav>
          )
      }
      if(cookies.Role === "admin"){
        return(
          <Nav className="me-auto my-2 my-lg-0"
          style={{ maxHeight: '100px' }}
          navbarScroll>
            <Nav.Link href="/AdminPage">AdminPage</Nav.Link>
            <Nav.Link href="/">HomePage</Nav.Link>
            <Nav.Link href="/Profile">Profile</Nav.Link>
            <Button variant="outline-success" onClick={()=>clearCoookies()}>Log out</Button>
          </Nav>
        )
      }
      else{
        return(
          <Nav  className="me-auto my-2 my-lg-0"
          style={{ maxHeight: '100px' }}
          navbarScroll>
            <Nav.Link href="/register">Register</Nav.Link>
            <Nav.Link href="/registerSuperUser">RegisterAsTeacher</Nav.Link>
            <Nav.Link href="/login">Login</Nav.Link>

          </Nav>
        )
      }
    }
    useEffect(() => {
      NavBarPerUser()
    }, [cookies.Role])

    return (
        <div>
        <Navbar bg="light" expand="lg">
          <Container fluid>
            <Navbar.Brand >Uchi Qko</Navbar.Brand>
            <Navbar.Toggle aria-controls="navbarScroll" />
            <Navbar.Collapse id="navbarScroll">
              <NavBarPerUser/>
              

              <Form className="d-flex">
                <Form.Control
                  type="search"
                  placeholder="Search"
                  className="me-2"
                  aria-label="Search"
                  onChange={e => setSurch(e.target.value)}
                />
                <Button variant="outline-success" onClick={()=>HandleSurch(surch)}>Search</Button>
              </Form>
            </Navbar.Collapse>
          </Container>
        </Navbar>
        <PopupC show={isOpen}
             onHide={() => setIsOpen(false)}/>
        <PopupU show={isOpenUnits}
             onHide={() => setIsOpenUnits(false)}/>

        <div>
        {surchValue.length > 0 && (
               <ul >
                 {surchValue.map(surch => (
                   <div style={{ width: '18rem', display: 'flex',flexDirection: 'row',marginTop : '1rem' }}>
                   <Card >
                     <Card.Img variant="top" src={`https://d32lv4htez3gdk.cloudfront.net/${surch.picture}`} />
                     <Card.Body>
                       <Card.Title>{surch.coursName}</Card.Title>
                       <Card.Text>
                         {surch.description}
                       </Card.Text>
                       <Button variant="primary" onClick={()=>navigate(`/WachVideo/${surch.courseid}`)} >Go to cours</Button>
                     </Card.Body>
                   </Card></div>
                 ))}
               </ul>)}</div>
      </div>
    );
} 

export default NavBar;