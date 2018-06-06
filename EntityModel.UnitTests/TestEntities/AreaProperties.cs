using System;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class AreaProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "Area",
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty
                {
                    Id = 29,
                    Name = "Name",
                    DataType = typeof(string),
                    DisplayOrder = 10,
                    Required = true,
                    TxId = 10,
                    Value = "Manchester"
                },
                new EntityProperty
                {
                    Id = 22,
                    Name = "ImportCode",
                    DataType = typeof(string),
                    DisplayOrder = 11,
                    Required = true,
                    TxId = 11,
                    Value = "A5"
                },
                new EntityProperty
                {
                    Id = 25,
                    Name = "ManagerName",
                    DataType = typeof(string),
                    DisplayOrder = 62,
                    Required = false,
                    TxId = 62,
                    Value = "Joe Bloggs"
                },
                new EntityProperty
                {
                    Id = 26,
                    Name = "ManagerPhone",
                    DataType = typeof(string),
                    DisplayOrder = 63,
                    Required = false,
                    TxId = 63
                },
                new EntityProperty
                {
                    Id = 23,
                    Name = "ManagerEmail",
                    DataType = typeof(string),
                    DisplayOrder = 64,
                    Required = false,
                    TxId = 64,
                    Value = "jblogs@kalibrate.com"
                },
                new EntityProperty
                {
                    Id = 24,
                    Name = "ManagerFax",
                    DataType = typeof(string),
                    DisplayOrder = 65,
                    Required = false,
                    TxId = 65,
                    Value = "0123456789"
                },
                new EntityProperty
                {
                    Id = 27,
                    Name = "ManagerSMS",
                    DataType = typeof(string),
                    DisplayOrder = 66,
                    Required = false,
                    TxId = 66
                },
                new EntityProperty
                {
                    Id = 28,
                    Name = "ManagerUserUID",
                    DataType = typeof(Guid),
                    DisplayOrder = 67,
                    Required = false,
                    TxId = 67,
                    RelationTypeId = "USER",
                    Value = new Guid("A45083AC-9D5E-46CC-BD3A-53A2F25553F4")
                },
                new EntityProperty
                {
                    Id = 17,
                    Name = "ExportSubject",
                    DataType = typeof(string),
                    DisplayOrder = 10,
                    Required = false,
                    TxId = 10
                },
                new EntityProperty
                {
                    Id = 30,
                    Name = "UseEmail",
                    DataType = typeof(bool),
                    DisplayOrder = 20,
                    Required = false,
                    TxId = 20,
                    Value = true
                },
                new EntityProperty
                {
                    Id = 18,
                    Name = "FormatTemplateEmailUID",
                    DataType = typeof(Guid),
                    DisplayOrder = 30,
                    Required = false,
                    TxId = 30,
                    Value = "71E2C96D-D865-44BE-80B0-91F5118B76A5"
                },
                new EntityProperty
                {
                    Id = 31,
                    Name = "UseFax",
                    DataType = typeof(bool),
                    DisplayOrder = 40,
                    Required = false,
                    TxId = 40,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 19,
                    Name = "FormatTemplateFaxUID",
                    DataType = typeof(Guid),
                    DisplayOrder = 50,
                    Required = false,
                    TxId = 50,
                    Value = new Guid("5659ACC1-324E-4356-BA43-DD58CF8C052C")
                }
            };
            
            return propertyCollection;
        }
    }
}
