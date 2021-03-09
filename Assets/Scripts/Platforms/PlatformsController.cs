using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour, IResettable
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

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        foreach (platformStruct platform in levelPlatforms)
            platform.movementScript.SetPlatformTransform(platform.actorTransform);
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void OnReset()
    {
        float halfWidth = GameFieldController.Instance.FieldWidth / 2;
        foreach (platformStruct platform in levelPlatforms)
        {
            platform.actorTransform.gameObject.SetActive(true);
            platform.actorTransform.transform.localPosition = new Vector3(halfWidth * platform.distanceFromTheCenterPercentage, 0, 0);
        }
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
