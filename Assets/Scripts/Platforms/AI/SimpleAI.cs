using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private Transform actorTransform = default;
    [Header("Settings: ")]
    [SerializeField] private float minDistanceToMove = default;
    [SerializeField] private float speed = default;
    [SerializeField] private bool isAIEnabled = default;
    

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Update()
    {
        if(BallBehavior.Instance != null)
        {
            float currentBallYPos = BallBehavior.Instance.CurrentBallPosition().y;
            if(Mathf.Abs(currentBallYPos - actorTransform.localPosition.y) > minDistanceToMove)
            {
                float direction = currentBallYPos > actorTransform.localPosition.y ? 1 : -1;
                actorTransform.transform.localPosition += Vector3.up * direction * speed * Time.deltaTime;
            }
        }
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>



    #endregion
}
