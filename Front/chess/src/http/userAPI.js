import { $host, $authHost } from "."
import jwt_decode from 'jwt-decode'

export const registration = async (email, password) => {
    const response = await $host.post('api/authorize/register', { email: email, password: password})
    return response;
}

export const login = async (email, password) => {
    const response = await $host.post('api/authorize/login', { email: email, password: password})
    return response;
}

export const check = async () =>{
    try{
        await $authHost.get('api/authorize/checkAuth')
    }
    catch{
        return false;
    }

    return mapJwtClaims(jwt_decode(localStorage.getItem('token')))
}


function mapJwtClaims(jwtClaims) {
    const mapping = {
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress": "email"
    };

    const result = {};
    for (const key in jwtClaims) {
        const mappedKey = mapping[key] || key;
        result[mappedKey] = jwtClaims[key];
    }
    return result;
}