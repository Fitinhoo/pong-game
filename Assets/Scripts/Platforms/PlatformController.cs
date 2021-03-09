using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour, IResettable
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private Transform leftPlatform = default;
    [SerializeField] private Transform rightPlatform = default;
    [Header("Settings: ")]
    [SerializeField] private float distanceFromTheCenterFactor = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        Validate();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void OnReset()
    {
        leftPlatform.gameObject.SetActive(true);
        rightPlatform.gameObject.SetActive(true);
        float halfWidth = GameFieldController.Instance.FieldWidth / 2;
        leftPlatform.transform.localPosition = new Vector3(halfWidth * -1 * distanceFromTheCenterFactor, 0, 0);
        rightPlatform.transform.localPosition = new Vector3(halfWidth * distanceFromTheCenterFactor, 0, 0);
    }



    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private bool Validate()
    {
        if (leftPlatform != null && rightPlatform != null) return true;
        Debug.LogError(this.name + " | The platforms have not been referenced");
        return false;
    }


    #endregion
}
