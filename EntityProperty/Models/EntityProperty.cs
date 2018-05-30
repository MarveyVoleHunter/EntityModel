using System;

namespace EntityModel.Models
{
    public class EntityProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TxId { get; set; }
        public int DisplayOrder { get; set; }
        //public string DataType { get; set; }
        public Type DataType { get; set; }
        public bool Required { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public int? MaxLength { get; set; }
        public object InitialValue { get; set; }
        public object Value { get; set; }
        //public virtual string ValueString { get; }
        public bool ValueIsNull { get; set; } = true;
        public object TestValue { get; set; }
        public bool Modified
        {
            get
            {
                return Value != InitialValue;
            }
        }
     }
}