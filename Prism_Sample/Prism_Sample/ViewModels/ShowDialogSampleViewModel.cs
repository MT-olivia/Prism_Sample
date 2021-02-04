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
        private IDialogService _dialogService;
        private Services.IMessageService _messageService;

        private string _labelText;
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

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand ReturnBtnCmd { get; private set; }

        public ShowDialogSampleViewModel(IDialogService dialogService) :this(dialogService, new Services.MessageService())
        {

        }

        public ShowDialogSampleViewModel(IDialogService dialogService, Services.IMessageService messageService)
        {
            _dialogService = dialogService;
            _messageService = messageService;
            LabelText = "別ウィンドウを開くサンプルです";

            ReturnBtnCmd = new DelegateCommand(ExecuteReturnBtnCmd);
        }

        private void ExecuteReturnBtnCmd()
        {
            if (_messageService.Question("値を戻しますか？") == System.Windows.MessageBoxResult.OK)
            {
                _messageService.ShowDialog("OK");

                var dp = new DialogParameters();
                dp.Add(nameof(Text), Text);

                // DialogResult の第1引数は、呼び出し元の画面に「何のボタンが押されたか？」を教えるためのもの
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, dp));
            }
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
