import { Dropdown } from "react-bootstrap";
import { Route, Router, Routes } from "react-router-dom";
import NavBar from "./layout/Navbar.js";
import Login from "./Login.js";
import Register from "./Register.js";
import AddVideos from "./layout/videos/AddVideo.js";
import WachVideos from "./layout/videos/WachVideos.js";
import AdminPage from "./layout/adminpage/AdminPage.js";
import LoadVideos from "./layout/videos/LoadVideos.js";
import RegisterSuperUser from "./RegisterSuperUser.js";
import Test from "./layout/videos/Test/Test.js";
import Profile from "./layout/videos/Profile/Profile.js";

function App() {
  
  return (
  <div >
    <NavBar/>

    <Routes>
      <Route path ="/login" element = {<Login/>}/>
      <Route path ="/register" element = {<Register/>}/>
      <Route path ="/AddVideos" element = {<AddVideos/>}/>
      <Route path ="/AdminPage" element = {<AdminPage/>}/>
      <Route path="/WachVideo/:id" element={<WachVideos/>}/>
      <Route path="/registerSuperUser" element={<RegisterSuperUser/>}/>
      <Route path="/Test/:unitid/:coursId" element={<Test/>}/>
      <Route path="/Profile" element={<Profile/>} />
      <Route path="/" element={<LoadVideos/>}/>
    
    </Routes>
    
    

  
    


    </div>
  );
}

export default App;
