using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : SingletonMonobehaviour<StartButtonController>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private GameObject actorUI = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void SetActive(bool value) => actorUI.SetActive(value);


    #endregion
}
