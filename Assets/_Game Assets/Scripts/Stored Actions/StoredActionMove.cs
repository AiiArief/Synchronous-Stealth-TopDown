using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum MoveHitType
{
    NoHit, FullHit, InteractHit, HalfBodyHit, StruggleMove
}

public class StoredActionMove : StoredAction
{
    public StoredActionMove(EntityCharacter entity)
    {
        Vector3 m_posBeforeMove = entity.transform.position;
        float gravitySpeed = _CalcGravitySpeed(entity.gravityPerTurn);

        action = () =>
        {
            entity.characterController.Move(Vector3.down * gravitySpeed * Time.deltaTime);
            if(entity.animator.runtimeAnimatorController) entity.animator.SetInteger("moveRange", 0);
            actionHasDone = _CheckProcessInputHasOverMinimumTime();
        };
    }

    public StoredActionMove(EntityCharacter entity, Vector3 direction, bool isWorldDir, int range = 1)
    {
        Transform transform = entity.transform;
        LevelManager levelManager = GameManager.Instance.levelManager;
        LevelGridNode currentNode = entity.currentNode;

        Vector3 localTarget = ((isWorldDir) ? Vector3.right : transform.right) * direction.x +
                              ((isWorldDir) ? Vector3.forward : transform.forward) * direction.z;
        float moveSpeed = 1.0f / GameManager.Instance.phaseManager.processInput.minimumTimeBeforeNextPhase;
        float gravitySpeed = _CalcGravitySpeed(entity.gravityPerTurn);

        currentNode.entityListOnThisNode.Remove(entity);
        int calculatedRange = 0;
        MoveHitType moveHitType = MoveHitType.NoHit;
        TagEntityInteractable interactedEntity = null;
        for (int i = 0; i < range; i++)
        {
            if (!_CheckAbleToMove(entity))
            {
                moveHitType = MoveHitType.StruggleMove;
                break;
            }

            Vector3 nextPos = new Vector3(currentNode.realWorldPos.x + Mathf.RoundToInt(localTarget.x), transform.position.y, currentNode.realWorldPos.z + Mathf.RoundToInt(localTarget.z));
            LevelGrid tempGrid = levelManager.GetClosestGridFromPosition(nextPos);
            if (tempGrid == null) break;

            LevelGridNode tempGridNode = tempGrid.ConvertPosToNode(nextPos);
            if (tempGridNode == null) break;

            interactedEntity = tempGridNode.CheckListEntityHaveComponent<TagEntityInteractable>();
            if (calculatedRange == 0 && interactedEntity && interactedEntity.enabled && interactedEntity.CheckInteractDirection(direction))
            {
                moveHitType = MoveHitType.InteractHit;                
                break;
            }

            var unpass = tempGridNode.CheckListEntityHaveComponent<TagEntityUnpassable>();
            if (tempGridNode.isStaticNode || (unpass && unpass.enabled))
            {
                if(calculatedRange == 0)
                    moveHitType = MoveHitType.FullHit; // nanti cek tinggi collider
                break;
            }

            calculatedRange++;
            currentNode = tempGridNode;
        }

        entity.AssignToLevelGrid(currentNode);

        action = () =>
        {
            if (!_CheckAbleToMove(entity))
            {
                actionHasDone = true;
                return;
            }

            Vector3 target = new Vector3(currentNode.realWorldPos.x, transform.position.y, currentNode.realWorldPos.z);
            _HandleMoveHitCondition(entity, calculatedRange, moveHitType, interactedEntity);

            if (Vector3.Distance(transform.position, target) > 0.1f && !_CheckProcessInputHasOverMinimumTime())
            {
                entity.characterController.Move(localTarget * range * moveSpeed * Time.deltaTime + Vector3.down * gravitySpeed * Time.deltaTime);
            }
            else
            {
                if(calculatedRange > 0)
                    entity.GetComponent<TagEntityFootStepAble>()?.Step(currentNode, calculatedRange > 1);

                transform.position = new Vector3(target.x, entity.transform.position.y, target.z);
                actionHasDone = true;
            }
        };
    }

    private bool _CheckAbleToMove(EntityCharacter entity)
    {
        var disableMoveInputList = entity.storedStatusEffects.OfType<StoredStatusEffectCaptured>();
        foreach (var effect in disableMoveInputList)
        {
            if (effect.disableMove)
                return false;
        }

        return true;
    }

    private float _CalcGravitySpeed(float gravityPerTurn)
    {
        return gravityPerTurn / GameManager.Instance.phaseManager.processInput.minimumTimeBeforeNextPhase;
    }

    bool m_hasInteracted = false;
    private void _HandleMoveHitCondition(EntityCharacter entity, int calculatedRange, MoveHitType moveHitType, TagEntityInteractable interactedEntity)
    {
        // instantiate effek nabrak? atau balikin di animator aja?
        switch (moveHitType)
        {
            case MoveHitType.NoHit:
                entity.animator.SetInteger("moveRange", calculatedRange);
                break;
            case MoveHitType.FullHit:
                entity.animator.SetTrigger("hit");
                entity.animator.SetInteger("moveRange", calculatedRange);
                break;
            case MoveHitType.InteractHit:
                if(!m_hasInteracted)
                {
                    entity.animator.SetTrigger("interact");
                    entity.animator.SetInteger("moveRange", calculatedRange);
                    interactedEntity.Interact(entity);
                    m_hasInteracted = true;
                }
                break;
        }
    }
}
