using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldController : SingletonMonobehaviour<GameFieldController>
{
    #region <--- VARIABLES --->

    public float FieldHeight { get; private set; } = default;
    public float FieldWidth { get; private set; } = default;

    private CameraSize cameraSizeScript = default;


    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void Awake()
    {
        base.Awake();
        cameraSizeScript = new CameraSize();
    }


    private void Start()
    {
        FieldHeight = cameraSizeScript.GetFieldHeight(Camera.main);
        FieldWidth = cameraSizeScript.GetFieldWidth(Camera.main);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool IsOffTheFieldHeight(Vector3 pos) => cameraSizeScript.IsOffTheFieldHeight(pos, Camera.main);

    public bool IsOffTheFieldWidth(Vector3 pos) => cameraSizeScript.IsOffTheFieldWidth(pos, Camera.main);

    public bool IsOffTheField(Vector3 pos) => cameraSizeScript.IsOffTheField(pos, Camera.main);

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}


public class CameraSize
{
    public float GetFieldHeight(Camera cam) => 2f * cam.orthographicSize;


    public float GetFieldWidth(Camera cam) => GetFieldHeight(cam) * cam.aspect;


    public bool IsOffTheFieldHeight(Vector3 point, Camera cam) => Mathf.Abs(point.y) >= ( GetFieldHeight(cam) / 2 ) ? true : false;


    public bool IsOffTheFieldWidth(Vector3 point, Camera cam) => Mathf.Abs(point.x) >= ( GetFieldWidth(cam) / 2 ) ? true : false;


    public bool IsOffTheField(Vector3 point, Camera cam) => IsOffTheFieldHeight(point, cam) || IsOffTheFieldWidth(point, cam);
}