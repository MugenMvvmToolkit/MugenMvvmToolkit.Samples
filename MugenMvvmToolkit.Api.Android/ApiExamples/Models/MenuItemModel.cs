using System.Collections.Generic;

namespace ApiExamples.Models
{
    public class MenuItemModel
    {
        #region Properties

        public string Name { get; set; }

        public bool HasSubMenu => Items != null && Items.Count != 0;

        public IList<MenuItemModel> Items { get; set; }

        #endregion
    }
}