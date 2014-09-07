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

        public int Id { get; private set; }

        #endregion

        #region Implementation of IHasDisplayName

        /// <summary>
        /// Gets or sets the display name for the current model.
        /// </summary>
        public string DisplayName { get; set; }

        #endregion
    }
}