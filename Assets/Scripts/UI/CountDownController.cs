using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountDownController : SingletonMonobehaviour<CountDownController>
{
    #region <--- VARIABLES --->
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI actorUI = default;
    [Header("Settings: ")]
    [SerializeField] private int startCountdownNumber = default;
    [SerializeField] private float smoothAnimationFactor = default;
    [Header("Events: ")]
    [SerializeField] private UnityEvent countdownFinished = default;

    #endregion
    #region <~~*~~*~~*~~*~~*~~* ENGINE METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private void Start()
    {
        actorUI.gameObject.SetActive(false);
    }

    #endregion
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void StartCountdown() => StartCoroutine(CountdownCoroutine());


    #endregion
    #region <~~*~~*~~*~~*~~*~~* PRIVATE METHODS  ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    private IEnumerator CountdownCoroutine()
    {
        actorUI.gameObject.SetActive(true);
        for(int i = startCountdownNumber; i > 0; i--)
        {
            actorUI.text = i.ToString();
            for(float j = 1; j > 0; j -= smoothAnimationFactor)
            {
                actorUI.rectTransform.localScale = Vector3.one * j;
                yield return new WaitForSeconds(smoothAnimationFactor);
            }
        }

        countdownFinished?.Invoke();
    }

    #endregion
}
