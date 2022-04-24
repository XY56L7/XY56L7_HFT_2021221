using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand EditBrandCommand { get; set; }
        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set { 
                SetProperty(ref selectedBrand, value);
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
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
                Brands = new RestCollection<Brand>("http://localhost:38806/", "brand");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        BrandName = "Kiss Béla",
                        Rating = 4,
                        trust_level = 4
                    });
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
            }
            
        }
    }
}
