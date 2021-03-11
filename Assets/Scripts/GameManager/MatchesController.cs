using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchesController : SingletonMonobehaviour<MatchesController>, ILevelResettable, INeedValidate
{
    #region <--- VARIABLES --->
    [Header("Settings: ")]
    [SerializeField] private int victoriesToWin = default;
    [SerializeField] private float delayToRestartMatch = default;
    [Header("For Debug: ")]
    [SerializeField] private int leftWinsCount = default;
    [SerializeField] private int rightWinsCount = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        if (!Validate()) gameObject.SetActive(false);
        OnReset();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool Validate()
    {
        if (victoriesToWin < 1)
        {
            Debug.LogError(this.name + " | victoriesToWin cannot be less than or equal to zero. I will disable the game object.");
            return false;
        }
        return true;
    }


    public void EndOfMatch(bool isLeftPoint)
    {
        PlatformsController.Instance.DisablePlatforms();
        UpdateScore(isLeftPoint);
        if (leftWinsCount == victoriesToWin)
            LeftWin();
        else if (rightWinsCount == victoriesToWin)
            RightWin();
        else
            RestartMatch();
    }


    public void RestartMatch() => StartCoroutine(RestartMatchCoroutine());


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
