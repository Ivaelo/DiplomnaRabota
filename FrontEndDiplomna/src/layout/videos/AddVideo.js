import axios from "axios"
import React, { useEffect, useState } from "react"
import { Button, Card,Form,Col,Row} from "react-bootstrap";
import { useCookies } from 'react-cookie';
import VideoPopUp from "./VideoPopUp";
import TestPopup from "./TestPopup";
import QuestionPopUp from "./QuestionPopUp";
import CertificatPopup from "./CertificatPopup";


function AddVideos () {
    const [popupShow, setPopup] = useState(false);
    const [popupShow2, setPopup2] = useState(false);
    const [popupShow3, setPopup3] = useState(false);
    const [popupShow4, setPopup4] = useState(false);
    const [courses, setCourses] = useState([]);
    const [coursesId, setCoursesId] = useState();
    

    const [units, setUnits] = useState([]);
    const [unitId, setUnitId] = useState(0);

    const [videos, setVideos] = useState([]);
    const [videosPath, setVideosPath] = useState();
    const [videoId, setVideoId] = useState();

    const [Test,setTests] = useState([]);
    const [testId,setTestsId] = useState();

    const [cookies, setCookie] = useCookies(['user']);

    function getUnits(CoursId){
        axios.get(`https://localhost:7021/api/CoursesControler/GetUnits?CoursId=${CoursId}` ).then(response => {
    
          setUnits(response.data)
        }).then(res=>{setCoursesId(CoursId)});
    }

    const fetchData = () => {
        axios.get(`https://localhost:7021/api/CoursesControler/GetCourses?UserName=${cookies.Name}` ).then(response => {
    
          setCourses(response.data)
        })
        
      }
     const  DeleteVideo = async() => {
      const res =await axios({
        method: 'DELETE',
        url: 'https://localhost:7021/api/Video/DeletVideo',
        data: {
          id : videoId,
          path : videosPath
        }
      }).then(response => {
    
          console.log(response);
        })
        
      }

      function getVideos(){
        axios.get(`https://localhost:7021/api/CoursesControler/Videos?unidtId=${unitId}` ).then(response => {
    
          setVideos(response.data)
        })
    }
    function getTests(){
      axios.get(`https://localhost:7021/api/Test/GetTest?unitId=${unitId}`)
      .then(res => setTests(res.data))
      .catch(err=> console.error(err));
    }

    function HandleVideos(e,unitId){
        e.preventDefault();
        setUnitId(unitId);
        getVideos();
        getTests();
  
      }

    function HandleVideoDelete(e){
      e.preventDefault();
      DeleteVideo();
      console.log(videoId);
      console.log(videosPath);
    }
    function setVideoData(e,path,id){
      e.preventDefault();
      setVideoId(id);
      setVideosPath(path);
      
    }
    function HandleTest(event,testsId){
      event.preventDefault();
      setPopup3(true)
      setTestsId(testsId)
      console.log(testId)
    }
      
    useEffect(() => {
        fetchData()
      }, [])
      
    useEffect(() => {
        getVideos()
      }, [popupShow])

    useEffect(() => {
        getTests()
      }, [popupShow2])
    return(
        <div>
          <Row className="vh-100 d-flex justify-content-center align-items-center">
          <Col md={8} lg={6} xs={12}>
          <Card className="shadow">
              <Card.Body>

            <div>
             <h1>Courses</h1>
             {courses.length > 0 && (
              <ul className="list-group list-group-numbered">
                {courses.map(cours => (
                <li className="list-group-item" key={cours.courseid}><Button onClick={(e) =>getUnits(cours.courseid)}>{cours.coursName}</Button></li>
                ))}
              </ul>
              )}</div>
              <div>
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
            <div>
           <h3>Videos</h3>
                        {units.length > 0 && (
                            <ul className="list-group list-group-numbered">
                                {videos.map(videos => (
                                <li className="list-group-item" key={videos.id}><Button onClick={(e) =>setVideoData(e,videos.videoPath,videos.id)}>{videos.title}</Button></li>
                                
                                ))}
                            </ul>
                        )}
            </div>
            <div>
           <h3>Tests</h3>
                        {Test.length > 0 && (
                            <ul className="list-group list-group-numbered">
                                {Test.map(test => (
                                <li className="list-group-item" key={test.id}><Button onClick={(e) =>HandleTest(e,test.id)}>{test.name}</Button></li>
                                
                                ))}
                            </ul>
                        )}
            </div>
            <button className="btn btnV btnV-2 " onClick={() => setPopup(true)}>AddVideo</button>
            <button className="btn btnV btnV-4 " onClick={() => setPopup2(true)}>Create Test</button>
            <button className="btn btnV btnV-3" onClick={(e) => HandleVideoDelete(e)}>DeleteVideo</button>
            <button className="btn btnV btnV-3" onClick={() => setPopup4(true)}>AddCertificat</button>
           </div></Card.Body></Card></Col></Row>

           <VideoPopUp show={popupShow}
             onHide={() => setPopup(false)}
             unitid = {unitId}/>
             <TestPopup show={popupShow2}
             onHide={() => setPopup2(false)}
             unitid = {unitId} />
            <QuestionPopUp show={popupShow3}
             onHide={() => setPopup3(false)}
             testid = {testId}/>
            <CertificatPopup  show={popupShow4}
             onHide={() => setPopup4(false)}
             CoursId = {coursesId}/>
        </div>
    )
}
export default AddVideos