using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : SingletonMonobehaviour<PlatformsController>, IMatchResettable
{
    [System.Serializable] private struct platformStruct
    {
        public Transform actorTransform;
        public float distanceFromTheCenterPercentage;
        public PlatformMovement movementScript;
    }

    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private List<platformStruct> levelPlatforms = default;
    private float halfWidth = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        halfWidth = GameFieldController.Instance.FieldWidth / 2;
        foreach (platformStruct platform in levelPlatforms)
        {
            platform.movementScript?.SetPlatformTransform(platform.actorTransform);
            platform.actorTransform.transform.localPosition = new Vector3(halfWidth * platform.distanceFromTheCenterPercentage, 0, 0);
        }
            
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void OnReset()
    {
        foreach (platformStruct platform in levelPlatforms)
        {
            platform.actorTransform.gameObject.SetActive(true);
            platform.actorTransform.transform.localPosition = new Vector3(halfWidth * platform.distanceFromTheCenterPercentage, 0, 0);
            platform.movementScript?.OnReset();
        }
    }


    public void DisablePlatforms()
    {
        foreach (platformStruct platform in levelPlatforms)
            platform.actorTransform.gameObject.SetActive(false);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
