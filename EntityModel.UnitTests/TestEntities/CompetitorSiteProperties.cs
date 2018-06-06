using System;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class CompetitorSiteProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "CompetitorSite",
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty                {                    Id = 117,                    Name = "ImportCode",                    DisplayOrder = 2,                    Required = true,                    TxId = 2,                 Value = "C999"                },
                new EntityProperty                {                    Id = 121,                    Name = "Name",                    DisplayOrder = 1,                    Required = true,                    TxId = 1,                 Value = "CompetitorSite001"                },
                new EntityProperty                {                    Id = 104,                    Name = "Address",                    DisplayOrder = 55,                    Required = false,                    TxId = 55,                },
                new EntityProperty                {                    Id = 105,                    Name = "Address2",                    DisplayOrder = 56,                    Required = false,                    TxId = 56,                },
                new EntityProperty                {                    Id = 106,                    Name = "Address3",                    DisplayOrder = 57,                    Required = false,                    TxId = 57,                },
                new EntityProperty                {                    Id = 107,                    Name = "Address4",                    DisplayOrder = 58,                    Required = false,                    TxId = 58,                },
                new EntityProperty                {                    Id = 108,                    Name = "Address5",                    DisplayOrder = 59,                    Required = false,                    TxId = 59,                },
                new EntityProperty                {                    Id = 127,                    Name = "PostCode",                    DisplayOrder = 60,                    Required = false,                    TxId = 60,                },
                new EntityProperty                {                    Id = 115,                    Name = "Country",                    DisplayOrder = 61,                    Required = false,                    TxId = 61,                },
                new EntityProperty                {                    Id = 136,                    Name = "TimeZoneID",                    DisplayOrder = 62,                    Required = true,                    TxId = 62,                    Value = 36                },
                new EntityProperty                {                    Id = 111,                    Name = "BrandUID",                    DisplayOrder = 10,                    Required = true,                    TxId = 10,                    Value = new Guid("120306FD-64EA-4C5A-A93B-AC32FEDAF9D3")                },
                new EntityProperty                {                    Id = 112,                    Name = "CompetitorGroupUID",                    DisplayOrder = 15,                    Required = true,                    TxId = 15,                    Value = new Guid("4F7B3AF0-F4F9-4FEC-9A1C-69B31B040A16")                },
                new EntityProperty                {                    Id = 109,                    Name = "AreaUID",                    DisplayOrder = 12,                    Required = false,                    TxId = 12,                },
                new EntityProperty                {                    Id = 122,                    Name = "Percentile",                    DisplayOrder = 10,                    Required = false,                    TxId = 10,                    Value = 0                },
                new EntityProperty                {                    Id = 124,                    Name = "PercentileMinutes",                    DisplayOrder = 50,                    Required = false,                    TxId = 50,                },
                new EntityProperty                {                    Id = 123,                    Name = "PercentileExcludeCompetitor",                    DisplayOrder = 20,                    Required = true,                    TxId = 20,                    Value = false                },
                new EntityProperty                {                    Id = 125,                    Name = "PercentileRoundDown",                    DisplayOrder = 40,                    Required = true,                    TxId = 40,                    Value = false                },
                new EntityProperty                {                    Id = 126,                    Name = "PercentileRoundUp",                    DisplayOrder = 30,                    Required = true,                    TxId = 30,                    Value = false                },
                new EntityProperty                {                    Id = 118,                    Name = "Latitude",                    DisplayOrder = 501,                    Required = false,                    TxId = 501,                },
                new EntityProperty                {                    Id = 119,                    Name = "Longitude",                    DisplayOrder = 502,                    Required = false,                    TxId = 502,                },
                new EntityProperty                {                    Id = 110,                    Name = "AssignElasticities",                    DisplayOrder = 50,                    Required = false,                    TxId = 50,                    Value = false                },
                new EntityProperty                {                    Id = 114,                    Name = "CompetitorPriorityID",                    DisplayOrder = 16,                    Required = true,                    TxId = 16,                    Value = 2                },
                new EntityProperty                {                    Id = 130,                    Name = "PriceCheckingPossible",                    DisplayOrder = 15,                    Required = false,                    TxId = 15,                    Value = false                },
                new EntityProperty                {                    Id = 137,                    Name = "ValidationSeconds",                    DisplayOrder = 15,                    Required = true,                    TxId = 15,                    Value = 0                },
                new EntityProperty                {                    Id = 113,                    Name = "CompetitorPriceAge",                    DisplayOrder = 10,                    Required = true,                    TxId = 10,                    Value = 0                },
                new EntityProperty                {                    Id = 135,                    Name = "SpiderCompetitorPriceAge",                    DisplayOrder = 11,                    Required = true,                    TxId = 11,                    Value = 0                },
                new EntityProperty                {                    Id = 134,                    Name = "PriceCheckWebsite",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 133,                    Name = "PriceCheckStreet",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 128,                    Name = "PriceCheckCity",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 131,                    Name = "PriceCheckPostcode",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 129,                    Name = "PriceCheckCountry",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 132,                    Name = "PriceCheckSource",                    DisplayOrder = 20,                    Required = false,                    TxId = 20,                },
                new EntityProperty                {                    Id = 120,                    Name = "MappingLabel",                    DisplayOrder = 503,                    Required = false,                    TxId = 503,                },
                new EntityProperty                {                    Id = 805,                    Name = "Recipients",                    DisplayOrder = 505,                    Required = false,                    TxId = 505                }
            };

            return propertyCollection;
        }
    }
}
