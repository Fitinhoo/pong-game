using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldController : SingletonMonobehaviour<GameFieldController>
{
    #region <--- VARIABLES --->

    public float FieldHeight { get; private set; } = default;
    public float FieldWidth { get; private set; } = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        FieldHeight = 2f * Camera.main.orthographicSize;
        FieldWidth = FieldHeight * Camera.main.aspect;
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool IsOffTheFieldHeight(Vector3 pos) => Mathf.Abs(pos.y) >= FieldHeight / 2 == true ? true: false;

    public bool IsOffTheFieldWidth(Vector3 pos) => Mathf.Abs(pos.x) >= FieldWidth / 2 == true ? true : false;

    public bool IsOffTheField(Vector3 pos) => IsOffTheFieldHeight(pos) || IsOffTheFieldWidth(pos);

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
