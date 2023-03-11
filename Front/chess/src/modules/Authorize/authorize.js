import { registration, login } from "../../http/userAPI"

export const registerUser = async (email, password, confirmPassword) => {
    const response = (await registration(email, password)).data
    console.log(response.successed)
    if(response.successed){
        console.log(response.jwtToken)
        localStorage.setItem('token', response.jwtToken)    
    }

    return response
}


export const loginUser = async (email, password) => {
    const response = (await login(email, password)).data
    console.log(response)
    if(response.successed){
        localStorage.setItem('token', response.jwtToken)   
    }

    return response
}
