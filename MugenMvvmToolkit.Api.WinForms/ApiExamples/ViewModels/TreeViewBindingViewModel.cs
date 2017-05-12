using System.Collections.Specialized;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TreeViewBindingViewModel : ViewModelBase
    {
        #region Fields

        private TreeNodeModel _selectedNode;

        #endregion

        #region Constructors

        public TreeViewBindingViewModel()
        {
            Nodes = new SynchronizedNotifiableCollection<TreeNodeModel>
            {
                new TreeNodeModel {Name = "Node 1", IsValid = true},
                new TreeNodeModel {Name = "Node 2", IsValid = true}
            };
            Nodes[0].Nodes.Add(new TreeNodeModel(Nodes[0]) {Name = "Node 1.1"});
            Nodes[1].Nodes.Add(new TreeNodeModel(Nodes[1]) {Name = "Node 2.1"});
            Nodes.CollectionChanged += NodesOnCollectionChanged;
            AddNodeCommand = new RelayCommand(AddNode);
            RemoveNodeCommand = new RelayCommand(RemoveNode, CanRemoveNode, this);
        }

        #endregion

        #region Properties

        public TreeNodeModel SelectedNode
        {
            get { return _selectedNode; }
            set
            {
                if (value == _selectedNode)
                    return;
                _selectedNode = value;
                OnPropertyChanged();
            }
        }

        public SynchronizedNotifiableCollection<TreeNodeModel> Nodes { get; }

        #endregion

        #region Methods

        private void NodesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (Nodes.Count == 0)
                SelectedNode = null;
        }

        #endregion

        #region Commands

        public ICommand AddNodeCommand { get; }

        public ICommand RemoveNodeCommand { get; }

        private void AddNode(object arg)
        {
            var node = new TreeNodeModel(SelectedNode) {Name = "New node"};
            if (node.Parent == null)
                Nodes.Add(node);
            else
                node.Parent.Nodes.Add(node);
        }

        private void RemoveNode(object arg)
        {
            if (SelectedNode.Parent == null)
                Nodes.Remove(SelectedNode);
            else
                SelectedNode.Parent.Nodes.Remove(SelectedNode);
        }

        private bool CanRemoveNode(object arg)
        {
            return SelectedNode != null;
        }

        #endregion
    }
}