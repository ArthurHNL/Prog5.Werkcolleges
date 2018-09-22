/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:EFWPF.Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using EFWPF.Repository.Abstract;
using EFWPF.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace EFWPF.Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            // IoC Container 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Repositories registreren
            SimpleIoc.Default.Register<IProductRepository, ProductRepository>();
            SimpleIoc.Default.Register<IPersonRepository, PersonRepository>();

            // ViewModels Registreren
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();

        }

        /// <summary>
        /// MainViewModel voor de hoofdpagina.
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Als een View een PersonViewModel nodig heeft, gebruik je in de binding PeopleVM
        /// </summary>
        public PersonViewModel PeopleVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}