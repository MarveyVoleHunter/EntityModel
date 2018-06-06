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
    public class PriceNetSqlGenerator : SqlGenerator
    {
        public static IDbCommand GenerateInsertCommand(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);

            ValidateInsertProperties(entityPropertyCollection);
            SqlCommand cmd = new SqlCommand(GenerateInsertStatement(entityPropertyCollection));
            cmd.Parameters.AddRange(GetCommandParameters(properties).ToArray());

            return cmd;
        }

        public static IDbCommand GenerateUpdateCommand(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetAmendedProperties(entityPropertyCollection);
            ValidateUpdateProperties(entityPropertyCollection);
            SqlCommand cmd = new SqlCommand(GenerateUpdateStatement(entityPropertyCollection));
            cmd.Parameters.AddRange(GetCommandParameters(properties).ToArray());

            return cmd;
        }

        private static string GenerateInsertStatement(EntityPropertyCollection propertyCollection)
        {
            StringBuilder insertSql = new StringBuilder();
            StringBuilder entitySql = new StringBuilder();
            StringBuilder selectSql = new StringBuilder("SELECT ");

            insertSql.Append(GenerateCreateEntityTables(propertyCollection));

            insertSql.AppendFormat("INSERT INTO {0}\r\n", GetPriceNetTableName(propertyCollection.TableName));
            insertSql.Append("(");

            if (PrimaryEntityIdsSupplied(propertyCollection))
            {
                insertSql.AppendFormat("[{0}], ", GetUidColumn(propertyCollection.PrimaryEntityTableName));
                selectSql.Append("pe.[EntityUID], ");
                entitySql.AppendLine("FROM #PrimaryEntity pe");

                if (SecondaryEntityIdsSupplied(propertyCollection))
                {
                    insertSql.AppendFormat("[{0}], ", GetUidColumn(propertyCollection.SecondaryEntityTableName));
                    selectSql.Append("se.[EntityUID], ");
                    entitySql.AppendLine("CROSS JOIN #SecondaryEntity se");
                }
            }

            selectSql.AppendLine(GetParameterList(propertyCollection));
            insertSql.AppendFormat("{0})\r\n", GetColumnList(propertyCollection));
            insertSql.Append(selectSql);
            insertSql.Append(entitySql);

            insertSql.Append(GenerateDropEntityTables(propertyCollection));

            return insertSql.ToString();
        }

        private static string GenerateUpdateStatement(EntityPropertyCollection propertyCollection)
        {
            StringBuilder updateSql = new StringBuilder();

            updateSql.Append(GenerateCreateEntityTables(propertyCollection));

            updateSql.AppendLine("UPDATE t");
            updateSql.AppendLine("SET");
            updateSql.AppendLine(GetSetClause(propertyCollection));
            updateSql.AppendFormat("FROM {0} t\r\n", GetPriceNetTableName(propertyCollection.TableName));
            updateSql.AppendFormat("JOIN #PrimaryEntity pe ON pe.[EntityUID] = t.[{0}]", GetUidColumn(propertyCollection.PrimaryEntityTableName));

            if (SecondaryEntityIdsSupplied(propertyCollection))
                updateSql.AppendFormat("JOIN #SecondaryEntity se ON se.[EntityUID] = t.[{0}]", GetUidColumn(propertyCollection.SecondaryEntityTableName));

            return updateSql.ToString();
        }

        private static string GetSetClause(EntityPropertyCollection entityPropertyCollection)
        {
            var setClause = new StringBuilder();
            var properties = GetAmendedProperties(entityPropertyCollection);
            int count = 1;

            foreach (var property in properties)
            {
                setClause.AppendFormat("[{0}] = @P{1},\r\n", property.Name, count++);
            }
            setClause.Length -= 3;

            return setClause.ToString();
        }

        private static bool ValidatePropertyDataTypes(EntityPropertyCollection entityPropertyCollection)
        {
            foreach (var property in entityPropertyCollection.Properties)
            {
                if (property.Value == null)
                    continue;
                if (property.Value.GetType() == property.DataType)
                    continue;

                if (property.DataType == typeof(bool) && Boolean.TryParse(property.Value.ToString(), out bool boolValue))
                {
                    property.Value = boolValue;
                    continue;
                }
                if (property.DataType == typeof(Guid) && Guid.TryParse(property.Value.ToString(), out Guid guidValue))
                {
                    property.Value = guidValue;
                    continue;
                }
                return false;
            }

            return true;
        }
    }
}