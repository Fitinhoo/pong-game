using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : SingletonMonobehaviour<ScoreController>, IResettable
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI leftScore = default;
    [SerializeField] private TextMeshProUGUI rightScore = default;
    public int LeftScoreCount { get; private set; } = default;
    public int RightScoreCount { get; private set; } = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        OnReset();
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void AddLeftScore()
    {
        LeftScoreCount++;
        leftScore.text += "| ";
    }


    public void AddRightScore()
    {
        RightScoreCount++;
        rightScore.text += "| ";
    }

    public void OnReset()
    {
        leftScore.text = rightScore.text = "";
        RightScoreCount = LeftScoreCount = 0;
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
