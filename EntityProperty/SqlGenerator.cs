using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EntityModel.Models;

namespace EntityModel
{
    public class SqlGenerator
    {
        protected static string GenerateCreateEntityTables(EntityPropertyCollection propertyCollection)
        {
            StringBuilder entityTableSql = new StringBuilder();

            if (PrimaryEntityIdsSupplied(propertyCollection))
            {
                entityTableSql.AppendLine(GenerateEntityTempTable("PrimaryEntity", propertyCollection.PrimaryEntityTableName,
                    propertyCollection.PrimaryEntityIds));

                if (SecondaryEntityIdsSupplied(propertyCollection))
                    entityTableSql.AppendLine(GenerateEntityTempTable("SecondaryEntity", propertyCollection.SecondaryEntityTableName,
                        propertyCollection.SecondaryEntityIds));
            }

            return entityTableSql.ToString();
        }

        protected static string GenerateDropEntityTables(EntityPropertyCollection entityPropertyCollection)
        {
            var dropTableSql = new StringBuilder();

            if (PrimaryEntityIdsSupplied(entityPropertyCollection))
            {
                dropTableSql.AppendLine();
                dropTableSql.AppendLine("DROP TABLE #PrimaryEntity");
            }
            if (SecondaryEntityIdsSupplied(entityPropertyCollection))
            {
                dropTableSql.AppendLine("DROP TABLE #SecondaryEntity");
            }

            return dropTableSql.ToString();
        }

        private static string GenerateEntityTempTable(string tempTableName, string entityTableName,
            IEnumerable<int> entityIds)
        {
            StringBuilder tempTableSql = new StringBuilder();

            tempTableSql.AppendFormat("CREATE TABLE #{0}\r\n", tempTableName);
            tempTableSql.AppendLine("(");
            tempTableSql.AppendLine("    [EntityID]  int,");
            tempTableSql.AppendLine("    [EntityUID] uniqueidentifier");
            tempTableSql.AppendLine(")");
            tempTableSql.AppendLine();
            tempTableSql.AppendFormat("INSERT INTO #{0}\r\n", tempTableName);
            tempTableSql.AppendLine("([EntityID], [EntityUID])");
            tempTableSql.AppendFormat("SELECT t.[EntityID], e.[{0}]\r\n", GetUidColumn(entityTableName));
            tempTableSql.AppendLine("FROM");
            tempTableSql.AppendLine("(");
            tempTableSql.AppendLine("VALUES");
            tempTableSql.AppendLine(GetEntityIdValuesList(entityIds));
            tempTableSql.AppendLine(") t ([EntityID])");
            tempTableSql.AppendFormat("JOIN {0} e ON e.[{1}] = t.[EntityID]\r\n", GetPriceNetTableName(entityTableName), GetIdColumn(entityTableName));

            return tempTableSql.ToString();
        }

        protected static IEnumerable<EntityProperty> GetAmendedProperties(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.Properties.Where(p => p.IsModified);
        }

        protected static string GetColumnList(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);
            var columnNames = properties.Select(e => e.Name);

            return "[" + string.Join("], [", columnNames) + "]";
        }

        protected static IEnumerable<DbParameter> GetCommandParameters(IEnumerable<EntityProperty> properties)
        {
            var parameters = new List<SqlParameter>();

            foreach (var property in properties)
            {
                var parameterName = string.Format("@P{0}", parameters.Count + 1);

                parameters.Add(new SqlParameter(parameterName, property.Value));
            }

            return parameters;
        }

        protected static string GetEntityIdValuesList(IEnumerable<int> ids)
        {
            return string.Format("({0})", string.Join("), (", ids));
        }

        protected static string GetIdColumn(string tableName)
        {
            return string.Concat(tableName, "ID");
        }

        protected static IEnumerable<EntityProperty> GetNonNullProperties(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.Properties.Where(p => p.Value != null);
        }

        protected static string GetParameterList(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);
            var count = 1;

            return string.Join(", ", properties.Select(p => string.Format("@P{0}", count++)));
        }

        protected static string GetPriceNetTableName(string tableName)
        {
            return string.Format("[dbo].[PN{0}]", tableName);
        }

        protected static string GetUidColumn(string tableName)
        {
            return string.Concat(tableName, "UID");
        }

        protected static bool PrimaryEntityIdsSupplied(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.PrimaryEntityIds != null && entityPropertyCollection.PrimaryEntityIds.Any();
        }

        protected static bool SecondaryEntityIdsSupplied(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.SecondaryEntityIds != null && entityPropertyCollection.SecondaryEntityIds.Any();
        }

        protected static void ValidateInsertProperties(EntityPropertyCollection entityPropertyCollection)
        {
            var nullrequiredProperties = entityPropertyCollection.Properties.Where(p => p.Required && p.Value == null);
            var nonNullProperties = GetNonNullProperties(entityPropertyCollection);

            if (entityPropertyCollection == null)
                throw new ArgumentNullException(nameof(entityPropertyCollection), "An.entity property collection must be supplied.");
            if (string.IsNullOrWhiteSpace(entityPropertyCollection.TableName))
                throw new ArgumentNullException(nameof(entityPropertyCollection.TableName), "A table name must be supplied.");
            if (!nonNullProperties.Any())
                throw new ArgumentOutOfRangeException(nameof(entityPropertyCollection.Properties), "A number of non-null properties must be supplied.");
            if (nullrequiredProperties.Any())
                throw new ArgumentNullException("A value must be supplied for all required properties.");

            if (PrimaryEntityIdsSupplied(entityPropertyCollection))
            {
                if (string.IsNullOrWhiteSpace(entityPropertyCollection.PrimaryEntityTableName))
                    throw new ArgumentNullException(nameof(entityPropertyCollection.PrimaryEntityTableName),
                        "If a set of entities has been supplied then an entity table name must also be supplied.");
            }
            if (SecondaryEntityIdsSupplied(entityPropertyCollection))
            {
                if (string.IsNullOrWhiteSpace(entityPropertyCollection.SecondaryEntityTableName))
                    throw new ArgumentNullException(nameof(entityPropertyCollection.SecondaryEntityTableName),
                        "If a set of secondary entities has been supplied then a secondary entity table name must also be supplied.");
             }
        }

        protected static void ValidateUpdateProperties(EntityPropertyCollection entityPropertyCollection)
        {
            if (string.IsNullOrWhiteSpace(entityPropertyCollection.TableName))
                throw new ArgumentNullException(nameof(entityPropertyCollection.TableName), "A table name must be supplied.");
            if (entityPropertyCollection.PrimaryEntityIds == null || !entityPropertyCollection.PrimaryEntityIds.Any())
                throw new ArgumentNullException(nameof(entityPropertyCollection.PrimaryEntityIds), "A set of one or more entity ids must be supplied.");
            var properties = GetAmendedProperties(entityPropertyCollection);
            if (!properties.Any())
                throw new ArgumentOutOfRangeException(nameof(entityPropertyCollection.Properties), "At least one amended property must be supplied.");
        }
    }
}