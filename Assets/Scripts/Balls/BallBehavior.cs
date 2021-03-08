using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : SingletonMonobehaviour<BallBehavior>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private Transform actorTransform = default;
    [Header("Settings: ")]
    [SerializeField] private float speed = default;
    [SerializeField] private float minStartAngle = default;
    [SerializeField] private float maxStartAngle = default;
    [SerializeField] private bool showDebugLines = default;
    [Header("For Deubg: ")]
    [SerializeField] private bool isOffTheField = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    void Start()
    {
        isOffTheField = false;
        SetStartDirection();
    }


    void Update()
    {
        actorTransform.Translate(Vector3.right * Time.deltaTime * speed);

        if (GameFieldController.Instance.IsOffTheField(actorTransform.localPosition))
        {
            if (!isOffTheField)
            {
                if (GameFieldController.Instance.IsOffTheFieldHeight(actorTransform.localPosition)) ReverseMotion(Vector3.up);
                else ReverseMotion(Vector3.left);
            }
            isOffTheField = true;
        }
        else isOffTheField = false;
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void SetStartDirection()
    {
        Vector3 newRandomDirection = new Vector3(0, 0, Random.Range(minStartAngle, maxStartAngle));
        actorTransform.localRotation = Quaternion.Euler(newRandomDirection);
    }


    public void ReverseMotion(Vector3 normalDirection)
    {
        Vector3 newDirection = Vector3.Reflect(actorTransform.right, normalDirection);
        actorTransform.right = newDirection;
        if (showDebugLines) ShowDebugLines(normalDirection, newDirection);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    private void ShowDebugLines(Vector3 normalDirection, Vector3 newDirection)
    {
        Debug.DrawRay(actorTransform.position, normalDirection * 2, Color.blue, 2);
        Debug.DrawRay(actorTransform.position, newDirection * 2, Color.yellow, 2);
    }


    #endregion
}
