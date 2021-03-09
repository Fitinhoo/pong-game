using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesController : SingletonMonobehaviour<MatchesController>, ILevelResettable
{
    #region <--- VARIABLES --->
    [Header("Settings: ")]
    [SerializeField] private float delayToRestartMatch = default;
    [Header("For Debug: ")]
    [SerializeField] private int leftWinsCount = default;
    [SerializeField] private int rightWinsCount = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        OnReset();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void RestartMatch() => StartCoroutine(RestartMatchCoroutine());


    public void EndOfMatch(bool isLeftPoint)
    {
        UpdateScore(isLeftPoint);
        if (leftWinsCount == 3)
            LeftWin();
        else if (rightWinsCount == 3)
            RightWin();
        else
            RestartMatch();
    }


    public void OnReset()
    {
        leftWinsCount = rightWinsCount = 0;
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private IEnumerator RestartMatchCoroutine()
    {
        yield return new WaitForSeconds(delayToRestartMatch);
        ResetterController.Instance.MatchResetAll();
    }


    private void UpdateScore(bool isLeftPoint)
    {
        if (isLeftPoint)
        {
            ScoreController.Instance.AddLeftScore();
            leftWinsCount++;
        }
        else
        {
            ScoreController.Instance.AddRightScore();
            rightWinsCount++;
        }
            
    }


    private void LeftWin()
    {
        WinTextController.Instance.LeftWin();
        LevelsController.Instance.NextLevel();
    }


    private void RightWin()
    {
        WinTextController.Instance.RightWin();
        LevelsController.Instance.RestartLevel();
    }


    #endregion
}
