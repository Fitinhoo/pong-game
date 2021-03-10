using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class GameFieldTests
{
    [Test]
    public void CheckGameField_PointOffTheHeight_01()
    {
        Camera camera = Camera.main;
        CameraSize cameraSizeScript = new CameraSize();

        Vector3 point = new Vector3(0,10,0);
        bool expectedResult = true;
        
        bool result = cameraSizeScript.IsOffTheFieldHeight(point, camera);

        Assert.AreEqual(expectedResult, result);
    }


    [Test]
    public void CheckGameField_PointOffTheHeight_02()
    {
        Camera camera = Camera.main;
        CameraSize cameraSizeScript = new CameraSize();

        Vector3 point = new Vector3(0, 5, 0);
        bool expectedResult = false;

        bool result = cameraSizeScript.IsOffTheFieldHeight(point, camera);

        Assert.AreEqual(expectedResult, result);
    }


    [Test]
    public void CheckGameField_PointOffTheWidth_01()
    {
        Camera camera = Camera.main;
        CameraSize cameraSizeScript = new CameraSize();

        Vector3 point = new Vector3(25, 0, 0);
        bool expectedResult = true;

        bool result = cameraSizeScript.IsOffTheFieldWidth(point, camera);

        Assert.AreEqual(expectedResult, result);
    }


    [Test]
    public void CheckGameField_PointOffTheWidth_02()
    {
        Camera camera = Camera.main;
        CameraSize cameraSizeScript = new CameraSize();

        Vector3 point = new Vector3(0, 0, 0);
        bool expectedResult = false;

        bool result = cameraSizeScript.IsOffTheFieldWidth(point, camera);

        Assert.AreEqual(expectedResult, result);
    }
}
