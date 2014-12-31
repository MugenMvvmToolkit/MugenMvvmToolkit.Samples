using System;
using System.Collections.Generic;
using System.Globalization;
using Binding.Portable.Interfaces;
using Binding.Portable.Resources;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces.Models;
using MugenMvvmToolkit.Binding.Models;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace Binding.Portable.Infrastructure
{
    public class LocalizationManager : NotifyPropertyChangedBase, ILocalizationManager, IDynamicObject
    {
        #region Implementation of ILocalizationManager

        public virtual void Initilaize()
        {
            //Register the current object as resource object with alias 'i18n' to use it in bindings '$i18n.MyResource'.
            BindingServiceProvider.ResourceResolver.AddObject("i18n", new BindingResourceObject(this));
        }

        public virtual void ChangeCulture(string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            LocalizableResources.Culture = cultureInfo;
            //Updating all properties.
            OnPropertyChanged(string.Empty);
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
        public virtual object GetMember(string member, IList<object> args)
        {
            return LocalizableResources.ResourceManager.GetString(member);
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