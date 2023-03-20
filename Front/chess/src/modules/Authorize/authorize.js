import { registration, login } from "../../http/userAPI"
import { validateEmail } from "./validation/validateEmail"
import { validatePassword } from "./validation/validatePassword"
import { validatePasswordConfirm } from "./validation/validatePasswordConfirm"

export const registerUser = async (email, password, confirmPassword) => {
    const emailErrors = validateEmail(email)
    const passwordErrors = validatePassword(password)
    const confirmPasswordErrors =  validatePasswordConfirm(password, confirmPassword)

    if(passwordErrors.length !== 0 || emailErrors.length !== 0 || confirmPasswordErrors.length !== 0){
        return {
            successed: false,
            errors: {
                password: passwordErrors,
                email: emailErrors,
                confirmPassword: confirmPasswordErrors
            }
        }
    }

    const response = (await registration(email, password)).data
    if(response.successed){
        localStorage.setItem('token', response.jwtToken)    
    }

    response.errors.email = response.errors['DuplicateUserName']
    return response
}


export const loginUser = async (email, password) => {
    const emailErrors = validateEmail(email)
    if(emailErrors.length !== 0){
        return {
            successed: false,
            errors: {
                email: emailErrors
            }
        }
    }

    const response = (await login(email, password)).data
    
    if(response.successed){
        localStorage.setItem('token', response.jwtToken)   
    }

    return response
}
