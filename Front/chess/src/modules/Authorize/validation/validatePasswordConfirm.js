export const  validatePasswordConfirm = (password, passwordConfirm) => {
    return password === passwordConfirm ? [] : ['must be equal to password']
}