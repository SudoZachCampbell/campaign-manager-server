import * as React from 'react';
import { useEffect, useState } from 'react';
import { Button, Col, Container, Image, Row } from 'react-bootstrap';
import * as _ from 'lodash';

export default function Npc(props: any) {
    return (
        <Container>
            <Row>
                <Col>
                    <h1 className="display-4">{props.data.Name}</h1>
                    <div>{props.npc.Monster ? props.data.Monster.Name : "None"}</div>
                    <Button variant="outline-info">Details</Button>
                </Col>
                {props.data.Picture &&
                    <Col style={{height: "100px"}}>
                        <Image src={`https\://ddimagecollection.s3-eu-west-1.amazonaws.com/npc/${props.data.Picture}`} />
                    </Col>
                }
            </Row>
        </Container>
    )
}