using Caliburn.Micro;
using CSC343_calculator.ViewModels;
using System.Windows;

namespace CSC343_calculator
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
       
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<TopViewModel>();
        }
    }
}
