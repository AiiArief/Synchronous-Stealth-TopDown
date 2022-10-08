using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    protected List<Entity> entities { get; private set; } = new List<Entity>();

    public virtual void SetupEntitiesOnLevelStart()
    {
        _AssignEntities();
    }

    public virtual void SetupEntitiesOnWaitInputStart()
    {
        for(int i=0; i<entities.Count; i++)
        {
            if (entities[i].isUpdateAble)
            {
                entities[i].SetupWaitInput();
            }
        }
    }

    public virtual bool CheckEntitiesHasDoneWaitInput()
    {
        for(int i=0; i<entities.Count; i++)
        {
            if (entities[i].isUpdateAble && entities[i].storedActions.Count == 0)
            {
                entities[i].WaitInput();
            }
        }

        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble && entities[i].storedActions.Count == 0)
            {
                return false;
            }
        }

        return true;
    }

    public virtual void SetupEntitiesOnProcessInputStart()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if(entities[i].isUpdateAble)
            {
                entities[i].SetupProcessInput();
            }
        }
    }

    public virtual bool CheckEntitiesHasDoneProcessInput()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble && !entities[i].CheckAllActionHasDone())
            {
                for(int j=0; j<entities[i].storedActions.Count; j++)
                {
                    if (!entities[i].storedActions[j].actionHasDone)
                    {
                        entities[i].storedActions[j].action.Invoke();
                    }
                }
            }
        }

        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble && !entities[i].CheckAllActionHasDone())
            {
                return false;
            }
        }

        return true;
    }

    public virtual void SetupEntitiesOnAfterInputStart()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if(entities[i].isUpdateAble)
            {
                entities[i].SetupAfterInput();
            }
        }
    }

    public virtual bool CheckEntitiesHasDoneAfterInput()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble)
            {
                entities[i].AfterInput();
            }
        }

        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble && !entities[i].afterActionHasDone)
            {
                return false;
            }
        }

        return true;
    }

    public void DebugProcessInputCheckEntitiesHasDone()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            if (entities[i].isUpdateAble && !entities[i].CheckAllActionHasDone())
            {
                for (int j = 0; j < entities[i].storedActions.Count; j++)
                {
                    if (!entities[i].storedActions[j].actionHasDone)
                    {
                        Debug.LogError("Entity has done : " + entities[i] + " - " + entities[i].storedActions[j]);
                    }
                }
            }
        }
    }

    protected virtual void _AssignEntities()
    {
        foreach (Transform child in transform)
        {
            Entity entity = child.GetComponent<Entity>();
            if (entity)
            {
                entities.Add(entity);
            }
        }
    }
}
