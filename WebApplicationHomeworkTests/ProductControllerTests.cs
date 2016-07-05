using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationHomework.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        [TestMethod()]
        public void Test_Get_Prod_By_PageSize_3_And_Column_is_Cost_Sum()
        {
            // arrange
            var target = new ProductController();

            var expected = new List<int> { 6, 15, 24, 21 };

            // act
            var actual = target.GetProdByPageSizeAndColumnSum(3, "Cost");

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test_Get_Prod_By_PageSize_4_And_Column_is_Revenue_Sum()
        {
            // arrange
            var target = new ProductController();

            var expected = new List<int> { 50, 66, 60 };

            // act
            var actual = target.GetProdByPageSizeAndColumnSum(4, "Revenue");

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}