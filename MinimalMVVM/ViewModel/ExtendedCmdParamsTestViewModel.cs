using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;


namespace MinimalMVVM.ViewModel
{
    public class ExtendedCmdParamsTestViewModel : ObservableObject
    {
        
        private string _someText;
        private readonly ObservableCollection<string> _params = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> Params
        {
            get { return _params; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        private void ConvertText(object parameter)
        {

            _params.Clear();

            _params.Add("TextBox = "+ SomeText);
            var extendedParam = parameter as ExtendedCommandParam;
            if (extendedParam != null)
            {
                extendedParam.InternalDico.ToList().ForEach(item=>_params.Add(item.Value==null ? item.Key + "= null" : item.Key+"="+item.Value.ToString()));
            }
            //SomeText = String.Empty;
        }

        
    }
}
