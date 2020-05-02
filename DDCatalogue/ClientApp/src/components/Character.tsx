import * as React from 'react';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

export default function Character(props: any) {
    const [character, setCharacter] = useState({});
    const [loading, setLoading] = useState(true);
    const { id } = useParams();

    const populateCharacterData = async () => {
        if (Object.keys(props.character).length === 0) {
            const response = await fetch(`character/details/${props.id}`);
            const data = await response.json();
            console.log(data);
            setCharacter(data);
            setLoading(false);
        } else {
            console.log("", props.character);
            setCharacter(props.character);
            setLoading(false);
        }
    }

    const renderCharacter = () => {
        return (
            <a href={`/character-details/${id}`}>character[name]</a>
        )

    }

    const contents = loading
        ? <p><em>Loading...</em></p>
        : renderCharacter();

    useEffect(() => {
        populateCharacterData();
    }, [])


    return (
        <div>{contents}</div>
    )
}