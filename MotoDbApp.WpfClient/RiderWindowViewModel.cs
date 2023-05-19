using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using QBU9QL_HFT_2022231.Client;
using QBU9QL_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MotoDbApp.WpfClient
{
    public class RiderWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Rider> Riders { get; set; }
        public List<string> query1;
        public List<string> query2;
        public List<string> query3;
        public List<string> Query1
        {
            get { return query1; }
            set
            {
                SetProperty(ref query1, value);
            }
        }
        public List<string> Query2
        {
            get { return query2; }
            set
            {
                SetProperty(ref query2, value);
            }
        }
        public List<string> Query3
        {
            get { return query3; }
            set
            {
                SetProperty(ref query3, value);
            }
        }
        private Rider selectedRider;

        public Rider SelectedRider
        {

            get { return selectedRider; }
            set
            {
                if (value != null)
                {
                    selectedRider = new Rider()
                    {
                        RiderId = value.RiderId,
                        Name = value.Name,
                        
                    };
                    OnPropertyChanged();

                    (DeleteRiderCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateRiderCommand { get; set; }
        public ICommand DeleteRiderCommand { get; set; }
        public ICommand UpdateRiderCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public RiderWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Riders = new RestCollection<Rider>("http://localhost:34767/", "rider", "hub");
                Query1 = new RestService("http://localhost:34767/").Get<string>("Stat/GetHasMoreThan800ccmMoto");
                Query2 = new RestService("http://localhost:34767/").Get<string>("Stat/HasAprilia");
                Query3 = new RestService("http://localhost:34767/").Get<string>("Stat/HasETZModel");
                CreateRiderCommand = new RelayCommand(() =>
                {
                    Riders.Add(new Rider()
                    {
                        Name = SelectedRider.Name
                    });
                });

                UpdateRiderCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Riders.Update(SelectedRider);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRiderCommand = new RelayCommand(() =>
                {
                    Riders.Delete(SelectedRider.RiderId);
                },
                () =>
                {
                    return SelectedRider != null;
                });
                SelectedRider = new Rider();
            }
        }
    }
}
