import React, { useContext, useState } from 'react';
import InputBlock from '../../components/InputBlock/InputBlock';
import SubmitButton from '../../components/UI/Buttons/SubmitButton/SubmitButton';
import FormWrapper from '../../components/UI/FormWrappers/FormWrapper/FormWrapper';
import HeadText from '../../components/UI/Texts/HeadText/HeadText';
import RedirectLink from '../../components/UI/Links/RedirectLink/RedirectLink';
import { loginUser } from './authorize'
import { MAIN_ROUTE } from '../../utils/routes';
import { useNavigate } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { Context } from '../..';

const LoginForm = observer(() => {
    const [emailInfo, setEmailInfo] = useState({ value: '', errors: [] });
    const [passwordInfo, setPasswordInfo] = useState({ value: '', errors: [] });
    const navigate = useNavigate()
    const { userInfo } = useContext(Context)

    async function submit() {
        const result = await loginUser(emailInfo.value, passwordInfo.value)
        
        if (result.successed) {
            userInfo.setUser({ email: emailInfo.value })
            userInfo.setIsAuth(true)
            navigate(MAIN_ROUTE)
        }

        setEmailInfo({ ...emailInfo, errors: result.errors.email || [] })
        setPasswordInfo({ ...passwordInfo, errors: result.errors.password || [] })
    }

    return (
        <div>
            <FormWrapper>
                <div>
                    <HeadText text="Login"></HeadText>
                    <InputBlock
                        type='text'
                        errors={emailInfo.errors}
                        value={emailInfo.value}
                        setValue={(email) => setEmailInfo({ ...emailInfo, value: email })}
                        text='Email'></InputBlock>
                    <InputBlock
                        type='password'
                        errors={passwordInfo.errors}
                        value={passwordInfo.value}
                        setValue={(password) => setPasswordInfo({ ...passwordInfo, value: password })}
                        text='Password'>
                    </InputBlock>
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