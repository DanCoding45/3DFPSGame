using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives.
    private int currentLives; // Current number of lives.

    [SerializeField] private Text livesText; // Reference to the UI Text element displaying lives.

    private void Start()
    {
        currentLives = maxLives; // Initialize the current lives to the maximum.
        UpdateLivesUI(); // Update the UI with initial lives.
    }

    void UpdateLivesUI()
    {
        string livesDisplay = "Lives: " + currentLives;

        // Add the livesDisplay to display in the UI.
        livesText.text = livesDisplay;

        // Check if the player has lost all lives and display "Game Over" if so.
        if (currentLives <= 0)
        {
            livesText.text = "Game Over"; // Replace the previous text with "Game Over."
            Debug.Log("Game Over. All lives lost.");
            // Add any additional game over logic here.
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentLives > 0)
        {
            currentLives -= damage;
            Debug.Log("Player lost " + damage + " life. Lives remaining: " + currentLives);

            UpdateLivesUI(); // Call this to update the UI with the new number of lives.

            if (currentLives <= 0)
            {
                Debug.Log("Game Over. All lives lost.");
                // Add any game over logic here, such as restarting the game.
            }
        }
    }
}
