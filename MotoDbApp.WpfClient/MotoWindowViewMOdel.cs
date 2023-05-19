using Microsoft.Toolkit.Mvvm.Input;
using QBU9QL_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using QBU9QL_HFT_2022231.Client;

namespace MotoDbApp.WpfClient
{
    internal class MotoWindowViewMOdel : ObservableObject
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Moto> Motos { get; set; }
        public List<string> query1;
        public List<string> query2;
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

        private Moto selectedMoto;

        public Moto SelectedMoto
        {

            get { return selectedMoto; }
            set
            {
                if (value != null)
                {
                    selectedMoto = new Moto()
                    {
                        MotoId = value.MotoId,
                        Model = value.Model,

                    };
                    OnPropertyChanged();

                    (DeleteMotoCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateMotoCommand { get; set; }
        public ICommand DeleteMotoCommand { get; set; }
        public ICommand UpdateMotoCommand { get; set; }
        
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MotoWindowViewMOdel()
        {

            if (!IsInDesignMode)
            {
                Motos = new RestCollection<Moto>("http://localhost:34767/", "moto", "hub");
                //noncrud ItemSource = ((MainWindowViewModel)DataContext).Musicians;
                Query1 = new RestService("http://localhost:34767/").Get<string>("Stat/GetCompanyOlderThan70");
                Query2 = new RestService("http://localhost:34767/").Get<string>("Stat/GetMaxSoldCompany");


                CreateMotoCommand = new RelayCommand(() =>
                {
                    Motos.Add(new Moto()
                    {
                        Model = SelectedMoto.Model
                    });
                });

                UpdateMotoCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Motos.Update(SelectedMoto);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteMotoCommand = new RelayCommand(() =>
                {
                    Motos.Delete(SelectedMoto.MotoId);
                },
                () =>
                {
                    return SelectedMoto != null;
                });
                SelectedMoto = new Moto();
                

            }
        }
    }

}
