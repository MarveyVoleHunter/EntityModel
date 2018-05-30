using System;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class OwnProductGroupProperties
    {
        public static EntityPropertyCollection Get()
        {
            var propertyCollection = new EntityPropertyCollection
            {
                TableName = "PNOwnProductGroup",
                PrimaryEntityColumnName = "OwnSiteID",
                PrimaryEntityTableName = "PNOwnSite",
                PrimaryEntityIds = new int[] { 1, 2 },
                SecondaryEntityColumnName = "GlobalProductGroupID",
                SecondaryEntityIds = new int[] { 4 },
                SecondaryEntityTableName = "PNGlobalProductGroup"
            };

            propertyCollection.Properties = new EntityProperty[]
            {
                new EntityProperty
                {
                    Id = 482,
                    Name = "Active",
                    DisplayOrder = 30,
                    Required = true,
                    TxId = 30,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 483,
                    Name = "AlternativeMainMarkerUID",
                    DisplayOrder = 81,
                    Required = false,
                    TxId = 81,
                },
                new EntityProperty
                {
                    Id = 484,
                    Name = "AutoImplement",
                    DisplayOrder = 40,
                    Required = true,
                    TxId = 40,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 485,
                    Name = "GenerateOnGPCEnd",
                    DisplayOrder = 73,
                    Required = true,
                    TxId = 73,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 486,
                    Name = "GeneratePrices",
                    DisplayOrder = 70,
                    Required = true,
                    TxId = 70,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 489,
                    Name = "IncludeInOptimise",
                    DisplayOrder = 50,
                    Required = true,
                    TxId = 50,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 490,
                    Name = "LFAutoImplement",
                    DisplayOrder = 45,
                    Required = true,
                    TxId = 45,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 492,
                    Name = "OwnSiteCompetitorUID",
                    DisplayOrder = 80,
                    Required = false,
                    TxId = 80,
                },
                new EntityProperty
                {
                    Id = 493,
                    Name = "PMIAutoImplement",
                    DisplayOrder = 110,
                    Required = true,
                    TxId = 110,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 494,
                    Name = "PMIFrequency",
                    DisplayOrder = 170,
                    Required = true,
                    TxId = 170,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 495,
                    Name = "PMILastRunDate",
                    DisplayOrder = 120,
                    Required = false,
                    TxId = 120,
                },
                new EntityProperty
                {
                    Id = 496,
                    Name = "PMIMarginRunningLength",
                    DisplayOrder = 180,
                    Required = true,
                    TxId = 180,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 497,
                    Name = "PMIRunningLength",
                    DisplayOrder = 150,
                    Required = true,
                    TxId = 150,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 498,
                    Name = "PMIRunningRate",
                    DisplayOrder = 140,
                    Required = true,
                    TxId = 140,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 499,
                    Name = "PMISalesImpactLimitPercentage",
                    DisplayOrder = 160,
                    Required = true,
                    TxId = 160,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 500,
                    Name = "PMISuggestedPolicy",
                    DisplayOrder = 130,
                    Required = true,
                    TxId = 130,
                    Value = 50
                },
                new EntityProperty
                {
                    Id = 502,
                    Name = "PMITemplateUID",
                    DisplayOrder = 100,
                    Required = false,
                    TxId = 100,
                },
                new EntityProperty
                {
                    Id = 504,
                    Name = "Policy",
                    DisplayOrder = 90,
                    Required = true,
                    TxId = 90,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 505,
                    Name = "RestActive",
                    DisplayOrder = 10,
                    Required = true,
                    TxId = 10,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 506,
                    Name = "RestAllowDecrease",
                    DisplayOrder = 120,
                    Required = true,
                    TxId = 120,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 507,
                    Name = "RestAllowFirstLower",
                    DisplayOrder = 140,
                    Required = true,
                    TxId = 140,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 508,
                    Name = "RestConsiderAllProducts",
                    DisplayOrder = 115,
                    Required = true,
                    TxId = 115,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 509,
                    Name = "RestFirstGenToSFR",
                    DisplayOrder = 220,
                    Required = true,
                    TxId = 220,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 510,
                    Name = "RestGeneratePricesAtEnd",
                    DisplayOrder = 210,
                    Required = true,
                    TxId = 210,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 511,
                    Name = "RestGPCToRest",
                    DisplayOrder = 160,
                    Required = true,
                    TxId = 160,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 512,
                    Name = "RestGPCTriggerCount",
                    DisplayOrder = 180,
                    Required = true,
                    TxId = 180,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 513,
                    Name = "RestGroup",
                    DisplayOrder = 20,
                    Required = false,
                    TxId = 20,
                },
                new EntityProperty
                {
                    Id = 514,
                    Name = "RestLaggardModeID",
                    DisplayOrder = 190,
                    Required = true,
                    TxId = 190,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 515,
                    Name = "RestMatchHighestCompetitor",
                    DisplayOrder = 110,
                    Required = true,
                    TxId = 110,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 516,
                    Name = "RestMaxHours",
                    DisplayOrder = 200,
                    Required = true,
                    TxId = 200,
                    Value = 0m
                },
                new EntityProperty
                {
                    Id = 517,
                    Name = "RestPreRestPricing",
                    DisplayOrder = 70,
                    Required = true,
                    TxId = 70,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 518,
                    Name = "RestSFROnDRop",
                    DisplayOrder = 150,
                    Required = true,
                    TxId = 150,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 519,
                    Name = "RestSuspendAutoImplement",
                    DisplayOrder = 90,
                    Required = true,
                    TxId = 90,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 520,
                    Name = "RestTriggerCount",
                    DisplayOrder = 60,
                    Required = true,
                    TxId = 60,
                    Value = 0
                },
                new EntityProperty
                {
                    Id = 521,
                    Name = "RestTriggerWaitPeriod",
                    DisplayOrder = 80,
                    Required = true,
                    TxId = 80,
                    Value = 0m
                },
                new EntityProperty
                {
                    Id = 522,
                    Name = "RestTurnOffAutoImplementAtEnd",
                    DisplayOrder = 100,
                    Required = true,
                    TxId = 100,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 523,
                    Name = "RestUseGPCTriggerCount",
                    DisplayOrder = 170,
                    Required = true,
                    TxId = 170,
                    Value = false
                },
                new EntityProperty
                {
                    Id = 524,
                    Name = "RestUseHigherRulesPrice",
                    DisplayOrder = 130,
                    Required = true,
                    TxId = 130,
                    Value = false
                }
            };

            return propertyCollection;
        }
    }
}
