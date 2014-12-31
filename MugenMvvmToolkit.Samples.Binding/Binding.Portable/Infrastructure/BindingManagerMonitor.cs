using System;
using System.Collections.Generic;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace Binding.Portable.Infrastructure
{
    /// <summary>
    ///     This class allows to monitor live binding instances.
    /// </summary>
    public class BindingManagerMonitor : NotifyPropertyChangedBase, IBindingManagerMonitor
    {
        #region Nested types

        private sealed class BindingTracker
        {
            #region Fields

            private readonly BindingManagerMonitor _monitor;

            #endregion

            #region Constructors

            public BindingTracker(BindingManagerMonitor monitor)
            {
                _monitor = monitor;
            }

            #endregion

            #region Destructor

            ~BindingTracker()
            {
                if (_monitor._finalized || SuspendUpdate)
                    return;
                List<WeakReference> bindings = _monitor._bindings;
                int collectedCount = 0;
                lock (bindings)
                {
                    for (int i = 0; i < bindings.Count; i++)
                    {
                        if (bindings[i].Target == null)
                        {
                            ++collectedCount;
                            bindings.RemoveAt(i);
                        }
                    }
                }
                _monitor.CollectedBindingCount += collectedCount;
                GC.ReRegisterForFinalize(this);
            }

            #endregion
        }

        #endregion

        #region Fields

        private readonly IBindingManager _bindingManager;
        private readonly List<WeakReference> _bindings;
        private int _bindingCount;
        private int _collectedBindingCount;
        private bool _finalized;

        #endregion

        #region Constructors

        public BindingManagerMonitor(IBindingManager bindingManager)
        {
            _bindingManager = bindingManager;
            _bindings = new List<WeakReference>();
            // ReSharper disable once ObjectCreationAsStatement
            new BindingTracker(this);
        }

        #endregion

        #region Properties

        public static bool SuspendUpdate { get; set; }

        public int BindingCount
        {
            get { return _bindingCount; }
            private set
            {
                if (value == _bindingCount)
                    return;
                _bindingCount = value;
                OnPropertyChanged();
                OnPropertyChanged("LiveBindingCount");
            }
        }

        public int CollectedBindingCount
        {
            get { return _collectedBindingCount; }
            private set
            {
                if (value == _collectedBindingCount)
                    return;
                _collectedBindingCount = value;
                OnPropertyChanged();
                OnPropertyChanged("LiveBindingCount");
            }
        }

        public int LiveBindingCount
        {
            get { return BindingCount - CollectedBindingCount; }
        }

        #endregion

        #region Implementation of IBindingManager

        public void Register(object target, string path, IDataBinding binding, IDataContext context = null)
        {
            _bindingManager.Register(target, path, binding, context);
            lock (_bindings)
                _bindings.Add(ServiceProvider.WeakReferenceFactory(binding, true));
            ++BindingCount;
        }

        public bool IsRegistered(IDataBinding binding)
        {
            return _bindingManager.IsRegistered(binding);
        }

        public IEnumerable<IDataBinding> GetBindings(object target, IDataContext context = null)
        {
            return _bindingManager.GetBindings(target, context);
        }

        public IEnumerable<IDataBinding> GetBindings(object target, string path, IDataContext context = null)
        {
            return _bindingManager.GetBindings(target, path, context);
        }

        public void Unregister(IDataBinding binding)
        {
            _bindingManager.Unregister(binding);
        }

        public void ClearBindings(object target, IDataContext context = null)
        {
            IEnumerable<IDataBinding> dataBindings = GetBindings(target);
            int count = 0;
            lock (_bindings)
            {
                foreach (IDataBinding dataBinding in dataBindings)
                {
                    WeakReference find = _bindings.Find(reference => reference.Target == dataBinding);
                    if (find != null)
                        _bindings.Remove(find);
                    ++count;
                }
            }
            CollectedBindingCount += count;
            _bindingManager.ClearBindings(target, context);
        }

        public void ClearBindings(object target, string path, IDataContext context = null)
        {
            _bindingManager.ClearBindings(target, path, context);
        }

        #endregion

        #region Finalizers

        ~BindingManagerMonitor()
        {
            _finalized = true;
        }

        #endregion
    }
}