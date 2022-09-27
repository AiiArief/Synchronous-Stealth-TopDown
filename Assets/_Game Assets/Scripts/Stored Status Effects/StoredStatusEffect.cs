using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoredStatusEffect
{
    // spell id buat cek ke database
    public Action effectAction;
    public Action effectRemovalAction;
    public bool isGoingToBeRemovedFlag = false;
}

public class StoredStatusEffectCustom : StoredStatusEffect
{
    public StoredStatusEffectCustom(Action customEffectAction, Action customEffectRemovalAction)
    {
        effectAction = customEffectAction;
        effectRemovalAction = customEffectRemovalAction;
    }
}

public class StoredStatusEffectAutoSkip : StoredStatusEffect
{
    public StoredStatusEffectAutoSkip(EntityCharacter target, float autoTime = 0.0f, int turnCount = -1)
    {
        float currentAutoTime = autoTime;
        effectAction = () =>
        {
            currentAutoTime = Mathf.Max(0.0f, currentAutoTime - Time.deltaTime);
            if (currentAutoTime <= 0.0f)
            {
                target.StoredActionSkipTurn();
            }
        };

        effectRemovalAction = () =>
        {
            turnCount = (turnCount < 0) ? turnCount : Mathf.Max(0, turnCount - 1);
            currentAutoTime = autoTime;

            if(turnCount == 0 || isGoingToBeRemovedFlag)
            {
                target.storedStatusEffects.Remove(this);
            }
        };
    }
}

public class StoredStatusEffectDisableMoveInput : StoredStatusEffect
{
    public bool disableMove { get; private set; } = true;
    public bool disableTurn { get; private set; } = true;

    public StoredStatusEffectDisableMoveInput(EntityCharacter entity, int turnCount = -1, bool disableMove = true, bool disableTurn = true)
    {
        this.disableMove = disableMove;
        this.disableTurn = disableTurn;

        effectAction = () =>
        {
        };

        effectRemovalAction = () =>
        {
            turnCount = (turnCount < 0) ? turnCount : Mathf.Max(0, turnCount - 1);
            if (turnCount == 0 || isGoingToBeRemovedFlag)
            {
                entity.storedStatusEffects.Remove(this);
            }
        };
    }
}

public class StoredStatusEffectCaptured : StoredStatusEffectDisableMoveInput
{
    public StoredStatusEffectCaptured(EntityCharacter entity, int turnCount = -1, bool disableMove = true, bool disableTurn = true) : base(entity, turnCount, disableMove, disableTurn)
    {
        entity.animator.SetBool("isCaptured", true);
        effectAction = () =>
        {
        };

        effectRemovalAction = () =>
        {
            turnCount = (turnCount < 0) ? turnCount : Mathf.Max(0, turnCount - 1);
            if (turnCount == 0 || isGoingToBeRemovedFlag)
            {
                entity.animator.SetBool("isCaptured", false);
                entity.storedStatusEffects.Remove(this);
            }
        };
    }

    public StoredStatusEffectCaptured(EntityCharacterPlayer player, EntityCharacter byWhom) : base(player)
    {
        player.animator.SetBool("isCaptured", true);
        GameManager.Instance.eventManager.genericEvent.PlayerIsCapturedEvent(byWhom as EntityCharacterNPC);
        effectAction = () =>
        {
        };

        effectRemovalAction = () =>
        {
        };
    }
}

public class StoredStatusEffectEventControl : StoredStatusEffectDisableMoveInput
{
    public StoredStatusEffectEventControl(EntityCharacter entity, int turnCount = -1, bool disableMove = true, bool disableTurn = true) : base(entity, turnCount, disableMove, disableTurn)
    {
        effectAction = () =>
        {
            // release animator
        };

        effectRemovalAction = () =>
        {
            turnCount = (turnCount < 0) ? turnCount : Mathf.Max(0, turnCount - 1);
            if (turnCount == 0 || isGoingToBeRemovedFlag)
            {
                // balikin ke animator sebelum cutscene
                entity.storedStatusEffects.Remove(this);
            }
        };
    }
}
