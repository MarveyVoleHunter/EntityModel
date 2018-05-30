using System.Collections.Generic;

namespace EntityModel.Models
{
    public class EntityPropertyCollection
    {
        public IEnumerable<EntityProperty> Properties { get; set;  }
        public string TableName { get; set; }
        public string PrimaryEntityColumnName { get; set; }
        public string PrimaryEntityTableName { get; set; }
        public IEnumerable<int> PrimaryEntityIds { get; set; }
        public string SecondaryEntityColumnName { get; set; }
        public string SecondaryEntityTableName { get; set; }
        public IEnumerable<int> SecondaryEntityIds { get; set; }
    }
}