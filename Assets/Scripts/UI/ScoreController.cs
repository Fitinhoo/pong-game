using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : SingletonMonobehaviour<ScoreController>, ILevelResettable, INeedValidate
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI leftScore = default;
    [SerializeField] private TextMeshProUGUI rightScore = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        if (!Validate()) gameObject.SetActive(false);
        OnReset();
    }


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void AddLeftScore() => leftScore.text += "| ";

    public void AddRightScore() => rightScore.text += "| ";

    public void OnReset() => leftScore.text = rightScore.text = "";

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public bool Validate()
    {
        if(leftScore == null)
        {
            Debug.LogError(this.name + " | leftScore cannot be null. I will disable the game object.");
            return false;
        }
        if(rightScore == null)
        {
            Debug.LogError(this.name + " | rightScore cannot be null. I will disable the game object.");
            return false;
        }
        return true;
    }



    #endregion
}
