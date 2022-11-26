using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacterNPC2D1BitSignPost : EntityCharacterNPC
{
    public override void WaitInput()
    {
        base.WaitInput();

        _DoIdle();
    }

    public override void AfterInput()
    {
        base.AfterInput();

        afterActionHasDone = true;
    }
}
