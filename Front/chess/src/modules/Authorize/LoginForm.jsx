import React, { useContext, useState } from 'react';
import InputBlock from '../../components/InputBlock/InputBlock';
import SubmitButton from '../../components/UI/Buttons/SubmitButton/SubmitButton';
import FormWrapper from '../../components/UI/FormWrappers/FormWrapper/FormWrapper';
import HeadText from '../../components/UI/Texts/HeadText/HeadText';
import RedirectLink from '../../components/UI/Links/RedirectLink/RedirectLink';
import { loginUser } from './authorize'
import { MAIN_ROUTE } from '../../utils/consts';
import { useNavigate } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { Context } from '../..';

const LoginForm = observer(() => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate()
    const { userInfo } = useContext(Context)

    async function submit() {
        const result = await loginUser(email, password)
        if (result.successed) {
            userInfo.setUser({ email: email })
            userInfo.setIsAuth(true)
            navigate(MAIN_ROUTE)
        }
    }

    return (
        <div>
            <FormWrapper>
                <div>
                    <HeadText text="Login"></HeadText>
                    <InputBlock type='text' value={email} setValue={setEmail} text='Email'></InputBlock>
                    <InputBlock type='password' value={password} setValue={setPassword} text='Password'></InputBlock>
                </div>
                <div>
                    <SubmitButton text='Login' onClick={submit}></SubmitButton>
                    <RedirectLink text={'dont have an account?'} route='/registration'></RedirectLink>
                </div>
            </FormWrapper>
        </div>
    );
});

export default LoginForm;