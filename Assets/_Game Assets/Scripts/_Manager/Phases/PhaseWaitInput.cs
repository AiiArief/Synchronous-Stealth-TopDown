using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseWaitInput : MonoBehaviour
{
    public void ActivateWaitInput()
    {
        gameObject.SetActive(true);

        GameManager.Instance.playerManager.SetupEntitiesOnWaitInputStart();
        GameManager.Instance.npcManager.SetupEntitiesOnWaitInputStart();
        GameManager.Instance.eventManager.SetupEntitiesOnWaitInputStart();
    }

    public void UpdateWaitInput()
    {
        bool playerManagerHasDoneInput = GameManager.Instance.playerManager.CheckEntitiesHasDoneWaitInput();
        bool enemyManagerHasDoneInput = GameManager.Instance.npcManager.CheckEntitiesHasDoneWaitInput();
        bool eventManagerHasDoneInput = GameManager.Instance.eventManager.CheckEntitiesHasDoneWaitInput();

        if(playerManagerHasDoneInput && enemyManagerHasDoneInput && eventManagerHasDoneInput)
        {
            GameManager.Instance.phaseManager.SetPhase(PhaseEnum.ProcessInput);
        }
    }
}
