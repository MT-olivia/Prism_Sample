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

        private int _first;
        public int First
        {
            get { return _first; }
            set { SetProperty(ref _first, value); }
        }

        private int _second;
        public int Second
        {
            get { return _second; }
            set { SetProperty(ref _second, value); }
        }

        public DelegateCommand MessageBtnCmd { get; private set; }
        public DelegateCommand ShowSampleViewBtnCmd { get; private set; }
        public DelegateCommand CalulateBtnCmd { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager) : base()
        {
            _regionManager = regionManager;

            First = 0;
            Second = 0;

            MessageBtnCmd = new DelegateCommand(ExecuteMessageBtnCmd);
            ShowSampleViewBtnCmd = new DelegateCommand(ExecuteShowSampleViewBtnCmd);
            CalulateBtnCmd = new DelegateCommand(ExecuteCalulateBtnCmd);
        }

        private void ExecuteCalulateBtnCmd()
        {
            var np = new NavigationParameters();
            np.Add(nameof(AddCalcViewModel.FirstArg), First);
            np.Add(nameof(AddCalcViewModel.SecondArg), Second);
            _regionManager.RequestNavigate("ContentRegion", "AddCalc", np);
        }

        private void ExecuteShowSampleViewBtnCmd()
        {
            _regionManager.RequestNavigate("ContentRegion", "Sample");
        }

        private void ExecuteMessageBtnCmd()
        {
            throw new NotImplementedException();
        }
    }
}
