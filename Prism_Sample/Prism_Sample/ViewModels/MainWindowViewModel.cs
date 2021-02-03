using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Prism_Sample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        private string _returnText;
        public string ReturnText
        {
            get { return _returnText; }
            set { SetProperty(ref _returnText, value); }
        }

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
        public DelegateCommand ShowDialogBtnCmd { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService) : base()
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            First = 0;
            Second = 0;

            MessageBtnCmd = new DelegateCommand(ExecuteMessageBtnCmd);
            ShowSampleViewBtnCmd = new DelegateCommand(ExecuteShowSampleViewBtnCmd);
            CalulateBtnCmd = new DelegateCommand(ExecuteCalulateBtnCmd);
            ShowDialogBtnCmd = new DelegateCommand(ExecuteShowDialogBtnCmd);
        }

        private void ExecuteShowDialogBtnCmd()
        {
            _dialogService.ShowDialog("ShowDialogSample", ShowDialogSampleClosed);
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

        private void ShowDialogSampleClosed(IDialogResult dialogResult)
        {
            // ×ボタンなどが押された時もこの関数は実行されるため、
            // ちゃんと ButtonResult が何だったかのチェックを入れる必要がある
            if (dialogResult.Result == ButtonResult.OK)
            {
                ReturnText = dialogResult.Parameters.GetValue<string>(nameof(ShowDialogSampleViewModel.Text));
            }
        }
    }
}
