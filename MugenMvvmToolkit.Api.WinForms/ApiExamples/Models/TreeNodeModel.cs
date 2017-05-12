using System.Collections.Generic;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
    public class TreeNodeModel : NotifyPropertyChangedBase
    {
        #region Fields

        private bool _isValid;
        private string _name;

        #endregion

        #region Constructors

        public TreeNodeModel(TreeNodeModel parent = null)
        {
            Parent = parent;
            Nodes = new SynchronizedNotifiableCollection<TreeNodeModel>();
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name)
                    return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                if (value == _isValid)
                    return;
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public TreeNodeModel Parent { get; set; }

        public IList<TreeNodeModel> Nodes { get; }

        #endregion
    }
}