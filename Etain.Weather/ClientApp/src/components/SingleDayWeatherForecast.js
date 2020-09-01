import React, {Component} from 'react';
import { WeatherImageProvider } from './WeatherImageProvider';
import './SingleDayWeatherForecast.css';


export class SingleDayWeatherForecast extends Component {

 constructor(props){
     super(props);
     this.state = {
       date : props.forecast.date,
       summary : props.forecast.summary,
       temperature : props.forecast.temperature,
       humidity: props.forecast.humidity
     };
     console.log(props.date);
     console.log(this.state.summary);
  }



    render() {
        return(
        <tr key={this.state.date}>
          <td><img className='weatherImg' src={ WeatherImageProvider.get(this.state.summary)} alt={this.state.summary} /></td>
          <td>{this.state.date}</td>
          <td>{this.state.summary}</td>
          <td>{this.state.temperature}</td>
          <td>{this.state.humidity}</td>
        </tr>
          )
    }
 }
