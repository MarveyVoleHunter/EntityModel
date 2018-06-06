using System;
using EntityModel.Models;

namespace EntityModel
{
    public class NetworkProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "Network",
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty
                {
                    Id = 405,
                    Name = "ImportCode",
                    DisplayOrder = 20,
                    Required = true,
                    TxId = 20,
                    Value = "A12"
                },
                new EntityProperty
                {
                    Id = 406,
                    Name = "ManagerEmail",
                    DisplayOrder = 40,
                    Required = false,
                    TxId = 40,
                    Value = ""
                },
                new EntityProperty
                {
                    Id = 407,
                    Name = "ManagerName",
                    DisplayOrder = 30,
                    Required = false,
                    TxId = 30,
                },
                new EntityProperty
                {
                    Id = 408,
                    Name = "ManagerSMS",
                    DisplayOrder = 50,
                    Required = false,
                    TxId = 50,
                },
                new EntityProperty
                {
                    Id = 409,
                    Name = "ManagerUserUID",
                    DisplayOrder = 51,
                    Required = false,
                    TxId = 51,
                },
                new EntityProperty
                {
                    Id = 410,
                    Name = "Name",
                    DisplayOrder = 10,
                    Required = true,
                    TxId = 10,
                    Value = "East2"
                }
            };
            return propertyCollection;
        }
    }
}