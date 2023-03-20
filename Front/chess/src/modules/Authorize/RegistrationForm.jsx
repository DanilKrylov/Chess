import { observer } from 'mobx-react';
import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Context } from '../..';
import InputBlock from '../../components/InputBlock/InputBlock';
import SubmitButton from '../../components/UI/Buttons/SubmitButton/SubmitButton';
import FormWrapper from '../../components/UI/FormWrappers/FormWrapper/FormWrapper';
import RedirectLink from '../../components/UI/Links/RedirectLink/RedirectLink';
import HeadText from '../../components/UI/Texts/HeadText/HeadText';
import { MAIN_ROUTE } from '../../utils/routes';
import { registerUser } from './authorize';

const RegistrationForm = observer(() => {
    const [emailInfo, setEmailInfo] = useState({ value: '', errors: [] });
    const [passwordInfo, setPasswordInfo] = useState({ value: '', errors: [] });
    const [confirmPasswordInfo, setConfirmPasswordInfo] = useState({ value: '', errors: [] });
    const navigate = useNavigate()
    const { userInfo } = useContext(Context)

    async function submit() {
        const result = await registerUser(emailInfo.value, passwordInfo.value, confirmPasswordInfo.value)
        if (result.successed) {
            userInfo.setUser({ email: emailInfo.value })
            userInfo.setIsAuth(true)
            navigate(MAIN_ROUTE)
        }
        console.log(result)

        setEmailInfo({ ...emailInfo, errors: result.errors.email || [] })
        setPasswordInfo({ ...passwordInfo, errors: result.errors.password || [] })
        setConfirmPasswordInfo({...confirmPasswordInfo, errors: result.errors.confirmPassword || []})
    }

    return (
        <FormWrapper>
            <div>
                <HeadText text="Registration"></HeadText>
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
                <InputBlock
                    type='password'
                    errors={confirmPasswordInfo.errors}
                    value={confirmPasswordInfo.value}
                    setValue={(password) => setConfirmPasswordInfo({ ...confirmPasswordInfo, value: password })}
                    text='Confirm password'>
                </InputBlock>
            </div>
            <div>
                <SubmitButton text='Register' onClick={submit}></SubmitButton>
                <RedirectLink text={'already have an account?'} route='/login'></RedirectLink>
            </div>
        </FormWrapper>
    );
});

export default RegistrationForm;