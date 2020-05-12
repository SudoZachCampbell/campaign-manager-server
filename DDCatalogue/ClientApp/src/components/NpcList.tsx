import { useEffect, useState } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import * as React from 'react';
import Npc from './Npc';
import { Accordion, Card, Button, Table } from 'react-bootstrap';
import Tr from './TableAccordionToggle';

export default function NpcList(props: any) {
    const [npcs, setNpcs] = useState([]);
    const [loading, setLoading] = useState(true);
    const [lastOpened, setLastOpened] = useState(0);

    const populateNpcsData = async () => {
        const response = await fetch('npc');
        const data = await response.json();
        console.log("Npcs returned: ", data);
        setNpcs(data);
        setLoading(false);
    }

    const customOnClick = (row: any) => {
        console.log(`Callback fired: ${row}`);
        const rowElement = document.getElementById(`hide-row-${row}`);
        if (rowElement) {
            if (lastOpened) {
                console.log(`Last Opened: ${lastOpened}`)
                const lastRowElement = document.getElementById(`hide-row-${lastOpened}`);
                if (lastRowElement) lastRowElement.style.display = "none"
            }
            if (row !== lastOpened) {
                rowElement.style.display = rowElement.style.display === "none" ? "table-row" : "none";
                setLastOpened(row);
            }
        }
    }

    const renderNpcsTable = (npcs: any[]) => {
        return (
            <Router>
                <div>
                    <Accordion>
                        <Table hover>
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Monster</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    npcs.map((npc: any) =>
                                        <>
                                            <Tr eventKey={`${npc.Id}`} key={npc.Name} customOnClick={customOnClick}>
                                                <td>{npc.Id}</td>
                                                <td>{npc.Name}</td>
                                                <td>{npc.Monster.Name}</td>
                                            </Tr>
                                            <tr id={`hide-row-${npc.Id}`} style={{ display: "none" }}>
                                                <td colSpan={5}>
                                                    <Accordion.Collapse eventKey={`${npc.Id}`}>
                                                        <Npc npc={npc} />
                                                    </Accordion.Collapse>
                                                </td>
                                            </tr>
                                        </>
                                    )
                                }
                            </tbody>
                        </Table>
                    </Accordion>

                    <Switch>
                        {npcs.map((npc: any) =>
                            <Route exact path={`/npc/${npc.Id}`}>
                                <Npc npc={npc} />
                            </Route>
                        )}
                    </Switch>
                </div>
            </Router>
        );
    }

    const contents = loading
        ? <p><em>Loading...</em></p>
        : renderNpcsTable(npcs);


    useEffect(() => {
        populateNpcsData();
    }, [])

    return (
        <div>
            <h1 id="tabelLabel" >Npcs</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );


}
