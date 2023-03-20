export const validatePassword = (password) => {
    var passwordErrors = []
    if(!/[A-Z]/.test(password))
        passwordErrors.push('password must contain at least one capital letter')

    if(!/[a-z]/.test(password))
        passwordErrors.push('password must contain at list one lowercase letter')

    if(!/[0-9]/.test(password))
        passwordErrors.push('password must contain at least one number')
    
    if(!/[A-Za-z0-9]/.test(password))
        passwordErrors.push('password must contain only numbers and letters')
    
    if(password.length < 8)
        passwordErrors.push('password length must be at least 8')

    return passwordErrors;
};