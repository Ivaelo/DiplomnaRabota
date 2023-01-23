import {LoginAPI} from "./LoginAPI.js" ;
import { Route, Router, Routes } from "react-router-dom";
import Login from "./Login.js";

function App() {
  return (
  <div className="d-flex flex-column min-vh-100">
    <Routes>
      <Route path ="/login" element = {<Login/>}/>
    
    </Routes>
    


    </div>
  );
}

export default App;
