using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : SingletonMonobehaviour<StartButtonController>, INeedValidate
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private GameObject actorUI = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        if (!Validate()) gameObject.SetActive(false);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool Validate()
    {
        if (actorUI == null)
        {
            Debug.LogError(this.name + " | actorUI cannot be null. I will disable the game object.");
            return false;
        }
        return true;
    }


    public void SetActive(bool value) => actorUI.SetActive(value);


    #endregion
}
