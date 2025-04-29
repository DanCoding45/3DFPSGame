using UnityEngine;

public class GuardBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 10.0f; // Adjust the speed as needed.

    // Reference to the PlayerHealth script.
    public PlayerHealth playerHealth;

    public PlayerHitAudio playerHitAudio; // Assign the PlayerHitAudio script in the Inspector.

    private void Update()
    {
        // Move the bullet forward along its local Z-axis.
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    // Add any additional behavior or collision detection logic for the bullet here.

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Player."
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce the player's health when the bullet collides with them.
            playerHealth.TakeDamage(1);

            // Play the player hit sound using the PlayerHitAudio script.
            playerHitAudio.PlayPlayerHitSound();

            // Destroy the bullet on collision with the player.
            Destroy(gameObject);
        }
    }
}
