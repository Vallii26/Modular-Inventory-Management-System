using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CSharpFinal;
using CSharpFinal.Entities;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class EquipmentsTests
    {
        /// <summary>
        /// This method returns true if the EOL of an equipment is within a 2 month range.
        /// </summary>
        [TestMethod]
        public void EquipmentsCloseToEOL_ReturnTrue_InEOLRange()
        {
            var equipment = new Equipments
            {
                EquipmentID = 1,
                EquipmentName = "Test Equipment",
                EOLDate = DateTime.Now.AddMonths(1)
            };

            var result = equipment.EquipmentsCloseToEOL();

            Assert.IsTrue(result, "Expected EquipmentsCloseToEOL to return true for EOL date within 2 months.");
        }

        /// <summary>
        /// This method tests if an equipment is outside the default 2 month range for EOL will return false.
        /// </summary>
        [TestMethod]
        public void EquipmentsCloseToEOL_ShouldReturnFalse_WhenEOLIsOutsideDefaultRange()
        {
            var equipment = new Equipments
            {
                EquipmentID = 2,
                EquipmentName = "Test Equipment",
                EOLDate = DateTime.Now.AddMonths(3)
            };

            var result = equipment.EquipmentsCloseToEOL();

            Assert.IsFalse(result, "Expected EquipmentsCloseToEOL to return false for EOL date greater than 2 months.");
        }

        /// <summary>
        /// If the EOL date range is specified than a equipment having a max range of four months should return true for 3 months.
        /// </summary>
        [TestMethod]
        public void EquipmentsCloseToEOL_ShouldReturnTrue_WhenEOLIsWithinSpecifiedRange()
        {
            var equipment = new Equipments
            {
                EquipmentID = 3,
                EquipmentName = "Test Equipment",
                EOLDate = DateTime.Now.AddMonths(3)
            };

            var result = equipment.EquipmentsCloseToEOL(4);

            Assert.IsTrue(result, "Expected EquipmentsCloseToEOL to return true for EOL date within 4 months.");
        }

        /// <summary>
        /// If the EOL date is null than the equipment should not be accepted.
        /// </summary>
        [TestMethod]
        public void EquipmentsCloseToEOL_ShouldReturnFalse_WhenEOLIsNull()
        {
            var equipment = new Equipments
            {
                EquipmentID = 4,
                EquipmentName = "Test Equipment",
                EOLDate = null
            };

            var result = equipment.EquipmentsCloseToEOL();

            Assert.IsFalse(result, "Expected EquipmentsCloseToEOL to return false for null EOL date.");
        }
    }
}