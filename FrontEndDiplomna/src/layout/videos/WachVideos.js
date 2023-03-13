import 'bootstrap/dist/css/bootstrap.min.css';  
import { Button, Container, Offcanvas } from 'react-bootstrap';  
import {useState, useEffect} from 'react'
import axios from 'axios';  
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom"
import { useCookies } from 'react-cookie';
function WachVideos(props){
    const [show, setShow] = useState(false); 
    const [units, setUnits] = useState([]); 
    const [unitId, setUnitId] = useState(0);
    const [videos, setVideos] = useState([]);
    const [videosId, setVideosId] = useState();
    const [videoURL,setVideoURL] = useState("https://d32lv4htez3gdk.cloudfront.net/");
    const [cookies, setCookie] = useCookies(['user']);
    const navigate = useNavigate();
    const closeSidebar = () => setShow(false);  
    const showSidebar = () => setShow(true);
    const id = useParams();  
    
    function getUnits(){
        axios.get(`https://localhost:7021/api/CoursesControler/GetUnits?CoursId=${id.id}` ).then(response => {
    
          setUnits(response.data)
        })
    }
    function getVideos(){
      axios.get(`https://localhost:7021/api/CoursesControler/Videos?unidtId=${unitId}` ).then(response => {
  
        setVideos(response.data)
      })
  }
  function Subscribe(){
    axios.post(`https://localhost:7021/api/Subscribe`,{
      coursId: id.id,
      name: cookies.Name
    } ).then(response =>console.log(response))
}
    function HandleVideos(e,unitId){
      
      setUnitId(unitId)
      getVideos()

    }
    
    useEffect(() => {
      getUnits()

    }, [])
    useEffect(() => {
      console.log(videosId);

    }, [videosId])
    console.log( videoURL+ videosId)
    return(
        <div style={{display: 'flex',
          gap: '1rem',
          flexDirection: 'column',
          alignItems: 'center'}}>
            <h1>Whach video here!</h1>
        <div >
            <video className='center' width={"700px"} height={"400px"} controls src={videoURL + videosId} style={{marginTop : '1rem' }}/>

        </div>
            <div> 
              <Button variant="primary" onClick={()=>Subscribe()}>  
                Subscribe  
              </Button>
              <Button variant="primary" onClick={()=>showSidebar()}>  
                See Videos  
              </Button>   
            <Container className='p-4'>  


              <Offcanvas backdrop='false' show={show} onHide={closeSidebar}>  
                <Offcanvas.Header closeButton>  
                  <Offcanvas.Title>Chuse Video</Offcanvas.Title>  
                </Offcanvas.Header>
                <Offcanvas.Body>  
                    <div >
                    <h2>Units</h2>
                        {units.length > 0 && (
                            <ul className="list-group list-group-numbered">
                                {units.map(unit => (
                                  <li className="list-group-item" key={unit.unitid}><Button onClick={(e) =>HandleVideos(e,unit.unitid)}>{unit.unitName}</Button></li>
                                ))}
                            </ul>
                        )}
                    </div>
                    <div>
                    <h3>Videos</h3>
                        {units.length > 0 && (
                            <ul className="list-group list-group-numbered">
                                {videos.map(videos => (
                                <li className="list-group-item" key={videos.id}><Button onClick={() =>setVideosId(videos.videoPath)}>{videos.title}</Button></li>
                                
                                ))}
                            </ul>
                        )}
                    </div>
                    <Button onClick={()=>navigate(`/Test/${unitId}/${id.id}`)}>Take Test</Button>
                </Offcanvas.Body>  
              </Offcanvas>  
              </Container>  
            </div>  
            </div>
    )
}
export default WachVideos