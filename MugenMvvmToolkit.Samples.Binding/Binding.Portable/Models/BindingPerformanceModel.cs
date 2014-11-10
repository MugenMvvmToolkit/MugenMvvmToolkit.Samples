using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Binding.Portable.Models
{
    public class BindingPerformanceModel : INotifyPropertyChanged
    {
        #region Fields

        private string _property;
        //to keep target alive.
        private readonly object _target;

        #endregion

        #region Constructors

        public BindingPerformanceModel(object target)
        {
            _target = target;
        }

        #endregion

        #region Properties

        public int SetCount { get; set; }

        public string Property
        {
            get { return _property; }
            set
            {
                if (Equals(_property, value))
                    return;
                _property = value;
                OnPropertyChanged();
                SetCount++;
            }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}