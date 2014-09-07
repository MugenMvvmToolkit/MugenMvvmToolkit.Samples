using MugenMvvmToolkit.Models;

namespace Validation.Portable
{
    public static class ValidationDataConstants
    {
        #region Fields

        public static readonly DataConstant<string> CustomError = DataConstant.Create(() => CustomError, true);

        #endregion
    }
}