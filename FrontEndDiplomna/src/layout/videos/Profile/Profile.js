import axios from 'axios';
import {useState, useEffect} from 'react'
import { useCookies } from 'react-cookie';
import ProgressBar from 'react-bootstrap/ProgressBar';
import {
  MDBCol,
  MDBContainer,
  MDBRow,
  MDBCard,
  MDBCardText,
  MDBCardBody,
  MDBCardImage,
  MDBBtn,
  MDBBreadcrumb,
  MDBBreadcrumbItem,
  MDBProgress,
  MDBProgressBar,
  MDBIcon,
  MDBListGroup,
  MDBListGroupItem
} from 'mdb-react-ui-kit';
function Profile(){
    const [cookies, setCookie] = useCookies(['user']);
    const [myCors, setMyCors] =useState([]);
    const [favCors, setFavCors] =useState([]);
    const [myCertificats,setMyCertificats] = useState([]);
    function GetMyCourses(){
        axios.get(`https://localhost:7021/api/Test/GetMyCour?usersName=${cookies.Name}`).then(res=>setMyCors(res.data))
    }
    function CertificateUser(){
      axios.post(`https://localhost:7021/api/Certificat/CertificateUser?UserName=${cookies.Name }`).then(()=>getCertificats())
  }
    function getCertificats(){
      axios.get(`https://localhost:7021/api/Certificat/CertificatsOfUser?userName=${cookies.Name}`).then(res=>setMyCertificats(res.data))
    }
    function getFavCourses(){
      axios.get(`https://localhost:7021/GetSub?userName=${cookies.Name}`).then(res=>setFavCors(res.data))
    }
    useEffect(() => {
        GetMyCourses()
        CertificateUser()
        getCertificats()
        getFavCourses()

      }, [])
    return(
        <div>

               <section style={{ backgroundColor: '#eee' }}>
      <MDBContainer className="py-5">
        <MDBRow>


          <MDBCol lg="8">
            <MDBCard className="mb-4">
              <MDBCardBody>
                <MDBRow>
                  <MDBCol sm="3">
                    <MDBCardText>Full Name</MDBCardText>
                  </MDBCol>
                  <MDBCol sm="9">
                    <MDBCardText className="text-muted">{cookies.Name}</MDBCardText>
                  </MDBCol>
                </MDBRow>
                <hr />
                <MDBRow>
                  <MDBCol sm="3">
                    <MDBCardText>Email</MDBCardText>
                  </MDBCol>
                  <MDBCol sm="9">
                    <MDBCardText className="text-muted">example@example.com</MDBCardText>
                  </MDBCol>
                </MDBRow>
                <hr />
                <MDBRow>
                  <MDBCol sm="3">
                    <MDBCardText>Role</MDBCardText>
                  </MDBCol>
                  <MDBCol sm="9">
                    <MDBCardText className="text-muted">{cookies.Role}</MDBCardText>
                  </MDBCol>
                </MDBRow>
                <hr />
                <MDBRow>
                  <MDBCol sm="3">
                    <MDBCardText>Mobile</MDBCardText>
                  </MDBCol>
                  <MDBCol sm="9">
                    <MDBCardText className="text-muted">(098) 765-4321</MDBCardText>
                  </MDBCol>
                </MDBRow>
                <hr />
                <MDBRow>
                  <MDBCol sm="3">
                    <MDBCardText>Address</MDBCardText>
                  </MDBCol>
                  <MDBCol sm="9">
                    <MDBCardText className="text-muted">Bay Area, San Francisco, CA</MDBCardText>
                  </MDBCol>
                </MDBRow>
              </MDBCardBody>
            </MDBCard>

            <MDBRow>
              <MDBCol md="6">
                <MDBCard className="mb-4 mb-md-0">
                  <MDBCardBody>
                    <MDBCardText className="mb-4"> MyCours</MDBCardText>
                      {myCors.length > 0 && (
                        <ul >
                          {myCors.map(cors => (
                          <MDBCardText className="mt-4 mb-1" style={{ fontSize: '.77rem' }}>aka
                          <MDBProgress className="rounded"><MDBProgressBar width={cors.progres} label={`${cors.progres}%`} /></MDBProgress></MDBCardText>
                          ))}
                        </ul>)}

                  </MDBCardBody>
                </MDBCard>
              </MDBCol>

              <MDBCol md="6">
                <MDBCard className="mb-4 mb-md-0">
                  <MDBCardBody>
                    <MDBCardText className="mb-4"> My Certificats</MDBCardText>
                    {myCertificats.length > 0 &&(
                      <ul>
                        {myCertificats.map(cert =>(
                          
                          <MDBListGroupItem key={cert.id} tag='a' href={`https://d32lv4htez3gdk.cloudfront.net/${cert.path}`} action noBorders color='success' className='px-3 rounded-3 mb-2'>
                            {cert.name}
                          </MDBListGroupItem>
                        ))}
                      </ul>
                    )}

                  </MDBCardBody>
                </MDBCard>
              </MDBCol>
              <MDBCol md="6">
                <MDBCard className="mb-4 mb-md-0">
                  <MDBCardBody>
                    <MDBCardText className="mb-4"> Subscribed Courses</MDBCardText>
                    {favCors.length > 0 &&(
                      <ul>
                        {favCors.map(cors =>(
                          <MDBListGroupItem key={cors.id} tag='a'  action noBorders color='success' className='px-3 rounded-3 mb-2'>
                            {cors.name}
                          </MDBListGroupItem>
                        ))}
                      </ul>
                    )}

                  </MDBCardBody>
                </MDBCard>
              </MDBCol>
              
            </MDBRow>
          </MDBCol>
        </MDBRow>
      </MDBContainer>
    </section>
        </div>
    )
}
export default Profile