namespace ApiExamples.Models
{
    public class ListItemModel
    {
        #region Properties

        public string Value
        {
            get { return IsValid ? "Valid value" : "Invalid value"; }
        }

        public bool IsValid { get; set; }

        #endregion
    }
}