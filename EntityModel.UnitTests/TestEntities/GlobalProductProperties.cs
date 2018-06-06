using System;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class GlobalProductProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "GlobalProduct",
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty
                {
                    Id = 273,
                    Name = "CFEnableCompetitorPrice",
                    DataType = typeof(bool),
                    DisplayOrder = 2,
                    Required = true,
                    TxId = 2,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 274,
                    Name = "CFEnableOwnPrice",
                    DisplayOrder = 1,
                    Required = true,
                    TxId = 1,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 275,
                    Name = "CFFillClosedPeriods",
                    DisplayOrder = 4,
                    Required = true,
                    TxId = 4,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 276,
                    Name = "CFMaximumPriceAge",
                    DisplayOrder = 6,
                    Required = true,
                    TxId = 6,
                    Value = 14
                },
                new EntityProperty
                {
                    Id = 277,
                    Name = "CFNumberOfDays",
                    DisplayOrder = 5,
                    Required = true,
                    TxId = 5,
                    Value = 14
                },
                new EntityProperty
                {
                    Id = 278,
                    Name = "CFTimeLag",
                    DisplayOrder = 7,
                    Required = true,
                    TxId = 7,
                    Value = 1
                },
                new EntityProperty
                {
                    Id = 279,
                    Name = "CFValidOnly",
                    DisplayOrder = 3,
                    Required = true,
                    TxId = 3,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 280,
                    Name = "FixedCompanyMargin",
                    DisplayOrder = 310,
                    Required = true,
                    TxId = 310,
                    Value = 0.000000000m
                },
                new EntityProperty
                {
                    Id = 281,
                    Name = "FixedDealerMargin",
                    DisplayOrder = 320,
                    Required = true,
                    TxId = 320,
                    Value = 0.000000000m
                },
                new EntityProperty
                {
                    Id = 282,
                    Name = "DisplayOrder",
                    DisplayOrder = 30,
                    Required = true,
                    TxId = 30,
                    Value = 1
                },
                new EntityProperty
                {
                    Id = 284,
                    Name = "ImportCode",
                    DisplayOrder = 20,
                    Required = true,
                    TxId = 20,
                    Value = "DSL2"
                },
                new EntityProperty
                {
                    Id = 285,
                    Name = "LFLVolumePercentageTarget",
                    DisplayOrder = 200,
                    Required = false,
                    TxId = 200,
                },
                new EntityProperty
                {
                    Id = 286,
                    Name = "MarginAllocationMethodID",
                    DisplayOrder = 300,
                    Required = true,
                    TxId = 300,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 287,
                    Name = "MaxCost",
                    DisplayOrder = 160,
                    Required = true,
                    TxId = 160,
                    Value = 0.000000000m
                },
                new EntityProperty
                {
                    Id = 288,
                    Name = "MaxPrice",
                    DisplayOrder = 50,
                    Required = true,
                    TxId = 50,
                    Value = 180.00m
                },
                new EntityProperty
                {
                    Id = 289,
                    Name = "MaxPriceDecrement",
                    DisplayOrder = 140,
                    Required = true,
                    TxId = 140,
                    Value = 0.25m
                },
                new EntityProperty
                {
                    Id = 290,
                    Name = "MaxPriceIncrement",
                    DisplayOrder = 150,
                    Required = true,
                    TxId = 150,
                    Value = 0.25m
                },
                new EntityProperty
                {
                    Id = 291,
                    Name = "MaxSales",
                    DisplayOrder = 90,
                    Required = true,
                    TxId = 90,
                    Value = 0m
                },
                new EntityProperty
                {
                    Id = 292,
                    Name = "MinCost",
                    DisplayOrder = 170,
                    Required = true,
                    TxId = 170,
                    Value = 0.000000000m
                },
                new EntityProperty
                {
                    Id = 293,
                    Name = "MinPrice",
                    DisplayOrder = 50,
                    Required = true,
                    TxId = 50,
                    Value = 120.00m
                },
                new EntityProperty
                {
                    Id = 294,
                    Name = "MinSales",
                    DisplayOrder = 80,
                    Required = true,
                    TxId = 80,
                    Value = 0m
                },
                new EntityProperty
                {
                    Id = 295,
                    Name = "Name",
                    DisplayOrder = 10,
                    Required = true,
                    TxId = 10,
                    Value = "Diesel2"
                },
                new EntityProperty
                {
                    Id = 296,
                    Name = "OctaneCode",
                    DisplayOrder = 900,
                    Required = false,
                    TxId = 900,
                },
                new EntityProperty
                {
                    Id = 297,
                    Name = "PGMaxPrice",
                    DisplayOrder = 100,
                    Required = true,
                    TxId = 100,
                    Value = 170.00m
                },
                new EntityProperty
                {
                    Id = 298,
                    Name = "PGMaxPriceDecrement",
                    DisplayOrder = 120,
                    Required = true,
                    TxId = 120,
                    Value = 2.50m
                },
                new EntityProperty
                {
                    Id = 299,
                    Name = "PGMaxPriceIncrement",
                    DisplayOrder = 130,
                    Required = true,
                    TxId = 130,
                    Value = 0.00m
                },
                new EntityProperty
                {
                    Id = 300,
                    Name = "PGMinPrice",
                    DisplayOrder = 110,
                    Required = true,
                    TxId = 110,
                    Value = 120.00m
                },
                new EntityProperty
                {
                    Id = 301,
                    Name = "PricePointSetUID",
                    DisplayOrder = 40,
                    Required = true,
                    TxId = 40,
                    Value = new Guid("6A185D57-D349-4824-844D-039A862BA0E9")
                },
                new EntityProperty
                {
                    Id = 302,
                    Name = "TaxRate",
                    DisplayOrder = 60,
                    Required = true,
                    TxId = 60,
                    Value = 0.175000000m
                },
                new EntityProperty
                {
                    Id = 303,
                    Name = "TaxRateEffectiveTime",
                    DisplayOrder = 70,
                    Required = true,
                    TxId = 70,
                    Value = DateTime.Parse("2013-10-11 00:00:00")
                },
                new EntityProperty
                {
                    Id = 809,
                    Name = "MaxDelivery",
                    DisplayOrder = 190,
                    Required = true,
                    TxId = 190,
                    Value = 40000
                },
                new EntityProperty
                {
                    Id = 810,
                    Name = "MinDelivery",
                    DisplayOrder = 180,
                    Required = true,
                    TxId = 180,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 813,
                    Name = "MaxCostBreakdown",
                    DisplayOrder = 178,
                    Required = true,
                    TxId = 178,
                    Value = 0.000000000m
                },
                new EntityProperty
                {
                    Id = 814,
                    Name = "MinCostBreakdown",
                    DisplayOrder = 179,
                    Required = true,
                    TxId = 179,
                    Value = 0.000000000m
                }
            };

            return propertyCollection;
        }
    }
}
