import React, {useContext} from 'react';
import { REGISTRATION_ROUTE, LOGIN_ROUTE } from '../../utils/consts';
import { Context } from '../..';
import NavBarLink from '../UI/Links/NavBarLink/NavBarLink';
import NavBarButton from '../UI/Buttons/NavBarButton/NavBarButton';
import { observer } from 'mobx-react';
import Flex from '../UI/Flex/Flex';

const UserInfo = observer(() => {
    const { userInfo } = useContext(Context)

    const logout = () =>{
        localStorage.removeItem('token')
        userInfo.setUser(null)
        userInfo.setIsAuth(false)
    }

    if (userInfo.isAuth) {
        return (
            <Flex>
                {userInfo.user.email}
                <NavBarButton text="Logout" onClick={logout}></NavBarButton>
            </Flex>
        )
    }

    return (
        <Flex>
            <NavBarLink text="Login" route={LOGIN_ROUTE}></NavBarLink>
            <NavBarLink text="Register" route={REGISTRATION_ROUTE}></NavBarLink>
        </Flex>
    );
});

export default UserInfo;