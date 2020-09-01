import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import { SingleDayWeatherForecast } from './SingleDayWeatherForecast';

export class WeatherData extends Component {
    static displayName = WeatherData.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, city: 'Belfast' };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <div>
                <table className='table table-bordered' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th bgcolor="#5D7B9D"><font color="#fff"></font></th>
                            <th bgcolor="#5D7B9D"><font color="#fff">Date</font></th>
                            <th bgcolor="#5D7B9D"><font color="#fff">Summary</font></th>
                            <th bgcolor="#5D7B9D"><font color="#fff">Temperature Centigrate</font></th>
                            <th bgcolor="#5D7B9D"><font color="#fff">Humidity</font></th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.map(forecast =>
                            <SingleDayWeatherForecast forecast={forecast} key={forecast.date} />
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : WeatherData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" color="red">{this.state.city} - Weather for next 5 days </h1>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const token = await authService.getAccessToken();

        let city = this.state.city;
        let dayCount = 5;
        let url = `${process.env.REACT_APP_API_BASE_URL}/api/weather/${city}/${dayCount}`;

        const response = await fetch(url, {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ forecasts: data, loading: false, city: city });
    }
}
