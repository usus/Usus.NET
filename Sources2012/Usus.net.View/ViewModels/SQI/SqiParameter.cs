using System;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SqiParameter : ViewModel
    {
        public SqiParameter(string parameter)
        {
            Parameter = parameter;
        }

        public string Parameter { get; private set; }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                Changed(() => Value);
            }
        }
    }
}
