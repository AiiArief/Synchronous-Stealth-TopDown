using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseEnum
{
    None,
    WaitInput,
    ProcessInput,
    AfterInput
}

public class PhaseManager : MonoBehaviour
{
    [SerializeField] PhaseWaitInput m_waitInput;
    public PhaseWaitInput waitInput { get { return m_waitInput; } }

    [SerializeField] PhaseProcessInput m_processInput;
    public PhaseProcessInput processInput { get { return m_processInput; } }

    [SerializeField] PhaseAfterInput m_afterInput;
    public PhaseAfterInput afterInput { get { return m_afterInput; } }

    public PhaseEnum currentPhase { get; private set; } = PhaseEnum.None;

    public void SetPhase(PhaseEnum phase)
    {
        currentPhase = phase;

        _DisableAllPhase();
        _ActivateCurrentPhase();
    }

    public void UpdateCurrentPhase()
    {
        switch(currentPhase)
        {
            case PhaseEnum.WaitInput:
                m_waitInput.UpdateWaitInput();
                break;
            case PhaseEnum.ProcessInput:
                m_processInput.UpdateProcessInput();
                break;
            case PhaseEnum.AfterInput:
                m_afterInput.UpdateAfterInput();
                break;
        }
    }

    private void _DisableAllPhase()
    {
        m_waitInput.gameObject.SetActive(false);
        m_processInput.gameObject.SetActive(false);
        m_afterInput.gameObject.SetActive(false);
    }

    private void _ActivateCurrentPhase()
    {
        switch(currentPhase)
        {
            case PhaseEnum.WaitInput: m_waitInput.ActivateWaitInput(); break;
            case PhaseEnum.ProcessInput: m_processInput.ActivateProcessInput(); break;
            case PhaseEnum.AfterInput: m_afterInput.ActivateAfterInput(); break;
        }
    }
}
