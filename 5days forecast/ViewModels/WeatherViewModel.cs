using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Threading.Tasks;
using UnweWeatherApp2.Models;
using UnweWeatherApp2.Services;

namespace UnweWeatherApp2.ViewModels
{
    class WeatherViewModel
    {
        private IList<WeatherData> _weatherList;
        public IList<WeatherData> WeatherList
        {
            get
            {
                if (_weatherList == null)
                    _weatherList = new ObservableCollection<WeatherData>();
                return _weatherList;
            }
            set
            {
                _weatherList = value;
            }
        }

        private async Task APIAsync()
        {
              //var weather = await WeatherAPI.Get5dayforecast(41.008240, 28.978359, "metric");
             //v//ar weather = await WeatherAPI.GetFiveDaysAsync("Istanbul");
            //WeatherList.Add(weather);
        }

        public WeatherViewModel()
        {
            Task.Run(APIAsync);
        }
    }
}
