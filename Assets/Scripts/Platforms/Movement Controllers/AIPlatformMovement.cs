using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlatformMovement : PlatformMovement
{
    #region <--- VARIABLES --->
    

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void Update()
    {
        base.Update();
        nextPosition = new Vector2(
            actorTransform.localPosition.x,
            BallBehavior.Instance.CurrentPosition.y);
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>



    #endregion
}
