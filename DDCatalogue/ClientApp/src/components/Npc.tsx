import * as React from 'react';
import { useEffect, useState } from 'react';
import { Button } from 'react-bootstrap';
import * as _ from 'lodash';

export default function Npc(props: any) {
    return (
        <div>
            <div>
                <div>{props.npc.Name}</div>
                <div>{props.npc.Monster.Name}</div>
            </div>
            <Button variant="outline-info">Details</Button>
        </div>
    )
}