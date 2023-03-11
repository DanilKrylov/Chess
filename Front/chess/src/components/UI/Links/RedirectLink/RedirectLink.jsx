import React from 'react';
import RedirectLinkText from '../../Texts/RedirectLinkText/RedirectLinkText';
import { Link } from 'react-router-dom';

const RedirectLink = ({route, text}) => {
    return (
        <Link to={route}>
            <RedirectLinkText text={text}></RedirectLinkText>
        </Link>
    );
};

export default RedirectLink;