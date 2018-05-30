using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.ModelConfiguration;
using EntityModel.Models;

namespace EntityModel.Controllers
{
    public class EntityPropertiesController : ApiController
    {
        Dictionary<int, EntityProperty> properties = new EntityProperty[]
            {
                new EntityProperty { Id = 1, Name = "Test", Value = 123 },
                new EntityProperty { Id = 2, Name = "Test2", Value = true }
            }.ToDictionary(e => e.Id, e => e);

        public EntityPropertyCollection Get()
        {
            IEnumerable<Models.EntityProperty> x = null;
            Models.EntityPropertyCollection coll = new Models.EntityPropertyCollection()
            {
                TableName = "PNArea",
                PrimaryEntityColumnName = "AreaUID",
                PrimaryEntityTableName = "PNArea",
                PrimaryEntityIds = new int[] { 1, 2 }
            };
            coll.Properties = properties.Values;
            //using (var context = new QA29v55Entities())
            //{
            //    var y = context.GetEntityProperties("OWNSITE");
            //    x = context.EntityProperties;
            //    var z = x.ToArray();
            //};
            return coll;
        }

        public string AddCollection(EntityPropertyCollection col)
        {
            Debug.WriteLine(col.TableName);
            return col.TableName;
            return col.Properties.First().GetType().Name;
        }

        public EntityProperty Get(int id)
        {
            if (!properties.ContainsKey(id))
                throw new IndexOutOfRangeException(id.ToString() + " was not found in the collection.");
            //Add(new Models.EntityProperty<int> { Id = 3 });
            properties[id].TestValue = true;
            return properties[id];
        }

        //public void Add<T>(EntityProperty<T> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}

        //public void Add(EntityProperty<bool> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}

        //public void Add(EntityProperty<DateTime> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}

        //public void Add(EntityProperty<decimal> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}

        //public void Add(EntityProperty<int> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}

        //public void Add(EntityProperty<string> newProperty)
        //{
        //    properties.Add(newProperty.Id, newProperty);
        //}
    }
}
