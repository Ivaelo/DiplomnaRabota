import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Card';
import { useParams } from "react-router-dom";

import { useNavigate } from "react-router-dom"
function Surch(props){
    const navigate = useNavigate();
    const surch = useParams();  
    return(
        <div>
        {surch.length > 0 && (
               <ul >
                 {surch.map(surch => (
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
    )
}
export default Surch;