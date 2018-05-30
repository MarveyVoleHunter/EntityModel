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
                    propertyCollection.PrimaryEntityColumnName, propertyCollection.PrimaryEntityIds));

                if (SecondaryEntityIdsSupplied(propertyCollection))
                    entityTableSql.AppendLine(GenerateEntityTempTable("SecondaryEntity", propertyCollection.SecondaryEntityTableName,
                        propertyCollection.SecondaryEntityColumnName, propertyCollection.SecondaryEntityIds));
            }

            return entityTableSql.ToString();
        }

        protected static string GenerateDropEntityTables(EntityPropertyCollection entityPropertyCollection)
        {
            StringBuilder dropTableSql = new StringBuilder();

            if (PrimaryEntityIdsSupplied(entityPropertyCollection))
            {
                dropTableSql.AppendLine();
                dropTableSql.AppendLine("DROP TABLE #PrimaryEntity");
            }
            if (SecondaryEntityIdsSupplied(entityPropertyCollection))
            {
                dropTableSql.AppendLine("DROP TABLE #SecondaryEntity");
                //dropTableSql.AppendLine("DROP TABLE IF EXISTS #SecondaryEntity");
            }

            return dropTableSql.ToString();
        }

        private static string GenerateEntityTempTable(string tempTableName, string entityTableName,
            string entityColumnName, IEnumerable<int> entityIds)
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
            tempTableSql.AppendFormat("SELECT t.[EntityID], e.[{0}]\r\n", GetUidColumn(entityColumnName));
            tempTableSql.AppendLine("FROM");
            tempTableSql.AppendLine("(");
            tempTableSql.AppendLine("VALUES");
            tempTableSql.AppendLine(GetEntityIdValuesList(entityIds));
            tempTableSql.AppendLine(") t ([EntityID])");
            tempTableSql.AppendFormat("JOIN [dbo].[{0}] e ON e.[{1}] = t.[EntityID]\r\n", entityTableName, entityColumnName);

            return tempTableSql.ToString();
        }

        protected static IEnumerable<EntityProperty> GetAmendedProperties(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.Properties.Where(p => p.Modified);
            //var properties = new List<EntityPropertyBase>();

            //foreach (var property in entityPropertyCollection.Properties)
            //{
            //    if (property.Value != property.DisplayOrder)
            //    if (property.DataType == typeof(bool) p1 && p1.Value != p1.InitialValue ||
            //        property.DataType == typeof(DateTime?> p2 && p2.Value != p2.InitialValue ||
            //        property.DataType is EntityProperty<decimal?> p3 && p3.Value != p3.InitialValue ||
            //        property.DataType is EntityProperty<Guid?> p4 && p4.Value != p4.InitialValue ||
            //        property.DataType is EntityProperty<int?> p5 && p5.Value != p5.InitialValue ||
            //        property.DataType is EntityProperty<string> p6 && p6.Value != p6.InitialValue)
            //    {
            //        properties.Add(property);
            //    }
            //}

            //return properties;
        }

        protected static string GetColumnList(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);
            var columnNames = properties.Select(e => e.Name);

            //IEnumerable<string> columnNames = entityPropertyCollection.Properties.Where(e => e.Value != null).Select(e => e.Name);
            return "[" + string.Join("], [", columnNames) + "]";
        }

        protected static IEnumerable<DbParameter> GetCommandParameters(IEnumerable<EntityProperty> properties)
        {
            var parameters = new List<SqlParameter>();

            foreach (var property in properties)
            {
                var parameterName = string.Format("@P{0}", parameters.Count + 1);
                var parameter = new SqlParameter(parameterName, property.Value)
                {
                    ParameterName = parameterName
                };

                //if (property is EntityProperty<bool?>)
                //    parameter.Value = ((EntityProperty<bool?>)property).Value;
                //if (property is EntityProperty<DateTime?>)
                //    parameter.Value = ((EntityProperty<DateTime?>)property).Value;
                //if (property is EntityProperty<decimal?>)
                //    parameter.Value = ((EntityProperty<decimal?>)property).Value;
                //if (property is EntityProperty<Guid?>)
                //    parameter.Value = ((EntityProperty<Guid?>)property).Value;
                //if (property is EntityProperty<int?>)
                //    parameter.Value = ((EntityProperty<int?>)property).Value;
                //if (property is EntityProperty<string>)
                //    parameter.Value = ((EntityProperty<string>)property).Value;

                parameters.Add(parameter);
            }

            return parameters;
        }

        protected static string GetEntityIdValuesList(IEnumerable<int> ids)
        {
            return string.Format("({0})", string.Join("), (", ids));
        }

        protected static IEnumerable<EntityProperty> GetNonNullProperties(EntityPropertyCollection entityPropertyCollection)
        {
            return entityPropertyCollection.Properties.Where(p => p.Value != null);
            //var properties = new List<EntityPropertyBase>();

            //foreach (var property in entityPropertyCollection.Properties)
            //{
            //    if ((property is EntityProperty<bool?> && ((EntityProperty<bool?>)property).Value != null) ||
            //        (property is EntityProperty<DateTime?> && ((EntityProperty<DateTime?>)property).Value != null) ||
            //        (property is EntityProperty<decimal?> && ((EntityProperty<decimal?>)property).Value != null) ||
            //        (property is EntityProperty<Guid?> && ((EntityProperty<Guid?>)property).Value != null) ||
            //        (property is EntityProperty<int?> && ((EntityProperty<int?>)property).Value != null) ||
            //        (property is EntityProperty<string> && ((EntityProperty<string>)property).Value != null))
            //    {
            //        properties.Add(property);
            //    }
            //}

            //return properties;
        }

        protected static string GetParameterList(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);
            var count = 1;

            return string.Join(", ", properties.Select(p => string.Format("@P{0}", count++)));
        }

        protected static string GetUidColumn(string idColumn)
        {
            return string.Concat(idColumn.Remove(idColumn.Length - 2), "UID");
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
                if (string.IsNullOrWhiteSpace(entityPropertyCollection.PrimaryEntityColumnName))
                    throw new ArgumentNullException(nameof(entityPropertyCollection.PrimaryEntityColumnName),
                        "If a set of entities has been supplied then an entity column name must also be supplied.");
            }
            if (SecondaryEntityIdsSupplied(entityPropertyCollection))
            {
                if (string.IsNullOrWhiteSpace(entityPropertyCollection.SecondaryEntityTableName))
                    throw new ArgumentNullException(nameof(entityPropertyCollection.SecondaryEntityTableName),
                        "If a set of secondary entities has been supplied then a secondary entity table name must also be supplied.");
                if (string.IsNullOrWhiteSpace(entityPropertyCollection.SecondaryEntityColumnName))
                    throw new ArgumentNullException(nameof(entityPropertyCollection.SecondaryEntityColumnName),
                        "If a set of secondary entities has been supplied then a secondary entity column name must also be supplied.");
            }
        }

        protected static void ValidateUpdateProperties(EntityPropertyCollection entityPropertyCollection)
        {
            if (string.IsNullOrWhiteSpace(entityPropertyCollection.TableName))
                throw new ArgumentNullException(nameof(entityPropertyCollection.TableName), "A table name must be supplied.");
            if (string.IsNullOrWhiteSpace(entityPropertyCollection.PrimaryEntityColumnName))
                throw new ArgumentNullException(nameof(entityPropertyCollection.PrimaryEntityColumnName), "The name of the primary entity id column must be supplied.");
            if (entityPropertyCollection.PrimaryEntityIds == null || !entityPropertyCollection.PrimaryEntityIds.Any())
                throw new ArgumentNullException(nameof(entityPropertyCollection.PrimaryEntityIds), "A set of one or more entity ids must be supplied.");
            var properties = GetAmendedProperties(entityPropertyCollection);
            if (!properties.Any())
                throw new ArgumentOutOfRangeException(nameof(entityPropertyCollection.Properties), "At least one amended property must be supplied.");
        }
    }
}