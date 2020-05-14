import * as React from 'react';
import { useEffect, useState } from 'react';
import { Button, Col, Container, Image, Row } from 'react-bootstrap';
import * as _ from 'lodash';

export default function Npc(props: any) {
    return (
        <Container>
            <Row>
                <Col>
                    <h1 className="display-4">{props.npc.Name}</h1>
                    <div>{props.npc.Monster ? props.npc.Monster.Name : "None"}</div>
                    <Button variant="outline-info">Details</Button>
                </Col>
                {props.npc.Picture &&
                    <Col>
                        <Image src={`https\://ddimagecollection.s3-eu-west-1.amazonaws.com/npc/${props.npc.Picture}`} />
                    </Col>
                }
            </Row>
        </Container>
    )
}