using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformMovement : MonoBehaviour
{
    #region <--- VARIABLES --->
    protected Transform actorTransform = default;
    [Header("Settings: ")]
    [SerializeField] protected float speed = default;
    [SerializeField] protected float minDistanceToMove = default;
    protected Vector3 nextPosition = default;
    protected bool isMoveEnabled = default;


    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        isMoveEnabled = false;
    }


    protected virtual void Update()
    {
        if(isMoveEnabled) Move();
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void SetPlatformTransform(Transform obj) => actorTransform = obj;

    public void SetEnabled(bool status) => isMoveEnabled = status;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Move()
    {

        if (Vector3.Distance(nextPosition, actorTransform.localPosition) > minDistanceToMove)
        {
            Vector3 direction = (nextPosition - actorTransform.localPosition).normalized;
            actorTransform.transform.localPosition += direction * speed * Time.deltaTime;
        }
    }


    #endregion
}
