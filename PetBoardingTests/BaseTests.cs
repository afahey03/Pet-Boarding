using NUnit.Framework;

namespace AF.PetBoardingTests
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
        public void BaseTest()
        {
            Assert.That(1 == 1, "Pass condition");
        }
    }
}