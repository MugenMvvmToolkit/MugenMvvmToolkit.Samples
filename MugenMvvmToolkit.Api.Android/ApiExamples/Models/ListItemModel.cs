namespace ApiExamples.Models
{
    public class ListItemModel
    {
        #region Properties

        public string Value => IsValid ? "Valid value" : "Invalid value";

        public bool IsValid { get; set; }

        #endregion
    }
}