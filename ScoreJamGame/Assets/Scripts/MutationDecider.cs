using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MutationDecider : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI text;

    public List<string> selections;
    public List<int> levels;

    public Bullet bullet;
    public PlayerMovement playerMovement;

    private System.Random random = new System.Random();

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        RandText();
        playerMovement.maxHealth = 100;
        playerMovement.currHealth = 100;
    }

    void RandText()
    {
        if (selections.Count > 0)
        {
            int randIndex = random.Next(selections.Count);
            text.text = selections[randIndex];
        }
        else
        {
            Debug.LogWarning("Selections list is empty.");
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        string selectedMutation = text.text;
        switch (selectedMutation)
        {
            case "Damage":
                DamageBuff();
                break;
            case "Health":
                HealthBuff();
                break;
            case "Mitosis":
                // Add code for Mitosis mutation
                break;
            default:
                break;
        }

        // Check if all mutations have been decided
        if (AreMutationsDecided())
        {
            // Activate mutation panel
            MutationPanel mutationPanel = FindObjectOfType<MutationPanel>();
            if (mutationPanel != null)
            {
                mutationPanel.gameObject.SetActive(true);
            }
        }
    }

    public void DamageBuff()
    {
        
            
            bullet.damage += 2;
            Debug.Log("Damage buff applied: " + bullet.damage);
        }
    

    public void HealthBuff()
    {
        
        
            
            playerMovement.maxHealth += 20;
            playerMovement.currHealth += 20 ;
            Debug.Log("Health buff applied: Max Health = " + playerMovement.maxHealth + ", Current Health = " + playerMovement.currHealth);
        
    }
    public void Mitosis()
    {
        int index = selections.IndexOf("Mitosis");
        if (index != -1)
        {
            levels[index]++;
            Debug.Log("Mitosis buff applied: " + levels[index]);
        }
    }

    // Check if all mutations have been decided
    bool AreMutationsDecided()
    {
        foreach (int level in levels)
        {
            if (level == 0)
            {
                return false;
            }
        }
        return true;
    }
}
