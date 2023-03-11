import { observer } from 'mobx-react';
import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Context } from '../..';
import InputBlock from '../../components/InputBlock/InputBlock';
import SubmitButton from '../../components/UI/Buttons/SubmitButton/SubmitButton';
import FormWrapper from '../../components/UI/FormWrappers/FormWrapper/FormWrapper';
import RedirectLink from '../../components/UI/Links/RedirectLink/RedirectLink';
import HeadText from '../../components/UI/Texts/HeadText/HeadText';
import { MAIN_ROUTE } from '../../utils/consts';
import { registerUser } from './authorize';

const RegistrationForm = observer(() => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const navigate = useNavigate()
    const { userInfo } = useContext(Context)

    async function submit() {
        const result = await registerUser(email, password, confirmPassword)
        if (result.successed) {
            userInfo.setUser({ email: email })
            userInfo.setIsAuth(true)
            navigate(MAIN_ROUTE)
        }
    }

    return (
        <FormWrapper>
            <div>
                <HeadText text="Registration"></HeadText>
                <InputBlock type='text' value={email} setValue={setEmail} text='Email'></InputBlock>
                <InputBlock type='password' value={password} setValue={setPassword} text='Password'></InputBlock>
                <InputBlock type='password' value={confirmPassword} setValue={setConfirmPassword} text='ConfirmPassword'></InputBlock>
            </div>
            <div>
                <SubmitButton text='Register' onClick={submit}></SubmitButton>
                <RedirectLink text={'already have an account?'} route='/login'></RedirectLink>
            </div>
        </FormWrapper>
    );
});

export default RegistrationForm;