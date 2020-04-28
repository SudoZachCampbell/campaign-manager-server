import * as React from 'react';
import { Link } from 'react-router-dom';

export default function Td(props: any) {
    // Conditionally wrapping content into a link
    const ContentTag = props.to ? Link : 'div';

    return (
        <td>
            <ContentTag to={props.to}>{props.children}</ContentTag>
        </td>
    );
}