using System;

namespace EntityModel.Models
{
    public class EntityProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TxId { get; set; }
        public int DisplayOrder { get; set; }
        public Type DataType { get; set; }
        public string RelationTypeId { get; set; }
        public bool Required { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public int? MaxLength { get; set; }
        public object InitialValue { get; set; }
        public object Value { get; set; }
        public bool IsModified
        {
            get
            {
                return Value != InitialValue;
            }
        }
     }
}