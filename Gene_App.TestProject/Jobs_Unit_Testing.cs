using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gene_App.TestProject
{
    [TestClass]
    public class Jobs_Unit_Testing
    {
        [TestMethod]
        public void DecodeString_Unit_Test()
        {
            
            var output = Jobs.DecodeString("TbSh");

            var expectedResult = "CATCGTCAGGAC";

            Assert.AreEqual(expectedResult, output);
        }
        public string reconvert(string s)
        {
            return Jobs.DecodeString(Jobs.encodestring(s));
        }
        [TestMethod]
        public void EncodeString_Unit_Test()
        {
            string input = "CATCGTCAGGAC";
            var output = Jobs.encodestring(input);
            var expectedResult = input;
            output = Jobs.DecodeString(output);
            
            Assert.AreEqual(expectedResult, output);
        }
        [TestMethod]
        public void EncodeString_Unit_Test2()
        {
            string input = "CCCA";
            var output = Jobs.encodestring(input);
            var expectedResult = input;
            output = Jobs.DecodeString(output);
            Console.WriteLine(output);

            Assert.AreEqual(expectedResult, output);
        }

    }
}

