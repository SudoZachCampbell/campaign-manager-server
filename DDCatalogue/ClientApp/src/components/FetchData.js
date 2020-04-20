import React, { useEffect, useState } from 'react';

export default function FetchData(props) {
    const [displayName, setDisplayName] = useState(FetchData.name);
    const [characters, setCharacters] = useState([]);
    const [loading, setLoading] = useState(true);

    const populateCharactersData = async () => {
        const response = await fetch('character');
        const data = await response.json();
        setCharacters(data);
        setLoading(false);
    }

    const renderCharactersTable = characters => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Armour Class</th>
                        <th>Hit Points</th>
                        <th>Alignment</th>
                    </tr>
                </thead>
                <tbody>
                    {characters.map(character =>
                        <tr key={character.name}>
                            <td>{character.name}</td>
                            <td>{character.ac}</td>
                            <td>{character.hp}</td>
                            <td>{character.alignment}</td>
                        </tr>
                    )}
                </tbody>
            </table>
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
            <h1 id="tabelLabel" >Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );


}
