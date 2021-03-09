using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextController : SingletonMonobehaviour<LevelTextController>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI actorUI = default;
    [Header("Settings: ")]
    [SerializeField] private string beforeText = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void UpdateLevelNumber() => actorUI.text = beforeText + LevelsController.Instance.CurrentLevel.ToString();

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
