using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText; // Use TextMeshProUGUI instead of Text
    private int enemiesKilled = 0;

    // Function to increment the enemy count

    void Start()
    {
        enemyCountText = GetComponent<TextMeshProUGUI>();
    }
    public void IncrementEnemyCount()
    {
        enemiesKilled++;
        UpdateEnemyCountText();
    }

    // Function to update the text with the current enemy count
    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemies Killed: " + enemiesKilled.ToString();
    }
}
