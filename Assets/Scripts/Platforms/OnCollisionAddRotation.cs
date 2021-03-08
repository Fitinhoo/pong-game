using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAddRotation : OnPlatformCollision
{
    #region <--- VARIABLES --->
    [SerializeField] private float rotationFactor = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void OnCollision(Collision other)
    {
        base.OnCollision(other);
        float distanceFromCenter = other.contacts[0].point.y - transform.position.y;
        BallBehavior.Instance.UpdateDirection(distanceFromCenter * rotationFactor);
    }


    #endregion
}
