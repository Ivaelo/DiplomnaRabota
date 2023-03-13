import axios from "axios"
import { useNavigate } from "react-router-dom"
import { useState,useEffect } from "react"
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import { useCookies } from 'react-cookie';
function LoadVideos(){
    const[videos,setVideos]= useState([]);
    const navigate = useNavigate();
    const [cookies, setCookie] = useCookies(['user']);
    function HandleSurch(){
        axios.get(`https://localhost:7021/api/CoursesControler/LoadCourses` ).then(response => {
      
            setVideos(response.data)
          })
      }
    function UserLoadHandler(){
      if(cookies.Name){
        return(
        <div>
                  {videos.length > 0 && (
               <ul style={{
                display: 'flex',
                gap: '3rem',
                flexWrap: 'wrap',
            }}>
                 {videos.map(surch => (
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
               </ul>)}
         </div>
         )
      }
      else{
          return(<h1>You have to be loged in if you want to study</h1>)
      }
    }
      useEffect(() => {
        HandleSurch()
        UserLoadHandler()
      }, [])

    return(
        <div>
          <UserLoadHandler/>
        </div>
          


    )
}//<li  key={surch.courseid}><button onClick={()=>navigate(`/WachVideo/${surch.courseid}`)}><img src={`https://d32lv4htez3gdk.cloudfront.net/${surch.picture}`} width={"500px"} height={"400px"} />{surch.coursName}  </button></li>
export default LoadVideos