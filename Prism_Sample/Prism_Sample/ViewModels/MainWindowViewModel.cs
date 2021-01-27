using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace Prism_Sample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public DelegateCommand MessageBtnCmd { get; private set; }

        public MainWindowViewModel() : base()
        {
            MessageBtnCmd = new DelegateCommand(ExecuteMessageBtnCmd);
        }

        private void ExecuteMessageBtnCmd()
        {
            throw new NotImplementedException();
        }
    }
}
