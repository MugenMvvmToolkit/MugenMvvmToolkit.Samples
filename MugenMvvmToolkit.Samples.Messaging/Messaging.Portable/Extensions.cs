using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;

namespace Messaging.Portable
{
    public static class Extensions
    {
        #region Methods

        public static void TraceMessage(object recipient, object sender, object message)
        {
            ServiceProvider.IocContainer.Get<IMessagePresenter>()
                .ShowAsync(string.Format("The '{0}' from '{1}' is handled by '{2}'", message.GetType().Name,
                    sender.GetType().Name, recipient.GetType().Name));
        }

        #endregion

    }
}