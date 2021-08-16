using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Gene_App.Jobs.DNA;


namespace Gene_App.TestProject
{
    [TestClass]
    public class Jobs_Unit_Testing
    {
        [TestMethod]
        public void DecodeString_Unit_Test()
        {
            
            var output = DNASerialization.DecodeStrandFromBase64("TbSh");

            var expectedResult = "CATCGTCAGGAC";

            Assert.AreEqual(expectedResult, output);
        }
        public string reconvert(string s)
        {
            return DNASerialization.DecodeStrandFromBase64(DNASerialization.EncodeStrandToBase64(s));
        }
        [TestMethod]
        public void EncodeString_Unit_Test()
        {
            string input = "CATAGTCACGTGGATTCAGCCCGAACGAGTCATCTCGGACAAGCGCTCGTGATGTCATAGGGATAAGTAACCTATATGTCACGACGTCACTTCTGTACAGGCCATATTGCCTCCGCAATCTCGCGTGACGTGGATTAATCGGGGTTAGTACGGGAATACATATTCAGTAGTGAACGGGGTGATCAAAGAGGCTGCAGTGATCATCTACTCAAGAGCAGTGCTTGGCCCTTATCTTCGTCAGAGAGAACCCGTTATTTACTCCACAGTTAGGCTGAAGACTGTAACACCCGCCAACTACTCTATAATTGACGCTATTGACAGCAGGGCCGTAGGGACATGCCGCTTGCTTGCACGACGATGACCCTTTTCAGCTGGTATGTCATGTTAACCTTATTGCCGGCCTGTCGACAGCCCTAAACTGATGAATATAGCCGTACGACATTTCTTAAGATTTGAAGAGTGATTATGGTGGGCCCCCTTCGGCCAGGTAGACCACCTAGGTAATTGTCTGCTATATATGTCTATCTTTCGGCTCCAGCCGTGGCCGTCCCGGCGCGGGTCCGTACTGCTGATTTTCATGGCGCTCTACCAATAGCCCGAGAAAATCGTAGGTCTGTTAAACCAACAATTCTTGGGCCCGGCATGCAGTTTCGCTCGACCCGAAGGACGGTCTCATCGCTGAGACTGAAGAATGGGAACACAGGTCACTAGAAAATTCGATCCAGGGGGTAACTATCATGGGCGACCATTGTGACAACAAGGGCCGATCGGTCAAGACCTTAGCAGACTCGGCTGGTGTCTTCTAGTTCTTCCGACTATTAAGAACCCTGAATCGGGGCGCAAGCACTTTCAACACGAAGTGGATGAGGAGCCATTTCTTCATAGGCGAGGATAAGGTTGAGCAAATATCTGTCAGATGTAGGATTCTCATGACCCTGACGGCAAGTCCATGGGCACACGGCACATCAAGAATCTGTATGCGACCGTGCCGGGTTTAGTGTGCGGCGAGAGTGCGGGGACCCACAACGGTGGGGATGGGTTTGTATCGAATCGCTTCTTCCAGTTTGCTCTTATAATCTGGTGTGCCATGCCAAGACATGACGAGACCCAGGTTCACCTAGTCC";
            var output = DNASerialization.EncodeStrandToBase64(input);
            var expectedResult = "TLRuj0lYGLTdoQmduO0yowsFzO0YbR97EpTPl1kN2bhujw2q8sagxM9LLgarjQIp5LjTcdCJLn6V8320iIFbz8dRLyngh7BFZQcdzD4Zz4SSpbKhOWfn5GGOFf9J6ztO8F8+Wl7YSVwHjgzJbGE/fCP4IuPOupVfaUrIUXKw+3nMztzf2nUlultWmatbHnj/TpncUMlYgDbK3vAUEPfqVpOS/Z2FYKGt02eIeCDqBErRyAPY1Kqwc06mFPuEEKlja0IXySHaeu33L31hzwgV4NqmQkf0EYLo4olP30ymKMK+JAze0jso904V4aQtTqRGkTQg3s5hblq/LuaYi5qhUQa6o6v7Ng2ffUv53zDeu5TlCE4YhUr0XLU=";
            
            Console.WriteLine(output);
            Assert.AreEqual(expectedResult, output);
        }
        [TestMethod]
        public void EncodeString_Unit_Test2()
        {
            string input = "CCCA";
            var output = DNASerialization.EncodeStrandToBase64(input);
            var expectedResult = input;
            output = DNASerialization.DecodeStrandFromBase64(output);
            Console.WriteLine(output);

            Assert.AreEqual(expectedResult, output);
        }
        [TestMethod]
        public void TestGeneActivation()
        {
            string gene = "TACCGCTTCATAAACCGCTAGACTGCATGATCGGGT";
            string template = "CATCTCAGTCCTACTAAACTCGCGAAGCTCATACTAGCTACTAAACCGCTAGACTGCATGATCGCATAGCTAGCTACGCT";
            bool output = DNAAnalysis.CheckStrandActivation(template, gene);
            bool expectedResult = true;
            Assert.AreEqual(expectedResult, output);
            
        }

    }
}

