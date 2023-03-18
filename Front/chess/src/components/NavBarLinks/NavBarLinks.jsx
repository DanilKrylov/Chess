import React from 'react';
import { MAIN_ROUTE } from '../../utils/routes';
import Flex from '../UI/Flex/Flex';
import NavBarLink from '../UI/Links/NavBarLink/NavBarLink';

const NavBarLinks = () => {
    return (
        <Flex>
            <NavBarLink route={MAIN_ROUTE} text='Main'></NavBarLink>
        </Flex>
    );
};

export default NavBarLinks;