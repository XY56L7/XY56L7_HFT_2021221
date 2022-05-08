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
        public ICommand CreateOSCommand { get; set; }
        public ICommand DeleteOSCommand { get; set; }
        public ICommand EditOSCommand { get; set; }

        public ICommand CreatePhoneCommand { get; set; }
        public ICommand DeletePhoneCommand { get; set; }
        public ICommand EditPhoneCommand { get; set; }
        private Brand selectedBrand;
        private OSYSTEM selectedOS;
        private Phone selectedPhone;

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
        public OSYSTEM SelectedOS
        {
            get { return selectedOS; }
            set
            {
                if (value != null)
                {
                    selectedOS = new OSYSTEM()
                    {
                        OS = value.OS,
                        OSId = value.OSId
                    };

                    OnPropertyChanged();
                    (DeleteOSCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                if (value != null)
                {
                    selectedPhone = new Phone()
                    {
                        PhoneName = value.PhoneName,
                        PhoneId = value.PhoneId
                    };

                    OnPropertyChanged();
                    (DeletePhoneCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<OSYSTEM> OSS { get; set; }
        public RestCollection<Phone> Phones { get; set; }
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
            
                    OSS = new RestCollection<OSYSTEM>("http://localhost:38806/", "OSYSTEM", "hub");
                Brands = new RestCollection<Brand>("http://localhost:38806/", "brand", "hub");
                Phones = new RestCollection<Phone>("http://localhost:38806/", "phone", "hub");
                CreatePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Add(new Phone()
                    {
                        PhoneName = SelectedPhone.PhoneName

                    });
                });
                DeletePhoneCommand = new RelayCommand(() =>
                {
                    Phones.Delete(SelectedPhone.PhoneId);

                },
                   () =>
                   {
                       return SelectedPhone != null;
                   }
                   );

                EditPhoneCommand = new RelayCommand(
                       () =>
                       {


                           try
                           {

                               Phones.Update(SelectedPhone);



                           }
                           catch (ArgumentException ex)
                           {
                               ErrorMessage = ex.Message;
                           }
                       });











                CreateOSCommand = new RelayCommand(() =>
                {
                    OSS.Add(new OSYSTEM()
                    {
                        OS = SelectedOS.OS

                    });
                });
                DeleteOSCommand = new RelayCommand(() =>
                {
                    OSS.Delete(SelectedOS.OSId);

                },
                   () =>
                   {
                       return SelectedOS != null;
                   }
                   );

                EditOSCommand = new RelayCommand(
                       () =>
                       {


                           try
                           {

                               OSS.Update(SelectedOS);



                           }
                           catch (ArgumentException ex)
                           {
                               ErrorMessage = ex.Message;
                           }
                       });
                CreateBrandCommand = new RelayCommand(() =>
                    {
                        Brands.Add(new Brand()
                        {
                            BrandName = SelectedBrand.BrandName

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

        
                EditBrandCommand = new RelayCommand(
                        () =>
                        {


                            try
                            {
                                selectedBrand.BrandName = SelectedBrand.BrandName;
                                selectedBrand.trust_level = selectedBrand.trust_level;
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
                SelectedOS = new OSYSTEM();

         
               
            }
               
            
        }
    }
}
