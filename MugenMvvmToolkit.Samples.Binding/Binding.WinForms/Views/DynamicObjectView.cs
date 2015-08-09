﻿using System.Windows.Forms;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.Binding.Extensions.Syntax;

namespace Binding.WinForms.Views
{
    public partial class DynamicObjectView : Form
    {
        public DynamicObjectView()
        {
            InitializeComponent();

            using (var set = new BindingSet<DynamicObjectViewModel>())
            {
                set.Bind(dynamicTb, () => t => t.Text)
                    .To(() => vm => vm.DynamicModel.Member<object>("DynamicProperty"))
                    .TwoWay();
                set.Bind(dynamicLabel, () => l => l.Text)
                    .To(() => vm => vm.DynamicModel.Member<object>("DynamicProperty"));
                set.BindFromExpression(methodLabel, "Text DynamicModel.DynamicMethod(DynamicModel.DynamicProperty)");
                set.BindFromExpression(indexLabel, "Text DynamicModel[DynamicModel.DynamicProperty]");
            }
        }
    }
}