import React, { useEffect, useState } from 'react';

export default function FetchData(props) {
    const [displayName, setDisplayName] = useState(FetchData.name);
    const [forecasts, setForecasts] = useState([]);
    const [loading, setLoading] = useState(true);

    const populateWeatherData = async () => {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
        setLoading(false);
    }

    const renderForecastsTable = forecasts => {
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
                    {forecasts.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    const contents = loading
        ? <p><em>Loading...</em></p>
        : renderForecastsTable(forecasts);


    useEffect(() => {
        populateWeatherData();
    }, [])

    return (
        <div>
            <h1 id="tabelLabel" >Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );


}
