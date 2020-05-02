import * as React from 'react';
import { useEffect, useState } from 'react';

export default function Character(props: any) {
    const [character, setCharacter] = useState({});
    const [loading, setLoading] = useState(true);

    const populateCharacterData = async () => {
        //if (Object.keys(props.character).length === 0) {
        //const response = await fetch(`character/details/${props.id}`);
        //const data = await response.json();
        //setCharacter(data);
        //setLoading(false);
        //} else {
        console.log("", props.character);
        setCharacter(props.character);
        setLoading(false);
        //}
    }

    const renderCharacter = () => {
        return character.name
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