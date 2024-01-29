using UnityEngine;

public class MutationPanel : MonoBehaviour
{
    public LevelingScript levelingScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Unfreeze time
            Time.timeScale = 1;

            // Activate player movement
            TogglePlayerMovement(true);

            // Deactivate mutation panel
            gameObject.SetActive(false);

            levelingScript.currLevel = 0;
            levelingScript.maxLevel += 1;
        }
    }

    // Toggle player movement based on the specified flag
    private void TogglePlayerMovement(bool isActive)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = isActive;
        }
    }

    // Method to activate the mutation panel
    public void ActivateMutationPanel()
    {
        // Check if the current level is greater than or equal to the max level
        
             // Freeze time
            Time.timeScale = 0;

            // Deactivate player movement
            TogglePlayerMovement(true);

            // Activate mutation panel
            gameObject.SetActive(true);
        
    }
}
