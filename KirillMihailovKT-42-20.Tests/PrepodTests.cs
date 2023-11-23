using KirillMihailovKt_42_20.Models;

namespace KirillMihailovKT_42_20.Tests
{
    public class PrepodTests
    {
        [Fact]
        public void IsValidPrepodFirstName_FirstName_true()
        {
            //arrange
            var TestPrepod = new Prepod
            {
                FirstName = "Павел"
            };

            //act
            var result = TestPrepod.IsvalidPrepodFirstName();

            //assert
            Assert.True(result);
        }
    }
}