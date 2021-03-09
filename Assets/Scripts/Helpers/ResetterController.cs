using UnityEngine;
using UnityEngine.Events;

public class ResetterController : SingletonMonobehaviour<ResetterController>
{
    #region <~~*~~*~~*~~*~~*~~* PUBLIC METHODS   ~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*>
    public void LevelResetAll()
    {
        var resettables = InterfaceHelper.FindObjects<ILevelResettable>();
        foreach (var resettable in resettables)
            resettable.OnReset();
    }


    public void MatchResetAll()
    {
        var resettables = InterfaceHelper.FindObjects<IMatchResettable>();
        foreach (var resettable in resettables)
            resettable.OnReset();
    }


    #endregion
}

