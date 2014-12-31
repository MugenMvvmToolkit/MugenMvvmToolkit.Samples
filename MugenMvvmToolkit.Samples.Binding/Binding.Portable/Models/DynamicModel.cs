using System;
using System.Collections.Generic;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Models;
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
        ///     Attempts to track the value change.
        /// </summary>
        public IDisposable TryObserve(string member, IEventListener listener)
        {
            return null;
        }

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

        /// <summary>
        ///     Provides the implementation of calling a member.
        /// </summary>
        public object InvokeMember(string member, IList<object> args, IList<Type> typeArgs, IDataContext context)
        {
            return string.Format("Value from method({0}) {1}", member, args[0]);
        }

        /// <summary>
        ///     Provides the implementation of performing a get index operation.
        /// </summary>
        public object GetIndex(IList<object> indexes, IDataContext context)
        {
            return "Value from index " + indexes[0];
        }

        /// <summary>
        ///     Provides the implementation of performing a set index operation.
        /// </summary>
        public void SetIndex(IList<object> indexes, IDataContext context)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}