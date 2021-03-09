using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTextController : SingletonMonobehaviour<WinTextController>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI actorUI = default;
    [Header("Settings: ")]
    [SerializeField] private string leftWinText = default;
    [SerializeField] private string rightWinText = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        SetActive(false);
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void SetActive(bool status) => actorUI.gameObject.SetActive(status);


    public void LeftWin()
    {
        SetActive(true);
        actorUI.text = leftWinText;
    }


    public void RightWin()
    {
        SetActive(true);
        actorUI.text = rightWinText;
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>



    #endregion
}
