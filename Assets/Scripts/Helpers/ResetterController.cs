using UnityEngine;
using UnityEngine.Events;

public class ResetterController : SingletonMonobehaviour<ResetterController>
{
    public void ResetAll()
    {
        var resettables = InterfaceHelper.FindObjects<IResettable>();
        foreach (var resettable in resettables)
            resettable.OnReset();
    }
}

