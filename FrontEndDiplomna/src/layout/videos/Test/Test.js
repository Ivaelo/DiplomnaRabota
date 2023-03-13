import 'bootstrap/dist/css/bootstrap.min.css';  
import { Button, Card,Col,Row } from 'react-bootstrap';  
import {useState, useEffect} from 'react'
import axios from 'axios';  
import { useParams } from "react-router-dom";
import { useCookies } from 'react-cookie';
function Test(){
    const[testid,setTestId]= useState(0)
    const[Questions,setQuestions]= useState([])
    const[Anser,setAnswer] = useState()
    const[Ansers,setAnsers]=useState([])
    const unidtId = useParams();  
    const [mapA, setMapA] = useState(new Map());

    
    //const [checked, setChecked] = useState(false);
    const [isSubmited,setIsSubmited]= useState(false);
    const [cookies, setCookie] = useCookies(['user']);

    


  
    function GetTestId(){
        axios.get(`https://localhost:7021/api/Test/Testid?unitId=${unidtId.unitid}`)
        .then(res=>setTestId(res.data.id))
    }
    function GetQuestions(){
        axios.get(`https://localhost:7021/api/Test/Questions?testId=${testid}`)
        .then(res=> setQuestions(res.data))
    } 
    function MyCours(){
        axios.post("https://localhost:7021/api/Test/myCourses",{
            userName:cookies.Name ,
            coursId: unidtId.coursId
        }).then(()=>Score())
    }
    function Score(){
        axios.put("https://localhost:7021/api/Test/score",{
            userName:cookies.Name ,
            coursId: unidtId.coursId 
        })
    }
    function SolveTest() {
        const values = mapA.values();
        console.log("this is the size of the map " + mapA.size);
        if (isSubmited == false) {
          const tempAnsers = [];
          for (let i = 0; i < mapA.size; i++) {
            tempAnsers.push(values.next().value);
          }
          setAnsers([...Ansers, ...tempAnsers]);
          axios
            .post("https://localhost:7021/api/Test/SolvTest", {
              ansers: tempAnsers,
              testId: testid,
              coursId: unidtId.coursId,
              userName: cookies.Name,
            })
            .then(() => MyCours());
        } else {
          alert("Kur");
        }

      }      

    const handleChange = (id,anser) => {
  
        //setChecked(!checked);
        setAnswer(anser);   
        setMapA(new Map(mapA).set(id, anser));
        console.log("this is the id"+id);
        console.log("This is the size of the map = "+mapA.size)
        //setAnsers([...Ansers,anser])
        
    };
    
    function SolveScoreTest(){
        SolveTest()      
    }
    console.log(testid)
    useEffect(() => {
        GetTestId()
        
        

      }, [])
    useEffect(() => {
   
        if(testid!==0){

            GetQuestions()
        }
        
        

      }, [testid])

    return(
        <div style={{display: 'flex',
        gap: '1rem',
        flexDirection: 'column',
        alignItems: 'center', margin : '1rem'}}>

                <Col md={8} lg={6} xs={12}>
                    <Card className="shadow">
                    <Card.Body>
                        <h1>Solve test</h1>
                        <p>Good luck </p>
                    {Questions.length > 0 && (
                        <ul className="list-group list-group-numbered">
                                {Questions.map(q => (
                                <li className="list-group-item" key={q.id} >
                                    <h6>{q.question}</h6>
                                    <input className="form-check-input" type="checkbox" value="" id="flexCheckCheckedDisabled" onChange={()=>handleChange(q.id,q.a)}/>
                                    <label className="form-check-label" >{q.a}</label>
                                    <input className="form-check-input" type="checkbox" value="" id="flexCheckCheckedDisabled" onChange={()=>handleChange(q.id,q.b)}/>
                                    <label className="form-check-label" >{q.b}</label>
                                    <input className="form-check-input" type="checkbox" value="" id="flexCheckCheckedDisabled" onChange={()=>handleChange(q.id,q.c)}/>
                                    <label className="form-check-label" >{q.c}</label>

                                </li>
                                        
                                    ))}
                            </ul>
                                )}
                    <Button disabled={isSubmited} onClick={()=>SolveScoreTest()} style={{margin:'1rem',position: 'right',float: 'right' }}>Submit</Button>
                    </Card.Body></Card></Col>

        </div>
    )
}
export default Test