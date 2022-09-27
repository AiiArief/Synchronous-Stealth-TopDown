using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityEvent : Entity
{
    protected UIManager um;
    protected EntityManagerEvent em;
    protected EntityCharacterPlayer player;

    public virtual void EventOnLoadLevel()
    {
        _BasicOnLoadLevel();
    }

    StoredStatusEffect[] m_eventStatusEffects;
    public void AddBasicStatusEffectOnStartingEvent()
    {
        m_eventStatusEffects = new StoredStatusEffect[2] { new StoredStatusEffectEventControl(player), new StoredStatusEffectAutoSkip(player) };
        player.storedStatusEffects.AddRange(m_eventStatusEffects);
    }

    public void RemoveBasicStatusEffectOnFinishEvent()
    {
        if (m_eventStatusEffects.Length > 0)
        {
            foreach (StoredStatusEffect eventStatusEffect in m_eventStatusEffects)
            {
                eventStatusEffect.isGoingToBeRemovedFlag = true;
            }
        }
    }

    protected virtual void _BasicOnLoadLevel()
    {
        um = GameManager.Instance.uiManager;
        em = GameManager.Instance.eventManager;
        player = GameManager.Instance.playerManager.GetMainPlayer();
    }

    protected void _TeleportPlayerToCheckpoint(int checkpointId)
    {
        int tempCheckpointId = checkpointId;
        if (em.currentcheckpoint >= em.triggerCheckpoints.Length)
        {
            Debug.LogError("Checkpoint invalid in this scene, will set checkpointid to 0 : " + checkpointId);
            tempCheckpointId = 0;
        }

        TriggerCheckpoint checkpoint = em.triggerCheckpoints[tempCheckpointId];

        LevelManager levelManager = GameManager.Instance.levelManager;
        LevelGrid grid = levelManager.GetClosestGridFromPosition(checkpoint.transform.position);
        LevelGridNode checkpointNode = grid.ConvertPosToNode(checkpoint.transform.position);
        player.currentNode.entityListOnThisNode.Remove(player);
        player.AssignToLevelGrid(checkpointNode);
        player.transform.position = checkpointNode.realWorldPos;
        player.transform.rotation = Quaternion.Euler(new Vector3(0.0f, checkpoint.startRotation, 0.0f));
    }

    protected void _TeleportPlayerToScene(SceneLevel sceneLevel, bool saveToo = true, int checkpointId = 0)
    {
        if(saveToo)
        {
            PlayerPrefs.SetString(ProfileManager.PLAYERPREFS_CURRENTSCENE, sceneLevel.sceneName);
            PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_CURRENTSCENECHECKPOINT, checkpointId);
        }

        SceneManager.LoadScene(sceneLevel.scenes[0]);
        for(int i=1; i<sceneLevel.scenes.Length; i++)
        {
            SceneManager.LoadScene(sceneLevel.scenes[i], new LoadSceneParameters(LoadSceneMode.Additive, sceneLevel.physicsModes[i]));
        }
    }
}
