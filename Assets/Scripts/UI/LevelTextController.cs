using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTextController : SingletonMonobehaviour<LevelTextController>, INeedValidate
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI actorUI = default;
    [Header("Settings: ")]
    [SerializeField] private string beforeText = default;


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


    public void UpdateLevelNumber() => actorUI.text = beforeText + LevelsController.Instance.CurrentLevel.ToString();


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
