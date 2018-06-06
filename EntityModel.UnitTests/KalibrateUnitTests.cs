using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityModel.UnitTests
{
    [TestClass]
    public class KalibrateUnitTests : UnitTestsBase
    {
        [TestMethod]
        public void CanInsertArea()
        {
            var entityPropertyCollection = AreaProperties.Get();
            var command = KalibrateSqlGenerator.GenerateInsertCommand(entityPropertyCollection);

            ParseSql(command.CommandText);
            TestCommand(command);
        }
    }
}
