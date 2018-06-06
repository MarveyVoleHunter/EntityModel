using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using EntityModel.Controllers;
using EntityModel.Models;

namespace EntityModel.UnitTests
{
    [TestClass]
    public class PriceNetUnitTests : UnitTestsBase
    {
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
            //entityPropertyCollection.PrimaryEntityColumnName = "AreaID";
            entityPropertyCollection.PrimaryEntityIds = new[] { 1 };
            entityPropertyCollection.PrimaryEntityTableName = "Area";
            var command = PriceNetSqlGenerator.GenerateUpdateCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        [TestMethod]
        public void CanInsertArea()
        {
            var propertyCollection = AreaProperties.Get();
            Test2(propertyCollection);
            var command = PriceNetSqlGenerator.GenerateInsertCommand(propertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }

        private void Test2(EntityPropertyCollection propertyCollection)
        {
            //Moq
            //var controller = new EntityPropertiesController();
            //controller.Insert(propertyCollection);
            //controller.Request = new HttpRequestMessage();
            //controller.Configuration = new HttpConfiguration();

            //var response = controller.Insert(propertyCollection);
        }

        private void SendToApi(EntityPropertyCollection propertyCollection)
        {
            var json = JsonConvert.SerializeObject(propertyCollection);
            var apiUrl = "";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (string.IsNullOrWhiteSpace(apiUrl))
                throw new ArgumentNullException("The URL of the connect API was blank or null.");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(apiUrl, content).GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                    throw new System.Web.HttpException((int)response.StatusCode, response.ReasonPhrase + " Uri: " + apiUrl);
            }
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
            //entityPropertyCollection.PrimaryEntityColumnName = "AreaID";
            entityPropertyCollection.PrimaryEntityTableName = "Area";
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
            entityPropertyCollection.PrimaryEntityTableName = "OwnSite";
            entityPropertyCollection.PrimaryEntityIds = new int[] { 1, 2 };
            entityPropertyCollection.SecondaryEntityIds = new int[] { 1 };
            entityPropertyCollection.SecondaryEntityTableName = "GlobalProduct";
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
    }
}
