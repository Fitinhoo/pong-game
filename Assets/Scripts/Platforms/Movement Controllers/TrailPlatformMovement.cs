using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPlatformMovement : PlatformMovement
{
    #region <--- VARIABLES --->
    [SerializeField] List<Vector3> pointsList = default;
    [SerializeField] private bool isLooping = default;
    private int currentPointIndex = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(nextPosition, actorTransform.localPosition) <= minDistanceToMove)
        {
            if (currentPointIndex + 1 >= pointsList.Count)
            {
                if (isLooping) currentPointIndex = 0;
                else enabled = false;
            }
            else currentPointIndex++;
            nextPosition = pointsList[currentPointIndex];
        }
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public override void OnReset()
    {
        currentPointIndex = 0;
        nextPosition = pointsList[currentPointIndex];
        SetEnabled(true);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>



    #endregion
}
