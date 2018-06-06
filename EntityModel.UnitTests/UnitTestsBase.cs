using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    public class UnitTestsBase
    {
        protected EntityProperty CreateNameProperty()
        {
            return new EntityProperty
            {
                Id = 1,
                Name = "Name",
                DataType = typeof(string),
                DisplayOrder = 1,
                Required = true,
                TxId = 12345,
                Value = "NorthXXX"
            };
        }

        protected EntityProperty CreateImportCodeProperty()
        {
            return new EntityProperty
            {
                Id = 2,
                Name = "ImportCode",
                DataType = typeof(string),
                DisplayOrder = 2,
                Required = true,
                TxId = 12345,
                Value = "AREA1"
            };
        }

        protected EntityPropertyCollection CreateEntityPropertyCollection()
        {
            var entityPropertyCollection = new EntityPropertyCollection()
            {
                TableName = "Area",
                Properties = new[] { CreateNameProperty() }
            };
            return entityPropertyCollection;
        }

        protected void ParseSql(string sqlCommandText)
        {
            TSql100Parser parser = new TSql100Parser(false);
            parser.Parse(new StringReader(sqlCommandText), out IList<ParseError> errors);
            File.WriteAllText(@"C:\Development\Tools & Scripts\Prototypes\EntityModel\GeneratedSql.txt", sqlCommandText);

            Assert.IsFalse(errors.Any(), "Incorrect SQL generated: '{0}'");
        }

        protected void TestCommand(IDbCommand command)
        {
            command.Connection = new SqlConnection(@"Data Source=wsman1367\sql2012;Initial Catalog=QA29v65;Integrated Security=SSPI;");
            command.Connection.Open();
            command.Transaction = command.Connection.BeginTransaction();
            command.ExecuteNonQuery();
            command.Transaction.Rollback();
            command.Connection.Close();
        }
    }
}
