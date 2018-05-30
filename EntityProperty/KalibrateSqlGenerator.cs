using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using EntityModel.Models;

namespace EntityModel
{
    public class KalibrateSqlGenerator : SqlGenerator
    {
        public static IDbCommand GenerateInsertCommand(EntityPropertyCollection entityPropertyCollection)
        {
            var properties = GetNonNullProperties(entityPropertyCollection);

            ValidateInsertProperties(entityPropertyCollection);
            //SqlCommand cmd = new SqlCommand(GenerateInsertStatement(entityPropertyCollection));
            //cmd.Parameters.AddRange(GetCommandParameters(properties).ToArray());

            return null;
        }

        private static string GenerateInsertStatement(EntityPropertyCollection propertyCollection)
        {
            StringBuilder insertSql = new StringBuilder();
            StringBuilder entitySql = new StringBuilder();
            StringBuilder selectSql = new StringBuilder("SELECT ");

            insertSql.Append(GenerateCreateEntityTables(propertyCollection));

            insertSql.AppendFormat("INSERT INTO [dbo].[{0}]\r\n", propertyCollection.TableName);
            insertSql.Append("(");

            //if (PrimaryEntityIdsSupplied(propertyCollection))
            //{
            //    insertSql.AppendFormat("[{0}], ", GetUidColumn(propertyCollection.PrimaryEntityColumnName));
            //    selectSql.Append("pe.[EntityUID], ");
            //    entitySql.AppendLine("FROM #PrimaryEntity pe");

            //    if (SecondaryEntityIdsSupplied(propertyCollection))
            //    {
            //        insertSql.AppendFormat("[{0}], ", GetUidColumn(propertyCollection.SecondaryEntityColumnName));
            //        selectSql.Append("se.[EntityUID], ");
            //        entitySql.AppendLine("CROSS JOIN #SecondaryEntity se");
            //    }
            //}

            selectSql.AppendLine(GetParameterList(propertyCollection));
            insertSql.AppendFormat("{0})\r\n", GetColumnList(propertyCollection));
            insertSql.Append(selectSql);
            insertSql.Append(entitySql);

            insertSql.Append(GenerateDropEntityTables(propertyCollection));

            return insertSql.ToString();
        }
    }
}