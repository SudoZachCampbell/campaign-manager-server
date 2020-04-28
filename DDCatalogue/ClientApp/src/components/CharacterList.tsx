import { useEffect, useState } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import * as React from 'react';
import Td from './Td';
import Character from './Character';

export default function CharacterList(props: any) {
    const [characters, setCharacters] = useState([]);
    const [loading, setLoading] = useState(true);

    const populateCharactersData = async () => {
        const response = await fetch('character');
        const data = await response.json();
        setCharacters(data);
        setLoading(false);
    }

    const renderCharactersTable = (characters: any[]) => {
        return (
            <Router>
                <div>
                    <table className='table .table-hover table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Armour Class</th>
                                <th>Hit Points</th>
                                <th>Alignment</th>
                            </tr>
                        </thead>
                        <tbody>
                            {characters.map((character: any) =>
                                <tr key={character.name}>
                                    <Td to={`/character/${character.characterId}`}>{character.characterId}</Td>
                                    <Td to={`/character/${character.characterId}`}>{character.name}</Td>
                                    <Td to={`/character/${character.characterId}`}>{character.ac}</Td>
                                    <Td to={`/character/${character.characterId}`}>{character.hp}</Td>
                                    <Td to={`/character/${character.characterId}`}>{character.alignment}</Td>
                                </tr>
                            )}
                        </tbody>
                    </table>

                    <Switch>
                        {characters.map((character: any) =>
                            <Route path={`/character/${character.characterId}`}>
                                <Character id={character.characterId} />
                            </Route>
                        )}
                    </Switch>
                </div>
            </Router>
        );
    }

    const contents = loading
        ? <p><em>Loading...</em></p>
        : renderCharactersTable(characters);


    useEffect(() => {
        populateCharactersData();
    }, [])

    return (
        <div>
            <h1 id="tabelLabel" >Characters</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );


}
