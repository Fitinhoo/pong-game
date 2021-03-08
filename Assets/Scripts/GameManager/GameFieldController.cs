using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldController : SingletonMonobehaviour<GameFieldController>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private Transform leftPlatform = default;
    [SerializeField] private Transform rightPlatform = default;
    public float FieldHeight { get; private set; } = default;
    public float FieldWidth { get; private set; } = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        FieldHeight = 2f * Camera.main.orthographicSize;
        FieldWidth = FieldHeight * Camera.main.aspect;

        if (Validate())
        {
            leftPlatform.transform.localPosition = new Vector3((FieldWidth / 2) * -1 * 0.9f, 0, 0);
            rightPlatform.transform.localPosition = new Vector3((FieldWidth / 2) * 0.9f, 0, 0);
        }
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool IsOffTheFieldHeight(Vector3 pos) => Mathf.Abs(pos.y) >= FieldHeight / 2 == true ? true: false;

    public bool IsOffTheFieldWidth(Vector3 pos) => Mathf.Abs(pos.x) >= FieldWidth / 2 == true ? true : false;

    public bool IsOffTheField(Vector3 pos) => IsOffTheFieldHeight(pos) || IsOffTheFieldWidth(pos);

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private bool Validate()
    {
        if (leftPlatform != null && rightPlatform != null) return true;
        Debug.LogError(this.name + " | The platforms have not been referenced");
        return false;
    }


    #endregion
}
