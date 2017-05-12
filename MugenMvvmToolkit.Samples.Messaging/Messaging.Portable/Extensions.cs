using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;

namespace Messaging.Portable
{
    public static class Extensions
    {
        #region Methods

        public static void TraceMessage(object recipient, object sender, object message)
        {
            ServiceProvider.IocContainer
                .Get<IMessagePresenter>()
                .ShowAsync($"The '{message.GetType().Name}' from '{sender.GetType().Name}' is handled by '{recipient.GetType().Name}'");
        }

        #endregion
    }
}