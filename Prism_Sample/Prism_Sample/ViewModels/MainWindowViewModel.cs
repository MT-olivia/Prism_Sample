using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Prism_Sample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand MessageBtnCmd { get; private set; }
        public DelegateCommand ShowSampleViewBtnCmd { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager) : base()
        {
            _regionManager = regionManager;

            MessageBtnCmd = new DelegateCommand(ExecuteMessageBtnCmd);
            ShowSampleViewBtnCmd = new DelegateCommand(ExecuteShowSampleViewBtnCmd);
        }

        private void ExecuteShowSampleViewBtnCmd()
        {
            _regionManager.RequestNavigate("ContentRegion", "SampleView");
        }

        private void ExecuteMessageBtnCmd()
        {
            throw new NotImplementedException();
        }
    }
}
