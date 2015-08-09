﻿using System.Windows.Forms;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Infrastructure;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.WinForms.Binding;

namespace OrderManager.WinForms.Templates
{
    public class ViewModelTabDataTemplate : DataTemplateSelectorBase<IViewModel, TabPage>
    {
        #region Fields

        public static readonly ViewModelTabDataTemplate Instance = new ViewModelTabDataTemplate();

        #endregion

        #region Constructors

        private ViewModelTabDataTemplate()
        {
        }

        #endregion

        #region Overrides of DataTemplateSelectorBase<IViewModel,TabPage>

        protected override TabPage SelectTemplate(IViewModel item, object container)
        {
            return new TabPage();
        }

        protected override void Initialize(TabPage template, BindingSet<TabPage, IViewModel> bindingSet)
        {
            bindingSet.Bind(AttachedMembers.Control.Content)
                      .To(() => m => m);
            bindingSet.Bind(() => v => v.Text)
                      .To(() => m => ((IHasDisplayName)m).DisplayName);
            bindingSet.Bind(AttachedMembersEx.Control.IsBusy)
                      .To(() => m => m.IsBusy);
            bindingSet.Bind(AttachedMembersEx.Control.BusyMessage)
                      .To(() => m => m.BusyMessage);
        }

        #endregion
    }
}