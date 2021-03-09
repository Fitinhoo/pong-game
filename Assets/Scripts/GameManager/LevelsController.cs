using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    #region <--- VARIABLES --->
    [Header("Settings: ")]
    [SerializeField] private List<GameObject> levelsPrefab;
    [Header("For Debug:")]
    public int CurrentLevelIndex = default;
    public int CurrentLevel = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        CurrentLevel = 0;
        CurrentLevelIndex = 0;
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void StartLevel()
    {
        Instantiate(levelsPrefab[CurrentLevelIndex]);
        ResetterController.Instance.ResetAll();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>


    #endregion
}
