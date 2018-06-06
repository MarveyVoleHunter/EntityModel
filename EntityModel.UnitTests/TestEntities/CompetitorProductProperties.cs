using System;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class CompetitorProductProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "CompetitorProduct",
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty                {                    Id = 84,                    Name = "Active",                    DisplayOrder = 2,                    Required = true,                    TxId = 2,                    Value = true                },
                new EntityProperty                {                    Id = 85,                    Name = "CardPriceDiscount",                    DisplayOrder = 11,                    Required = true,                    TxId = 11,                    Value = 0.00m                },
                new EntityProperty                {                    Id = 86,                    Name = "CompetitorSiteUID",                    DisplayOrder = 1,                    Required = true,                    TxId = 1,                    Value = new Guid("A7932646-918F-40DC-AE87-072A4EF994E3")                },
                new EntityProperty                {                    Id = 89,                    Name = "GlobalProductUID",                    DisplayOrder = 1,                    Required = true,                    TxId = 1,                    Value = new Guid("26B4AF2D-AC09-48D2-AB77-4A44350104C2")                },
                new EntityProperty                {                    Id = 91,                    Name = "InStock",                    DisplayOrder = 3,                    Required = true,                    TxId = 3,                    Value = false                },
                new EntityProperty                {                    Id = 92,                    Name = "MaxListPricePercentage",                    DisplayOrder = 2,                    Required = true,                    TxId = 2,                    Value = 0.00m                },
                new EntityProperty                {                    Id = 93,                    Name = "MaxPrice",                    DisplayOrder = 5,                    Required = true,                    TxId = 5,                    Value = 3.40m                },
                new EntityProperty                {                    Id = 94,                    Name = "MaxPriceDecrement",                    DisplayOrder = 6,                    Required = true,                    TxId = 6,                    Value = 0.00m                },
                new EntityProperty                {                    Id = 95,                    Name = "MaxPriceIncrement",                    DisplayOrder = 7,                    Required = true,                    TxId = 7,                    Value = 0.00m                },
                new EntityProperty                {                    Id = 96,                    Name = "MinListPricePercentage",                    DisplayOrder = 1,                    Required = true,                    TxId = 1,                    Value = 0.00m                },
                new EntityProperty                {                    Id = 97,                    Name = "MinPrice",                    DisplayOrder = 4,                    Required = true,                    TxId = 4,                    Value = 1.00m                },
                new EntityProperty                {                    Id = 98,                    Name = "NearestOwnSiteUID",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 102,                    Name = "SurveyPossible",                    DisplayOrder = 12,                    Required = true,                    TxId = 12,                    Value = false                }
            };

            return propertyCollection;
        }
    }
 }
