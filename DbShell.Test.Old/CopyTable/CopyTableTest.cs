﻿using System;
using System.Configuration;
using System.IO;
using DbShell.Core.Runtime;
using DbShell.Driver.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbShell.Core.Utility;

namespace DbShell.Test
{
    [TestClass]
    public class CopyTableTest : DatabaseTestBase
    {
        [TestMethod]
        [DeploymentItem("CopyTable/copytable_tabletocdl.xaml")]
        public void TableToCdl()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_tabletocdl.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("CopyTable/copytable_cdltocdl.xaml")]
        public void CdlToCdl()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_cdltocdl.xaml");
                runner.Run();
            }

            Assert.IsTrue(TestUtility.FileCompare("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("CopyTable/copytable_tabletotable.xaml")]
        public void TableToTable()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_tabletotable.xaml");
                runner.Run();
            }

            Assert.IsTrue(TestUtility.FileCompareCdlContent("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("CopyTable/copytable_columnmap.xaml")]
        public void CopyTableColumnMapTest()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_columnmap.xaml");
                runner.Run();
                using (var sr = new StreamReader("test.csv"))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine().Trim();
                    Assert.AreEqual("1,4,AlbumId=1", line);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("CopyTable/copyalltables.xaml")]
        public void CopyAllTablesTest()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copyalltables.xaml");
                runner.Run();
            }
        }

        private void TestValue(string table, string idcol, string idval, string column, string value)
        {
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT [{0}] FROM [{1}] WHERE [{2}] = '{3}'", column, table, idcol, idval);
                    string realVal = cmd.ExecuteScalar().SafeToString();
                    Assert.AreEqual(value, realVal);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("CopyTable/mapped_import.xaml")]
        [DeploymentItem("CopyTable/ImportedData.csv")]
        public void MappedImportTest()
        {
            InitDatabase();
            RunEmbeddedScript("CopyTable.CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("mapped_import.xaml");
                runner.Run();
            }

            // bulk copy
            TestValue("ImportedData", "ID_IMPORTED", "1", "Data1", "a1");
            TestValue("ImportedData", "ID_IMPORTED", "3", "Data3", "c3");
            TestValue("ImportedData", "ID_IMPORTED", "4", "Data1", "a3");
            TestValue("ImportedData", "ID_IMPORTED", "6", "Data3", "c2");

            // inserts
            TestValue("ImportedData", "ID_IMPORTED", "7", "Data1", "a1");
            TestValue("ImportedData", "ID_IMPORTED", "9", "Data3", "c3");
            TestValue("ImportedData", "ID_IMPORTED", "10", "Data1", "a3");
            TestValue("ImportedData", "ID_IMPORTED", "12", "Data3", "c2");
        }

        [TestMethod]
        [DeploymentItem("CopyTable/copytable_xmltocsv.xaml")]
        [DeploymentItem("CopyTable/importedxml1.xml")]
        [DeploymentItem("CopyTable/importedxml2.xml")]
        [DeploymentItem("CopyTable/importedxml3.xml")]
        [DeploymentItem("CopyTable/importedxml4.xml")]
        public void XmlImportTest()
        {
            var instructions = XmlTableAnalyser.AnalyseFile("importedxml4.xml", true);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_xmltocsv.xaml");
                runner.Run();

                string output1 = File.ReadAllText("outputcsv1.csv");
                Assert.AreEqual("sub,attr,x,y,z\r\nA,a1,x1,y1,z1\r\nA,a2,x2,y2,z2\r\nB,a3,x3,y3,z3\r\nB,a4,x4,y4,z4\r\n", output1);

                string output2 = File.ReadAllText("outputcsv2.csv");
                Assert.AreEqual("x,y,z,x2,y2,z2\r\nx1,y1,z1,(NULL),(NULL),(NULL)\r\nx2,y2,z2,(NULL),(NULL),(NULL)\r\n(NULL),(NULL),(NULL),x3,y3,z3\r\n(NULL),(NULL),(NULL),x4,y4,z4\r\n", output2);

                string output3 = File.ReadAllText("outputcsv3.csv");
                Assert.AreEqual("x\r\nx1\r\nx2\r\nx3\r\n", output3);

                string output4 = File.ReadAllText("outputcsv4.csv");
                Assert.AreEqual("x,y,z\r\nxval,yval,zval\r\n", output4);

            }
        }
    }
}