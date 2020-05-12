import * as React from 'react';
import { useEffect, useState } from 'react';
import { Button } from 'react-bootstrap';
import * as _ from 'lodash';

export default function Npc(props: any) {

    return (
        <div>
            {_.map(props.npc, (p: any) => {
                console.log(p);
                return (
                    <div>{p}</div>
                )
            })}
            <Button variant="outline-info">Details</Button>
        </div>
    )
}