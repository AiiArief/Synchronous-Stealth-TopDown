using System.Collections;
using UnityEngine;

public class StoredActionLevelFX : StoredAction
{
    public StoredActionLevelFX(EntityLevelFX levelFX)
    {
        action = () =>
        {
            levelFX.HandleSkyBox();
            levelFX.HandleWindEffect();
            levelFX.HandleFX();
            actionHasDone = _CheckProcessInputHasOverMinimumTime();
        };
    }
}