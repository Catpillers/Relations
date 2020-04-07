using Relations.Bll.Services;
using Xunit;

namespace Relations.Tests
{
  public  class PostalCodeMaskTest
  {
      [Theory]
      [InlineData("2222AA", "NNNN-Ll", "2222-Aa")]
      [InlineData("2222AA", "", "2222AA")]
      [InlineData("2222AA", "NNNN-ll", "2222-aa")]
      [InlineData("AAAA-22", "", "AAAA-22")]
        public void ApplyMask_MaskShouldApplyToValue(string value, string mask, string expected)
        {
            //Arrange
            var relation = new RelationService();
            //Act 
            string actual = relation.ApplyMask(value, mask);
            //Assert 
            Assert.Equal(expected, actual);
        }
  }
}
