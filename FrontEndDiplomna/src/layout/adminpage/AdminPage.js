
import React, {  useEffect,useState } from "react"
import axios from 'axios';
import Admin from './Admin.module.css'
import { useCookies } from "react-cookie";
import { Button } from "react-bootstrap";

function AdminPage(){
    const [users, setUsers] = useState([]);
    const [aprove,setAprove] = useState()
    const [cookies, setCookie] = useCookies(['user']);
    axios.defaults.withCredentials = true;
    const fetchData = () => {
        axios.get(`https://localhost:7021/api/AdminPageControler` ).then(response => {
          setUsers(response.data)
        })
    }
    function AproveUser(id,name){
        axios.put(`https://localhost:7021/aproveSuperUser`,{
            id: id,
            name: name,
            isAproved: true
        } ).then(() => {
            setAprove(aprove+1)
        })
    }
    useEffect(() => {
        console.log(" HERE ds")
        fetchData();
      }, [aprove])
    return (
        
        <div className={ Admin.ReactTable }>
            <h1>Weating user list</h1>
            <table>
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Role</th>
                    <th>Action</th>
                </tr>
                </thead>
                <tbody>
                {users.length > 0 && (
                    
                        users.map((user) => (
                            <tr key={user.id}>
                                <td>{user.usersName}</td>
                                <td>{user.role}</td>
                                <td><Button onClick={()=>AproveUser(user.id,user.usersName)}>approve</Button></td>
                            </tr>
                        ))
                   ) }
                </tbody>
            </table>
        </div>
    );
}
export default AdminPage