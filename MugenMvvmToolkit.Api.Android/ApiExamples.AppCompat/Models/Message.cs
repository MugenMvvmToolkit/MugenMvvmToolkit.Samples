using System.Windows.Input;

namespace ApiExamples.Models
{
    public class Message
    {
        #region Properties

        public string Text { get; set; }

        public string ActionTitle { get; set; }

        public ICommand Command { get; set; }

        #endregion
    }
}