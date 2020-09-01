import {Component} from 'react';
import snow from '../assets/images/snow.png';
import sleet from '../assets/images/sleet.png';
import thunderstorm from '../assets/images/thunderstorm.png';
import hail from '../assets/images/hail.png';
import lightRain from '../assets/images/lightRain.png';
import heavyRain from '../assets/images/heavyRain.png';
import showers from '../assets/images/showers.png';
import lightCloud from '../assets/images/lightCloud.png';
import heavyCloud from '../assets/images/heavyCloud.png';
import sunny from '../assets/images/sunny.png';

export class WeatherImageProvider extends Component{

static get(weatherType){
    switch(weatherType)
    {
      case 'Light Rain' : return lightRain;
      case 'Heavy Rain' : return heavyRain;
      case 'Clear' : return sunny;
      case 'Light Cloud' : return lightCloud;
      case 'Heavy Cloud' : return heavyCloud;
      case 'Showers' : return showers;
      case 'Sleet' : return sleet;
      case 'Snow' : return snow;
      case 'Thunderstorm' : return thunderstorm;
      case 'Hail' : return hail;
      default: return null;
    }
  };
}