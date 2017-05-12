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

        public IDisposable TryObserve(string member, IEventListener listener)
        {
            return null;
        }

        public object GetMember(string member, IList<object> args)
        {
            object value;
            _dynamicData.TryGetValue(member, out value);
            return value;
        }

        public void SetMember(string member, IList<object> args)
        {
            _dynamicData[member] = args[0];
            OnPropertyChanged(member);
        }

        public object InvokeMember(string member, IList<object> args, IList<Type> typeArgs, IDataContext context)
        {
            return $"Value from method({member}) {args[0]}";
        }

        public object GetIndex(IList<object> indexes, IDataContext context)
        {
            return "Value from index " + indexes[0];
        }

        public void SetIndex(IList<object> indexes, IDataContext context)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}