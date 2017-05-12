using System.Threading;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class ItemViewModel : ViewModelBase, IHasDisplayName
    {
        #region Fields

        private static int _counter;

        #endregion

        #region Constructors

        public ItemViewModel()
        {
            Id = Interlocked.Increment(ref _counter);
            DisplayName = Id.ToString();
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public int Id { get; }

        public string DisplayName { get; }

        #endregion
    }
}