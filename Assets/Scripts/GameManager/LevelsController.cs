using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public void StartLevel()
    {
        ResetterController.Instance.ResetAll();
    }
}
