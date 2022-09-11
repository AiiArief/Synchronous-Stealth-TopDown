using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredActionVisionLook : StoredAction
{
    public StoredActionVisionLook(EntityCharacter entity, VisionLook visionLook)
    {
        action = () =>
        {
            actionHasDone = _CheckProcessInputHasOverMinimumTime();
            if (actionHasDone)
                return;

            visionLook.HandleVisionLookWaitInput();
        };
    }
}