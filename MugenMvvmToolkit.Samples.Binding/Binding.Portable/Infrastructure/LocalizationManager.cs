using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace Binding.Portable.Infrastructure
{
    public class LocalizationManager : NotifyPropertyChangedBase, ILocalizationManager, IDynamicObject
    {
        #region Fields

        public const string ResourceName = "i18n";
        private static readonly ResourceManager Resorces = new ResourceManager("Binding.Portable.Resources.LocalizableResources", typeof(LocalizationManager).GetTypeInfo().Assembly);
        private CultureInfo _culture;

        #endregion

        #region Constructors

        public LocalizationManager()
        {
            //Register the current object as resource object with alias 'i18n' to use it in bindings '$i18n.MyResource'.
            BindingServiceProvider.ResourceResolver.AddObject(ResourceName, new BindingResourceObject(this, true));
        }

        #endregion

        #region Implementation of interfaces

        #region Implementation of ILocalizationManager

        public virtual void ChangeCulture(string culture)
        {
            _culture = new CultureInfo(culture);
            InvalidateProperties();
        }

        #endregion

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
        public virtual object GetMember(string member, IList<object> args)
        {
            return Resorces.GetString(member, _culture);
        }

        /// <summary>
        ///     Provides the implementation of setting a member.
        /// </summary>
        public void SetMember(string member, IList<object> args)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Provides the implementation of calling a member.
        /// </summary>
        public object InvokeMember(string member, IList<object> args, IList<Type> typeArgs, IDataContext context)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        ///     Provides the implementation of performing a get index operation.
        /// </summary>
        public object GetIndex(IList<object> indexes, IDataContext context)
        {
            throw new NotSupportedException();
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