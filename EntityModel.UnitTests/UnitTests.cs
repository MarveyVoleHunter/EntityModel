using System;
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
    [TestClass]
    public class UnitTests
    {
        private EntityProperty CreateNameProperty()
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

        private EntityProperty CreateImportCodeProperty()
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

        private EntityPropertyCollection CreateEntityPropertyCollection()
        {
            var entityPropertyCollection = new EntityPropertyCollection()
            {
                TableName = "PNArea",
                Properties = new[] { CreateNameProperty() }
            };
            return entityPropertyCollection;
        }

        [TestMethod]
        public void CanCreateEntityProperty()
        {
            var entityProperty = CreateNameProperty();
            Assert.IsNotNull(entityProperty);
        }

        [TestMethod]
        public void CanCreateEntityPropertyCollection()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            Assert.IsNotNull(entityPropertyCollection);
        }

        [TestMethod]
        public void CanGeneratePriceNetInsert()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            entityPropertyCollection.Properties = new[] { CreateNameProperty(), CreateImportCodeProperty() };
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);
            Assert.IsFalse(string.IsNullOrEmpty(command.CommandText));
        }

        [TestMethod]
        public void ValidSqlInsertGenerated()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            entityPropertyCollection.Properties = new[] { CreateNameProperty(), CreateImportCodeProperty() };
            entityPropertyCollection.PrimaryEntityColumnName = null;
            entityPropertyCollection.PrimaryEntityIds = null;
            entityPropertyCollection.PrimaryEntityTableName = null;
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);
            TSql100Parser parser = new TSql100Parser(false);
            parser.Parse(new StringReader(command.CommandText), out IList<ParseError> errors);

            Assert.IsFalse(errors.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableNameNull()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            entityPropertyCollection.TableName = null;
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);
        }

        [TestMethod]
        public void CanGeneratePriceNetUpdate()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            entityPropertyCollection.Properties = new[] { CreateNameProperty(), CreateImportCodeProperty() };
            entityPropertyCollection.PrimaryEntityColumnName = "AreaID";
            entityPropertyCollection.PrimaryEntityIds = new[] { 1 };
            entityPropertyCollection.PrimaryEntityTableName = "PNArea";
            Test(entityPropertyCollection);
            var p = entityPropertyCollection.Properties.First();
            p.Value = "Amended";
            var command = PriceNetSqlGenerator.GenerateUpdateCommand(entityPropertyCollection);
            Assert.IsFalse(string.IsNullOrEmpty(command.CommandText));
        }

        [TestMethod]
        public void ValidSqlUpdateGenerated()
        {
            var entityPropertyCollection = CreateEntityPropertyCollection();
            entityPropertyCollection.Properties = new[] { CreateNameProperty(), CreateImportCodeProperty() };
            entityPropertyCollection.PrimaryEntityColumnName = "AreaID";
            entityPropertyCollection.PrimaryEntityIds = new[] { 1 };
            entityPropertyCollection.PrimaryEntityTableName = "PNArea";
            var command = PriceNetSqlGenerator.GenerateUpdateCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertArea()
        {
            var entityPropertyCollection = AreaProperties.Get();
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertGlobalProduct()
        {
            var entityPropertyCollection = GlobalProductProperties.Get();
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertNetwork()
        {
            var entityPropertyCollection = NetworkProperties.Get();
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertOwnProduct()
        {
            var entityPropertyCollection = OwnProductProperties.Get();
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertOwnProductGroup()
        {
            var entityPropertyCollection = OwnProductGroupProperties.Get();
            var command = PriceNetSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanUpdateArea()
        {
            var entityPropertyCollection = AreaProperties.Get();
            var properties = entityPropertyCollection.Properties.ToList();
            properties.RemoveAll(p => p.Name == "ImportCode" || p.Name == "Name");
            entityPropertyCollection.Properties = properties;
            entityPropertyCollection.PrimaryEntityColumnName = "AreaID";
            entityPropertyCollection.PrimaryEntityTableName = "PNArea";
            entityPropertyCollection.PrimaryEntityIds = new int[] { 1, 2 };
            Test(entityPropertyCollection);
            entityPropertyCollection.Properties.First().Value = "Amended";
            var command = PriceNetSqlGenerator.GenerateUpdateCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanUpdateOwnProduct()
        {
            var entityPropertyCollection = OwnProductProperties.Get();
            var properties = entityPropertyCollection.Properties.ToList();
            properties.RemoveAll(p => p.Name == "ImportCode" || p.Name == "Name");
            entityPropertyCollection.Properties = properties;
            entityPropertyCollection.PrimaryEntityColumnName = "OwnSiteID";
            entityPropertyCollection.PrimaryEntityTableName = "PNOwnSite";
            entityPropertyCollection.PrimaryEntityIds = new int[] { 1, 2 };
            entityPropertyCollection.SecondaryEntityColumnName = "GlobalProductID";
            entityPropertyCollection.SecondaryEntityIds = new int[] { 1 };
            entityPropertyCollection.SecondaryEntityTableName = "PNGlobalProduct";
            Test(entityPropertyCollection);
            var p1 = entityPropertyCollection.Properties.First();
            p1.InitialValue = false;
            //foreach (var property in entityPropertyCollection.Properties)
            //{
            //    property.in
            //}
            var command = PriceNetSqlGenerator.GenerateUpdateCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        private void Test(EntityPropertyCollection propertyCollection)
        {
            foreach (var property in propertyCollection.Properties)
            {
                property.InitialValue = property.Value;
                //if (property is EntityProperty<bool?> p1)
                //{
                //    p1.InitialValue = p1.Value;
                //}
                //else
                //if (property is EntityProperty<DateTime?> p2)
                //{
                //    p2.InitialValue = p2.Value;
                //}
                //else
                //if (property is EntityProperty<decimal?> p3)
                //{
                //    p3.InitialValue = p3.Value;
                //}
                //else
                //if (property is EntityProperty<Guid?> p4)
                //{
                //    p4.InitialValue = p4.Value;
                //}
                //else
                //if (property is EntityProperty<int?> p5)
                //{
                //    p5.InitialValue = p5.Value;
                //}
                //else
                //if (property is EntityProperty<string> p6)
                //{
                //    p6.InitialValue = p6.Value;
                //}
            }
        }

        private void ParseSql(string sqlCommandText)
        {
            TSql100Parser parser = new TSql100Parser(false);
            parser.Parse(new StringReader(sqlCommandText), out IList<ParseError> errors);
            File.WriteAllText(@"C:\Development\Tools & Scripts\Prototypes\EntityModel\GeneratedSql.txt", sqlCommandText);

            Assert.IsFalse(errors.Any(), "Incorrect SQL generated: '{0}'");
        }

        private void TestCommand(IDbCommand command)
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
