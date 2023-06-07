using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Recording_studio;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string connectionString = @"Data Source=DESKTOP-OH72CL7\MSSQLSERVER01;Initial Catalog=Studio;Integrated Security=True";
        string username = "testuser";
        string lastname = "testuser";
        string login = "test@mail.ru";
        string pas1 = "123456";
        string pas2 = "123456";
        string usernameChange = "testuser1";
        string phone = "890476922699";
        [TestMethod]
        public void TestMethod1()
        {
            Registration registration = new Registration();
            

            bool registrationResult = registration.RegisterUser(username, lastname, login, pas1, pas2);


            Assert.IsTrue(registrationResult);
        }


        [TestMethod]
        public void TestMethod2()
        {
            Authorization authorization = new Authorization();


            bool authorizationResult = authorization.AuthorizeUser(login, pas2);


            Assert.IsTrue(authorizationResult);
        }

        [TestMethod]
        public void TestMethod3()
        {
            admin2 admin2 = new admin2();


            bool changeResult = admin2.ChangeUser(usernameChange, login, pas2);


            Assert.IsTrue(changeResult);
        }

        [TestMethod]
        public void TestMethod4()
        {
            admin2 admin2 = new admin2();


            bool deleteResult = admin2.DeleteUser( login, pas2);


            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Recording recording = new Recording();


            bool record = recording.Record(phone);


            Assert.IsTrue(record);
        }

    }
}
