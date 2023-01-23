import React from 'react';
import axios from 'axios';
import Login from './Login';

class LoginAPI extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            isLogedin: ''
        };
    }

    async componentDidMount(loginData) {
        // POST request using axios with async/await
        const login = { 
            name: loginData.name,
            password: loginData.password
     };
        const response =await axios.post('https://localhost:7021/api/identity', login);
       // this.setState({ isLogedin: response.data });

    }
//taka li mu podavame loginData const { isLogedin } = this.state;
    render() {
       
        return (
            <div className="card text-center m-3">
                
                <Login onLogin = {this.componentDidMount}/>
                <div className="card-body">
                   
                </div>
            </div>
        );
    }
}

export { LoginAPI }; 