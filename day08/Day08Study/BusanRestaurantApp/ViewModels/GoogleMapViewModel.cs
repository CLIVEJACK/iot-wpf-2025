using BusanRestaurantApp.Models;
using CefSharp.DevTools.CSS;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusanRestaurantApp.ViewModels
{
    public class GoogleMapViewModel : ObservableObject
    {
        private BusanItem _selectedMatjbItem;
        private string _matjibLocation;

        public GoogleMapViewModel()
        {
            MatjibLocation = "";
        }

        public BusanItem SelectedMatjbItem
        {
            get => _selectedMatjbItem;
            set {
                SetProperty(ref _selectedMatjbItem, value);
                // 위도(Lat), 경도(Lng)
                MatjibLocation = $"https://google.com/maps/place/{SelectedMatjbItem.Lat},{SelectedMatjbItem.Lng}";
            }
        }

        public string MatjibLocation
        {
            get => _matjibLocation;
            set => SetProperty(ref _matjibLocation, value);
        }


    }
}
