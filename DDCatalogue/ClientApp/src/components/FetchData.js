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
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {characters.map(character =>
                        <tr key={character.date}>
                            <td>{character.date}</td>
                            <td>{character.temperatureC}</td>
                            <td>{character.temperatureF}</td>
                            <td>{character.summary}</td>
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
