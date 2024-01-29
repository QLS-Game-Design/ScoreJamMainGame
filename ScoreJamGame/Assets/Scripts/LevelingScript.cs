
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class LevelingScript : MonoBehaviour
{
    public float currLevel = 0;
    public float maxLevel = 10.0f;
    private float currExp = 0.0f;

    [SerializeField] private Slider slider;
    [SerializeField] private MutationPanel mutationPanel; // Reference to the MutationPanel script

    private void Start()
    {
        if (slider == null)
        {
            slider = GetComponentInChildren<Slider>();
            if (slider == null)
            {
                Debug.LogError("Slider not found in children.");
                return;
            }
        }

        UpdateLevel();
    }

    public void UpdateLevel()
    {
        if (slider != null)
        {
            slider.value = currLevel / maxLevel;
        }
    }

    void Update()
    {
        if (currLevel >= maxLevel)
        {
            ActivateMutationPanelIfNeeded();

            currLevel = 0;
            maxLevel += 1;
        }
    }

    void ActivateMutationPanelIfNeeded()
    {
        
            mutationPanel.ActivateMutationPanel();
        
    }
}
