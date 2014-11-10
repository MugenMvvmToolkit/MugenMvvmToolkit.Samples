using System;
using System.Runtime.Serialization;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
    [DataContract]
    public class ViewModelCommandParameter
    {
        #region Constructors

        public ViewModelCommandParameter(Type viewModelType, IDataContext context = null)
        {
            ViewModelType = viewModelType;
            Context = context;
        }

        public ViewModelCommandParameter(Type viewModelType, string viewName)
        {
            ViewModelType = viewModelType;
            Context = new DataContext(NavigationConstants.ViewName.ToValue(viewName));
        }

        #endregion

        #region Properties

        [DataMember(Name = "ViewModelType")]
        public string ViewModelTypeName
        {
            get { return ViewModelType.AssemblyQualifiedName; }
            set { ViewModelType = Type.GetType(value, true); }
        }

        [IgnoreDataMember]
        public Type ViewModelType { get; private set; }

        [IgnoreDataMember]
        public IDataContext Context { get; private set; }

        #endregion
    }
}