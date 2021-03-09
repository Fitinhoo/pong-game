using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : SingletonMonobehaviour<LevelsController>
{
    #region <--- VARIABLES --->
    [Header("Settings: ")]
    [SerializeField] private List<GameObject> levelsPrefab = default;
    [SerializeField] private float delayToRestartLevel = default;
    [SerializeField] private int forceStartWithLevelIndex = default;
    [SerializeField] private bool instantiateRandomAfterTheLast = default;
    [Header("For Debug:")]
    [SerializeField] private GameObject currentlevelObject = default;
    public int CurrentLevelIndex = default;
    public int CurrentLevel = default;
    private bool randomLevelsEnabled = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        randomLevelsEnabled = false;
        CurrentLevel = 1;
        if(forceStartWithLevelIndex != -1)
            CurrentLevelIndex = forceStartWithLevelIndex;
        else
            CurrentLevelIndex = 0;
        LevelTextController.Instance.UpdateLevelNumber();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void StartLevel()
    {
        if (currentlevelObject != null) Destroy(currentlevelObject);
        currentlevelObject = Instantiate(levelsPrefab[CurrentLevelIndex]);
        ResetterController.Instance.LevelResetAll();
    }


    public void NextLevel()
    {
        CurrentLevel++;
        SetNextCurrentLevelIndex();
        Destroy(currentlevelObject);
        ScoreController.Instance.OnReset();
        StartCoroutine(StartLevelCoroutine());
    }


    public void RestartLevel()
    {
        Destroy(currentlevelObject);
        ScoreController.Instance.OnReset();
        StartCoroutine(StartLevelCoroutine());
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private IEnumerator StartLevelCoroutine()
    {
        yield return new WaitForSeconds(delayToRestartLevel);
        LevelTextController.Instance.UpdateLevelNumber();
        WinTextController.Instance.SetActive(false);
        CountDownController.Instance.StartCountdown();
    }


    private void SetNextCurrentLevelIndex()
    {
        if (randomLevelsEnabled)
            CurrentLevelIndex = Random.Range(0, levelsPrefab.Count);
        else
        {
            if (levelsPrefab.Count <= CurrentLevelIndex + 1)
            {
                if (instantiateRandomAfterTheLast)
                {
                    randomLevelsEnabled = true;
                    CurrentLevelIndex = Random.Range(0, levelsPrefab.Count);
                }
                else
                    CurrentLevelIndex = 0;
            }
            else
                CurrentLevelIndex++;
        }
    }

    #endregion
}
