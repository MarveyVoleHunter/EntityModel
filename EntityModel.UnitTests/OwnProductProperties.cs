using System;
using EntityModel.Models;


namespace EntityModel.UnitTests
{
    public class OwnProductProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "OwnProduct",
                PrimaryEntityTableName = "OwnSite",
                PrimaryEntityIds = new int[] { 1, 2 },
                SecondaryEntityIds = new int[] { 7 },
                SecondaryEntityTableName = "GlobalProduct"
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty { Id = 413, Name = "Active", DisplayOrder = 4, Required = true, TxId = 4, Value = true },
                new EntityProperty { Id = 414, Name = "AllowOptimise", DisplayOrder = 1, Required = true, TxId = 1, Value = true },
                new EntityProperty { Id = 415, Name = "CardPriceDiscount", DisplayOrder = 14, Required = true, TxId = 14, Value = 0.00m },
                new EntityProperty { Id = 416, Name = "FixedCompanyMargin", DisplayOrder = 310, Required = true, TxId = 310, Value = 0.00m },
                new EntityProperty { Id = 425, Name = "DealerIndustryZoneMargin", DisplayOrder = 50, Required = false, TxId = 50, },
                new EntityProperty { Id = 426, Name = "FixedDealerMargin", DisplayOrder = 320, Required = true, TxId = 320, Value = 0.00m },
                new EntityProperty { Id = 427, Name = "EndTime", DisplayOrder = 7, Required = false, TxId = 7, },
                new EntityProperty { Id = 429, Name = "HighPriceIncrease", DisplayOrder = 100, Required = true, TxId = 100, Value = 0.00m },
                new EntityProperty { Id = 431, Name = "InStock", DisplayOrder = 5, Required = true, TxId = 5, Value = true },
                new EntityProperty { Id = 432, Name = "ListPrice", DisplayOrder = 1, Required = false, TxId = 1, },
                new EntityProperty { Id = 433, Name = "ListPriceChangeLimit", DisplayOrder = 3, Required = false, TxId = 3, Value = 0.00m },
                new EntityProperty { Id = 434, Name = "ListPriceOffset", DisplayOrder = 2, Required = false, TxId = 2, },
                new EntityProperty { Id = 435, Name = "LocalReferencePriceOffset", DisplayOrder = 1, Required = false, TxId = 1, },
                new EntityProperty { Id = 436, Name = "MaintainSpread", DisplayOrder = 40, Required = true, TxId = 40, Value = false },
                new EntityProperty { Id = 437, Name = "MarginAllocationMethodID", DisplayOrder = 300, Required = true, TxId = 300, Value = 0 },
                new EntityProperty { Id = 438, Name = "MaxCost", DisplayOrder = 30, Required = true, TxId = 30, Value = 200.00m },
                new EntityProperty { Id = 439, Name = "MaxPrice", DisplayOrder = 16, Required = true, TxId = 16, Value = 999.00m },
                new EntityProperty { Id = 440, Name = "MaxPriceDecrement", DisplayOrder = 18, Required = true, TxId = 18, Value = 999.00m },
                new EntityProperty { Id = 441, Name = "MaxPriceIncrement", DisplayOrder = 19, Required = true, TxId = 19, Value = 999.00m },
                new EntityProperty { Id = 442, Name = "MaxSales", DisplayOrder = 70, Required = true, TxId = 70, Value = 9999999.00m },
                new EntityProperty { Id = 443, Name = "MinCost", DisplayOrder = 25, Required = true, TxId = 25, Value = 100.00m },
                new EntityProperty { Id = 444, Name = "MinPrice", DisplayOrder = 15, Required = true, TxId = 15, Value = 1.00m },
                new EntityProperty { Id = 445, Name = "MinSales", DisplayOrder = 60, Required = true, TxId = 60, Value = 0.00m },
                new EntityProperty { Id = 446, Name = "NumberOfHoses", DisplayOrder = 8, Required = true, TxId = 8, Value = 4 },
                new EntityProperty { Id = 448, Name = "PGMaxPrice", DisplayOrder = 21, Required = true, TxId = 21, Value = 180.00m },
                new EntityProperty { Id = 449, Name = "PGMaxPriceDecrement", DisplayOrder = 10, Required = true, TxId = 10, Value = 2.50m },
                new EntityProperty { Id = 450, Name = "PGMaxPriceIncrement", DisplayOrder = 11, Required = true, TxId = 11, Value = 0.00m },
                new EntityProperty { Id = 451, Name = "PGMinPrice", DisplayOrder = 20, Required = true, TxId = 20, Value = 100.00m },
                new EntityProperty { Id = 458, Name = "PricePointSetUID", DisplayOrder = 3, Required = true, TxId = 3, Value = new Guid("6A185D57-D349-4824-844D-039A862BA0E9") },
                new EntityProperty { Id = 459, Name = "SOEInclude", DisplayOrder = 10, Required = true, TxId = 10, Value = false },
                new EntityProperty { Id = 460, Name = "SOEMargin", DisplayOrder = 20, Required = false, TxId = 20, },
                new EntityProperty { Id = 461, Name = "SOEMarginEffectiveTime", DisplayOrder = 30, Required = false, TxId = 30, },
                new EntityProperty { Id = 462, Name = "SOEMaxPrice", DisplayOrder = 40, Required = false, TxId = 40, },
                new EntityProperty { Id = 463, Name = "SOEMaxPriceEffectiveTime", DisplayOrder = 50, Required = false, TxId = 50, },
                new EntityProperty { Id = 464, Name = "StartTime", DisplayOrder = 6, Required = false, TxId = 6, },
                new EntityProperty { Id = 465, Name = "SupplierName", DisplayOrder = 60, Required = false, TxId = 60, },
                new EntityProperty { Id = 466, Name = "TaxRate", DisplayOrder = 12, Required = true, TxId = 12, Value = 0.18m },
                new EntityProperty { Id = 467, Name = "TaxRateEffectiveTime", DisplayOrder = 13, Required = true, TxId = 13, Value = DateTime.Parse("2013-10-11 00:00:00") },
                new EntityProperty { Id = 468, Name = "VolatilityCostChangeCountFrom", DisplayOrder = 7, Required = false, TxId = 7, },
                new EntityProperty { Id = 469, Name = "VolatilityCostChangeCountTo", DisplayOrder = 8, Required = false, TxId = 8, },
                new EntityProperty { Id = 470, Name = "VolatilityCostChangeValueFrom", DisplayOrder = 9, Required = false, TxId = 9, },
                new EntityProperty { Id = 471, Name = "VolatilityCostChangeValueTo", DisplayOrder = 10, Required = false, TxId = 10, },
                new EntityProperty { Id = 472, Name = "VolatilityCostChangeWithinLastXDays", DisplayOrder = 11, Required = false, TxId = 11, },
                new EntityProperty { Id = 473, Name = "VolatilityCostEnabled", DisplayOrder = 12, Required = true, TxId = 12, Value = false },
                new EntityProperty { Id = 474, Name = "VolatilityPriceChangeCountFrom", DisplayOrder = 1, Required = false, TxId = 1, },
                new EntityProperty { Id = 475, Name = "VolatilityPriceChangeCountTo", DisplayOrder = 2, Required = false, TxId = 2, },
                new EntityProperty { Id = 476, Name = "VolatilityPriceChangeValueFrom", DisplayOrder = 3, Required = false, TxId = 3, },
                new EntityProperty { Id = 477, Name = "VolatilityPriceChangeValueTo", DisplayOrder = 4, Required = false, TxId = 4, },
                new EntityProperty { Id = 478, Name = "VolatilityPriceChangeWithinLastXHours", DisplayOrder = 5, Required = false, TxId = 5, },
                new EntityProperty { Id = 479, Name = "VolatilityPriceEnabled", DisplayOrder = 6, Required = true, TxId = 6, Value = false },
                new EntityProperty { Id = 480, Name = "ZOffset", DisplayOrder = 34, Required = false, TxId = 34, },
                new EntityProperty { Id = 481, Name = "ZOffsetEffectiveTime", DisplayOrder = 38, Required = false, TxId = 38, },
                new EntityProperty { Id = 811, Name = "MaxDelivery", DisplayOrder = 50, Required = true, TxId = 50, Value = 40000 },
                new EntityProperty { Id = 812, Name = "MinDelivery", DisplayOrder = 40, Required = true, TxId = 40, Value = 0 },
                new EntityProperty { Id = 815, Name = "MaxCostBreakdown", DisplayOrder = 39, Required = true, TxId = 39, Value = 200.00m },
                new EntityProperty { Id = 816, Name = "MinCostBreakdown", DisplayOrder = 38, Required = true, TxId = 38, Value = 100.00m }
            };

            return propertyCollection;
        }
    }
}
