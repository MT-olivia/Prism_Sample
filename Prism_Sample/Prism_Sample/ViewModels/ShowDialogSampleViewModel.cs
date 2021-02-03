using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism_Sample.ViewModels
{
    public class ShowDialogSampleViewModel : BindableBase, IDialogAware
    {
        private string _labelText;

        public event Action<IDialogResult> RequestClose;

        public string LabelText
        {
            get { return _labelText; }
            set { SetProperty(ref _labelText, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string Title => "Dialog";

        public DelegateCommand ReturnBtnCmd { get; private set; }

        public ShowDialogSampleViewModel()
        {
            LabelText = "別ウィンドウを開くサンプルです";

            ReturnBtnCmd = new DelegateCommand(ExecuteReturnBtnCmd);
        }

        private void ExecuteReturnBtnCmd()
        {
            var dp = new DialogParameters();
            dp.Add(nameof(Text), Text);

            // DialogResult の第1引数は、呼び出し元の画面に「何のボタンが押されたか？」を教えるためのもの
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, dp));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
