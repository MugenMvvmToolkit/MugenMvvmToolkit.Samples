using System;
using MugenMvvmToolkit.DataConstants;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace ApiExamples.Models
{
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

        public Type ViewModelType { get; }

        public IDataContext Context { get; }

        #endregion
    }
}