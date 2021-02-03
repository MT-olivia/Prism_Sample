using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism_Sample.ViewModels
{
    public class AddCalcViewModel : BindableBase, INavigationAware
    {
        private int _first;
        public int FirstArg
        {
            get { return _first; }
            set { SetProperty(ref _first, value); }
        }

        private int _second;
        public int SecondArg
        {
            get { return _second; }
            set { SetProperty(ref _second, value); }
        }

        public int Result
        {
            get { return FirstArg + SecondArg; }
        }

        public AddCalcViewModel()
        {

        }

        /// <summary>
        /// ナビゲーションがこのコントロールに移ってきた際に実行される関数。
        /// </summary>
        /// <param name="navigationContext">パラメータを受け取りたい場合は、コレから取得できる</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            FirstArg = navigationContext.Parameters.GetValue<int>(nameof(FirstArg));
            SecondArg = navigationContext.Parameters.GetValue<int>(nameof(SecondArg));
        }

        /// <summary>
        /// インスタンスを使いまわすか否かを返す。前回の値を覚えておきたいときは true を指定する。
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>使いまわすときは true</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// ナビゲーションが他のコントロールに移る際に実行される関数。終了処理が必要な場合はここに実装する。
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
