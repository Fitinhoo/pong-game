using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputPlatformMovement : PlatformMovement
{
    #region <--- VARIABLES --->
    [SerializeField] private bool useWorldPositions = default;
    private Vector2 startInputPos = default;
    private Vector2 startPlatformPos = default;
    private Vector2 distanceFromStartPos = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void Update()
    {
        base.Update();
        CheckInput();
        nextPosition = new Vector2(
            actorTransform.localPosition.x,
            startPlatformPos.y + distanceFromStartPos.y);
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoveEnabled = true;
            startInputPos = GetInputPosition();
            startPlatformPos = actorTransform.localPosition;
        }
            
        if (Input.GetMouseButton(0)) UpdateInputPosition();
    }


    private void UpdateInputPosition()
    {
        Vector2 currentPosition = GetInputPosition();
        distanceFromStartPos = new Vector2(
           currentPosition.x - startInputPos.x,
           currentPosition.y - startInputPos.y
            );
    }


    private Vector2 GetInputPosition() => useWorldPositions ? Camera.main.ScreenToWorldPoint(Input.mousePosition) : Input.mousePosition;

    #endregion
}
