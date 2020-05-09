import * as React from 'react';
import { useEffect, useState } from 'react';
import { Button } from 'react-bootstrap';

export default function Npc(props: any) {

    return (
        <div>
            {props.npc.map((p: any) => {
                return (
                    <div>{p}</div>
                )
            })}
            <Button variant="outline-info">Details</Button>
        </div>
    )
}