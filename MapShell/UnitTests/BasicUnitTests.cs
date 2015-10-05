//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MapShell;


//namespace UnitTests
//{
//    [TestClass]
//    public class BasicUnitTests
//    {
//        [TestMethod]
//        public void TestingManeuverMethods()
//        {
//            Maneuver testingData = new Maneuver();
//            Maneuver testingDataFromJson = new Maneuver();

//            PopulateInformation(); //Setting testingData variable to hardcoded data to test against what we pull from JSon file 

//            if (testingData.distanceBetweenPoints != testingDataFromJson.distanceBetweenPoints)
//            {
//                throw new Exception("distance between points does not match");
//            }
//            if (testingData.roadName != testingDataFromJson.roadName)
//            {
//                throw new Exception("roadName does not match");
//            }

//            if (testingData.turningDirection != testingDataFromJson.turningDirection)
//            {
//                throw new Exception("turning direction does not match");
//            }

//            if (testingData.turningIcon != testingDataFromJson.turningIcon)
//            {
//                throw new Exception("turning Icon does not match");
//            }

//            if (testingData.writtenDirection != testingDataFromJson.writtenDirection)
//            {
//                throw new Exception("written direction does not match");
//            }

//            if (testingData.tollRoad != testingDataFromJson.tollRoad)
//            {
//                throw new Exception("toll road does not match");
//            }


//        }



//    }
//}
