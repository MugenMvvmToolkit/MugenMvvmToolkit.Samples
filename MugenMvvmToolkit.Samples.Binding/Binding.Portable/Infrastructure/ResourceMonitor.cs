using System;
using System.Collections.Generic;
using Binding.Portable.Interfaces;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Interfaces;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;

namespace Binding.Portable.Infrastructure
{
    /// <summary>
    ///     This class allows to monitor live binding instances.
    /// </summary>
    public class ResourceMonitor : NotifyPropertyChangedBase, IResourceMonitor
    {
        #region Nested types

        private sealed class ReferenceCollector
        {
            #region Fields

            private readonly ResourceMonitor _monitor;

            #endregion

            #region Constructors

            public ReferenceCollector(ResourceMonitor monitor)
            {
                _monitor = monitor;
            }

            #endregion

            #region Methods

            private static int Collect(List<WeakReference> references)
            {
                if (references.Count == 0)
                    return 0;
                int collectedCount = 0;
                lock (references)
                {
                    for (int i = 0; i < references.Count; i++)
                    {
                        if (references[i].Target == null)
                        {
                            ++collectedCount;
                            references.RemoveAt(i);
                        }
                    }
                }
                return collectedCount;
            }

            #endregion

            #region Destructor

            ~ReferenceCollector()
            {
                if (_monitor._finalized || Environment.HasShutdownStarted)
                    return;
                _monitor.CollectedBindingCount += Collect(_monitor._bindings);
                _monitor.CollectedViewCount += Collect(_monitor._views);
                _monitor.CollectedViewModelCount += Collect(_monitor._viewModels);
                GC.ReRegisterForFinalize(this);
            }

            #endregion
        }

        #endregion

        #region Fields

        private readonly IBindingManager _bindingManager;
        private readonly List<WeakReference> _bindings;
        private readonly List<WeakReference> _viewModels;
        private readonly List<WeakReference> _views;
        private int _bindingCount;
        private int _collectedBindingCount;
        private int _collectedViewCount;
        private int _collectedViewModelCount;
        private bool _finalized;
        private int _viewCount;
        private int _viewModelCount;

        #endregion

        #region Constructors

        public ResourceMonitor(IViewManager viewManager)
        {
            _bindingManager = BindingServiceProvider.BindingManager;
            BindingServiceProvider.BindingManager = this;

            _bindings = new List<WeakReference>();
            _viewModels = new List<WeakReference>();
            _views = new List<WeakReference>();
            viewManager.ViewInitialized += (manager, args) =>
            {
                lock (_views)
                    _views.Add(new WeakReference(args.View, true));
                ++ViewCount;
            };
            Tracer.TraceViewModelHandler += (auditAction, viewModel) =>
            {
                if (auditAction != ViewModelLifecycleType.Created)
                    return;
                lock (_viewModels)
                    _viewModels.Add(new WeakReference(viewModel, true));
                ++ViewModelCount;
            };
            // ReSharper disable once ObjectCreationAsStatement
            new ReferenceCollector(this);
        }

        #endregion

        #region Properties

        public int BindingCount
        {
            get { return _bindingCount; }
            private set
            {
                if (value == _bindingCount)
                    return;
                _bindingCount = value;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.LiveBindingCount);
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
                this.OnPropertyChanged(() => vm => vm.LiveBindingCount);
            }
        }

        public int LiveBindingCount => BindingCount - CollectedBindingCount;

        public int ViewCount
        {
            get { return _viewCount; }
            private set
            {
                if (value == _viewCount)
                    return;
                _viewCount = value;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.LiveViewCount);
            }
        }

        public int CollectedViewCount
        {
            get { return _collectedViewCount; }
            private set
            {
                if (value == _collectedViewCount)
                    return;
                _collectedViewCount = value;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.LiveViewCount);
            }
        }

        public int LiveViewCount => ViewCount - CollectedViewCount;

        public int ViewModelCount
        {
            get { return _viewModelCount; }
            private set
            {
                if (value == _viewModelCount)
                    return;
                _viewModelCount = value;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.LiveViewModelCount);
            }
        }

        public int CollectedViewModelCount
        {
            get { return _collectedViewModelCount; }
            private set
            {
                if (value == _collectedViewModelCount)
                    return;
                _collectedViewModelCount = value;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.LiveViewModelCount);
            }
        }

        public int LiveViewModelCount => ViewModelCount - CollectedViewModelCount;

        #endregion

        #region Implementation of IBindingManager

        public void Register(object target, string path, IDataBinding binding, IDataContext context = null)
        {
            _bindingManager.Register(target, path, binding, context);
            lock (_bindings)
                _bindings.Add(new WeakReference(binding, true));
            ++BindingCount;
        }

        public bool IsRegistered(IDataBinding binding)
        {
            return _bindingManager.IsRegistered(binding);
        }

        public ICollection<IDataBinding> GetBindings(object target, IDataContext context = null)
        {
            return _bindingManager.GetBindings(target, context);
        }

        public ICollection<IDataBinding> GetBindings(object target, string path, IDataContext context = null)
        {
            return _bindingManager.GetBindings(target, path, context);
        }

        public void Unregister(IDataBinding binding)
        {
            _bindingManager.Unregister(binding);
        }

        public void ClearBindings(object target, IDataContext context = null)
        {
            _bindingManager.ClearBindings(target, context);
        }

        public void ClearBindings(object target, string path, IDataContext context = null)
        {
            _bindingManager.ClearBindings(target, path, context);
        }

        #endregion

        #region Finalizers

        ~ResourceMonitor()
        {
            _finalized = true;
        }

        #endregion
    }
}