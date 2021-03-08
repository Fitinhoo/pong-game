using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlatformCollision : MonoBehaviour
{
    #region <--- VARIABLES --->
    [SerializeField] private LayerMask layerToCollide;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void OnCollisionEnter(Collision other)
    {
        if (layerToCollide == (1 << other.gameObject.layer))
        {
            Vector3 normalCollision = new Vector3(other.contacts[0].normal.x, other.contacts[0].normal.y, 0);
            BallBehavior.Instance.ReverseMotion(normalCollision);
        }
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    #endregion
}
