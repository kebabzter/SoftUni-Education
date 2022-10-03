import { clearUserData, setUserData } from "../util.js";
import { get, post } from "./api.js";

export async function login (email,password){
    const result = await post('/users/login', {email, password});

    const userData = {
        id: result._id,
        email: result.email,
        gender: result.gender,
        accessToken: result.accessToken
    }

    setUserData(userData);

    return result;
}

export async function register ( email, password, gender){
    const result = await post('/users/register', { email, password, gender});

    const userData = {
        id: result._id,
        email: result.email,
        gender: result.gender,
        accessToken: result.accessToken
    }

    setUserData(userData);

    return result;
}

export function logout (){
    get('/users/logout');
    clearUserData();
}


