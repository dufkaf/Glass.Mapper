﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Glass.Mapper.Tests
{
    [TestFixture]
    public class UtilitiesFixture
    {

        #region Method - CreateConstructorDelegates

        [Test]
        public void CreateConstructorDelegates_NoParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof (StubNoParameters);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result.First().Key.GetParameters().Count());
        }

        [Test]
        public void CreateConstructorDelegates_OneParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof(StubOneParameter);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.First().Key.GetParameters().Count());
        }

        [Test]
        public void CreateConstructorDelegates_TwoParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof(StubTwoParameters);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result.First().Key.GetParameters().Count());
        }

        [Test]
        public void CreateConstructorDelegates_ThreeParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof(StubThreeParameters);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, result.First().Key.GetParameters().Count());
        }

        [Test]
        public void CreateConstructorDelegates_FourParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof(StubFourParameters);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(4, result.First().Key.GetParameters().Count());
        }

        [Test]
        [ExpectedException(typeof(MapperException))]
        public void CreateConstructorDelegates_FiveParameters_CreatesSingleConstructor()
        {
            //Assign
            Type type = typeof(StubFiveParameters);

            //Act
            var result = Utilities.CreateConstructorDelegates(type);

            //Assert
        }

        #region Stubs

        public class StubNoParameters
        {
            public StubNoParameters()
            {
                
            }
        }

        public class StubOneParameter
        {
            public StubOneParameter(string param1)
            {

            }
        }

        public class StubTwoParameters
        {
            public StubTwoParameters(string param1, string param2)
            {

            }
        }

        public class StubThreeParameters
        {
            public StubThreeParameters(string param1, string param2, string param3)
            {

            }
        }

        public class StubFourParameters
        {
            public StubFourParameters(string param1, string param2, string param3, string param4)
            {

            }
        }

        public class StubFiveParameters
        {
            public StubFiveParameters(string param1, string param2, string param3, string param4, string param5)
            {

            }
        }

        #endregion

        #endregion

        #region Method - GetProperty

        [Test]
        public void GetProperty_GetPropertyOnClass_ReturnsProperty()
        {
            //Assign
            string name = "Property";
            Type type = typeof (StubClass);

            //Act
            var result = Utilities.GetProperty(type, name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);
        }

        [Test]
        public void GetProperty_GetPropertyOnSubClass_ReturnsProperty()
        {
            //Assign
            string name = "Property";
            Type type = typeof(StubSubClass);

            //Act
            var result = Utilities.GetProperty(type, name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);
        }

        [Test]
        public void GetProperty_GetPropertyOnInterface_ReturnsProperty()
        {
            //Assign
            string name = "Property";
            Type type = typeof (StubInterface);

            //Act
            var result = Utilities.GetProperty(type, name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);
        }

        [Test]
        public void GetProperty_GetPropertyOnSubInterface_ReturnsProperty()
        {
            //Assign
            string name = "Property";
            Type type = typeof(StubSubInterface);

            //Act
            var result = Utilities.GetProperty(type, name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(name, result.Name);
        }

        #endregion

        #region Stubs

        public class StubClass
        {
            public string Property { get; set; }
        }

        public class StubSubClass : StubClass
        {
        }

        public interface StubInterface
        {
            string Property { get; set; }
        }

        public interface StubSubInterface : StubInterface
        {
        }

        #endregion

    }
}
