using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityCharacter : Entity
{
    [SerializeField] Animator m_animator;
    public Animator animator { get { return m_animator; } }
    protected float m_currentAnimatorSpeed = 0.0f;

    public CharacterController characterController { get; private set; }
    [SerializeField] bool m_detectCollisionOnStart = true;

    public float gravityPerTurn = 3.0f;

    public LevelGridNode currentNode { get; private set; }

    public List<StoredStatusEffect> storedStatusEffects { get; private set; } = new List<StoredStatusEffect>();

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();

        m_currentAnimatorSpeed = animator.speed;
        animator.speed = 0;
    }

    public override void WaitInput()
    {
        foreach (StoredStatusEffect effect in storedStatusEffects)
        {
            effect.effectAction.Invoke();
        }
    }

    public override void SetupProcessInput()
    {
        base.SetupProcessInput();

        animator.speed = m_currentAnimatorSpeed;
    }

    public override void AfterInput()
    {
        foreach (StoredStatusEffect effect in storedStatusEffects.ToArray())
        {
            effect.effectRemovalAction.Invoke();
        }
    }

    public override void SetIsUpdateAble(bool isUpdateAble)
    {
        base.SetIsUpdateAble(isUpdateAble);

        if (isUpdateAble)
            _AssignComponent();
    }

    public virtual void StoredActionSkipTurn()
    {
        storedActions.Add(new StoredActionSkip());
        if (characterController.enabled) storedActions.Add(new StoredActionMove(this));
    }

    public void AssignToLevelGrid(LevelGridNode node = null)
    {
        currentNode = node;
        if (node == null)
        {
            LevelGrid tempGrid = GameManager.Instance.levelManager.GetClosestGridFromPosition(transform.position);
            LevelGridNode tempGridNode = tempGrid.ConvertPosToNode(transform.position);
            currentNode = tempGridNode;
        }

        currentNode.entityListOnThisNode.Add(this);
    }

    protected virtual void _AssignComponent()
    {
        if (!characterController)
        {
            characterController = GetComponent<CharacterController>();
            characterController.detectCollisions = m_detectCollisionOnStart;
        }
    }
}
