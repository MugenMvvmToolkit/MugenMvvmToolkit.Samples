using System.Collections.Generic;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace Binding.Portable.Models
{
    public class DynamicModel : NotifyPropertyChangedBase, IDynamicObject
    {
        #region Fields

        private readonly Dictionary<string, object> _dynamicData;

        #endregion

        #region Constructors

        public DynamicModel()
        {
            _dynamicData = new Dictionary<string, object>();
        }

        #endregion

        #region Implementation of IDynamicObject

        /// <summary>
        ///     Provides the implementation of getting a member.
        /// </summary>
        /// <returns>
        ///     The result of the get operation.
        /// </returns>
        public object GetMember(string member, IList<object> args)
        {
            object value;
            _dynamicData.TryGetValue(member, out value);
            return value;
        }

        /// <summary>
        ///     Provides the implementation of setting a member.
        /// </summary>
        public void SetMember(string member, IList<object> args)
        {
            _dynamicData[member] = args[0];
            OnPropertyChanged(member);
        }

        #endregion
    }
}