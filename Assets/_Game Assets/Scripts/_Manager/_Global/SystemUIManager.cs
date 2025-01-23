using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SystemUIManager : MonoBehaviour
{
    [SerializeField] Canvas m_canvas;

    [SerializeField] Text m_screenResolutionText;
    [SerializeField] Text m_screenResolutionListText;

    [SerializeField] Text m_screenModeText;

    [SerializeField] Text m_graphicPresetText;

    [SerializeField] Text m_musicVolumeText;

    [SerializeField] Text m_sfxVolumeText;

    List<Resolution> availableScreenResolution = new List<Resolution>();
    Resolution currentScreenResolution;

    public void ToggleSystemUI()
    {
        m_canvas.enabled = !m_canvas.enabled;

        if (!m_canvas.enabled)
            return;

        _Localize();
        _SetupScreenResolutions();
    }

    private void _Localize()
    {
        m_screenResolutionText.text = LocalizationManager.SYSTEM_SCREENRESOLUTIONS;
        m_screenModeText.text = LocalizationManager.SYSTEM_SCREENMODE;
        m_graphicPresetText.text = LocalizationManager.SYSTEM_GRAPHICPRESET;
        m_musicVolumeText.text = LocalizationManager.SYSTEM_MUSICVOLUME;
        m_sfxVolumeText.text = LocalizationManager.SYSTEM_SFXVOLUME;
    }

    private void _SetupScreenResolutions()
    {
        if (Screen.resolutions.Length <= 0)
            return;

        if (availableScreenResolution == null || availableScreenResolution.Count <= 0)
        {
            availableScreenResolution = Screen.resolutions.ToList();
            currentScreenResolution = Screen.currentResolution;
            // filter list screen resolution dsiini 
        }

        if (availableScreenResolution.Count <= 0)
            return;


    }
}