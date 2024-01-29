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
    
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject mutationPanel;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        RandText();
        
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
            Mitosis();
            break;
        default:
            break;
    }

    // Check if all mutations have been decided
    if (AreMutationsDecided())
    {
        // Activate mutation panel
        MutationPanel mutationScript = FindObjectOfType<MutationPanel>();
        if (mutationPanel != null)
        {
            mutationPanel.SetActive(true);
        }

        // Unfreeze time
        Time.timeScale = 1;

        // Activate player movement
        mutationScript.TogglePlayerMovement(true);

        // Deactivate mutation panel
        mutationPanel.SetActive(false);

        // Reset leveling script
        LevelingScript levelingScript = FindObjectOfType<LevelingScript>();
        if (levelingScript != null)
        {
            levelingScript.currLevel = 0;
            levelingScript.maxLevel += 1;
        }
    }
}


    public void DamageBuff()
    {
        
            
            bullet.damage += 125;
            Debug.Log("Damage buff applied: " + bullet.damage);
        }
    

    public void HealthBuff()
    {
        
        
            
            
            playerMovement.currHealth += 20;
            Debug.Log("Health buff applied: Max Health = " + playerMovement.maxHealth + ", Current Health = " + playerMovement.currHealth);
        
    }
    public void Mitosis()
    {
        
        GameObject newPlayer1 = Instantiate(playerPrefab, player.transform.position + Vector3.right * 2, Quaternion.identity);
        GameObject newPlayer2 = Instantiate(playerPrefab, player.transform.position + Vector3.left * 2, Quaternion.identity);
    
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
