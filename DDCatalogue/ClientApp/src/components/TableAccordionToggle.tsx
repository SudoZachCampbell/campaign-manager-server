import * as React from 'react';
import { useState, useEffect } from 'react';
import { useAccordionToggle } from 'react-bootstrap';

export default function TableAccordionToggle(props: any) {
    const decoratedOnClick = useAccordionToggle(props.eventKey, () => {
        console.log(`Decorated Click: ${props.eventKey}`)
        props.customOnClick(props.eventKey);
    });

    return (
        <tr onClick={decoratedOnClick} key={props.key}>{props.children}</tr>
    )
}