using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand EditBrandCommand { get; set; }
        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        BrandName = value.BrandName,
                        BrandId = value.BrandId
                    };
                    
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RestCollection<Brand> Brands { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:38806/", "brand","hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        BrandName = SelectedBrand.BrandName
                     
                    }) ;
                });
                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.BrandId);

                },
                () =>
                {
                    return SelectedBrand != null;
                }
                );
                EditBrandCommand = new RelayCommand(
                    () =>
                    {
                        //selectedBrand.BrandName = SelectedBrand.BrandName;
                        //selectedBrand.trust_level = 5;
                        //selectedBrand.Category = "csodafon";
                        //selectedBrand.Rating = 5;

                        try
                        {
                            selectedBrand.BrandName = SelectedBrand.BrandName;
                            selectedBrand.trust_level =selectedBrand.trust_level;
                            selectedBrand.Category = selectedBrand.Category;
                            selectedBrand.Rating = selectedBrand.Rating;
                            
                            Brands.Update(SelectedBrand);

                            
                            
                        }
                        catch (ArgumentException ex)
                        {
                            ErrorMessage = ex.Message;
                        }
                    });
                SelectedBrand = new Brand();

            }
            
        }
    }
}
