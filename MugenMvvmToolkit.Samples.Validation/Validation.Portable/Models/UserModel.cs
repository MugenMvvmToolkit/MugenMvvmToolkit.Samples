using MugenMvvmToolkit.Models;

namespace Validation.Portable.Models
{
    public class UserModel : NotifyPropertyChangedBase
    {
        #region Fields

        private string _email;
        private string _login;
        private string _name;

        #endregion

        #region Properties

        public string Login
        {
            get { return _login; }
            set
            {
                if (Equals(value, _login)) return;
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (Equals(value, _name)) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (Equals(value, _email)) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}