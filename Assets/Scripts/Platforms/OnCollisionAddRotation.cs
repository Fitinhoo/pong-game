using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAddRotation : OnPlatformCollision
{
    #region <--- VARIABLES --->
    [Header("Settings: ")]
    [SerializeField] private bool showDebugLines = default;
    [Header("For Debug: ")]
    [SerializeField] private float actorHeight = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        actorHeight = transform.localScale.y;
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    protected override void OnCollision(Collision other)
    {
        float distanceFromCenter = other.contacts[0].point.y - transform.position.y;
        float distanceFactor = (distanceFromCenter / (actorHeight / 2));

        float xDirection = 1 - Mathf.Abs(distanceFactor * 0.5f);
        float yDirection = 0 + ((distanceFactor * 0.5f));

        int invertDirectionMovement = BallBehavior.Instance.CurrentDirection.x < 0 ? 1 : -1;
        Vector2 newDirection = new Vector2(xDirection * invertDirectionMovement, yDirection);
        BallBehavior.Instance.ForceDirection(newDirection);
        if (showDebugLines) ShowDebugLines(newDirection);
    }


    private void ShowDebugLines(Vector2 newDirection)
    {
        Debug.DrawRay(BallBehavior.Instance.CurrentPosition, newDirection * 2, Color.blue, 2);
    }


    #endregion
}
