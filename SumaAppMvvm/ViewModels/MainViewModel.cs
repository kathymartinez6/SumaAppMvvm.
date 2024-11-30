using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SumaAppMvvm_.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _value1;
        private string _value2;
        private string _result;
        private string _errorMessage;

        public string Value1
        {
            get => _value1;
            set
            {
                _value1 = value;
                OnPropertyChanged();
            }
        }

        public string Value2
        {
            get => _value2;
            set
            {
                _value2 = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SumCommand { get; }
        public ICommand ClearCommand { get; }

        public MainViewModel()
        {
            SumCommand = new Command(ExecuteSum);
            ClearCommand = new Command(ExecuteClear);
        }

        private void ExecuteSum(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteSum()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Value1) || string.IsNullOrWhiteSpace(Value2))
            {
                ErrorMessage = "Por favor, complete ambos campos.";
                return;
            }

            if (double.TryParse(Value1, out double num1) && double.TryParse(Value2, out double num2))
            {
                Result = (num1 + num2).ToString();
            }
            else
            {
                ErrorMessage = "Ingrese valores numéricos válidos.";
            }
        }

        private void ExecuteClear()
        {
            Value1 = string.Empty;
            Value2 = string.Empty;
            Result = string.Empty;
            ErrorMessage = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
