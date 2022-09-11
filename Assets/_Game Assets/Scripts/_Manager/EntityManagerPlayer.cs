using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManagerPlayer : EntityManager
{
    [SerializeField] int playerCountOnLevelStart = 1;

    public override void SetupEntitiesOnLevelStart()
    {
        base.SetupEntitiesOnLevelStart();
        _AssignPlayersToGrid();
        _SetPlayersIsActive();
    }

    public EntityCharacterPlayer GetMainPlayer() { return entities[0] as EntityCharacterPlayer; }
    public List<EntityCharacterPlayer> GetPlayerPlayableList()
    {
        var playablePlayers = new List<EntityCharacterPlayer>();
        foreach (EntityCharacterPlayer player in entities)
        {
            if (player.isUpdateAble)
            {
                playablePlayers.Add(player);
            }
        }

        return playablePlayers;
    }

    public void SetPlayerPlayable(int playerId, bool set)
    {
        entities[playerId].SetIsUpdateAble(set);
    }

    private void _AssignPlayersToGrid()
    {
        foreach (EntityCharacterPlayer player in entities)
        {
            player.AssignToLevelGrid();
        }
    }

    private void _SetPlayersIsActive()
    {
        for (int i = 0; i < playerCountOnLevelStart; i++)
            entities[i].SetIsUpdateAble(true);

        for (int i = playerCountOnLevelStart; i < entities.Count; i++)
            entities[i].SetIsUpdateAble(false);
    }
}
