﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacterNPCGodDeveloperNote : EntityCharacterNPC
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
