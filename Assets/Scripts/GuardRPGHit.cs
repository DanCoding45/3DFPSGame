using UnityEngine;

public class GuardRPGHit : MonoBehaviour
{
    public AudioSource guardRPGHitSound; // Assign the AudioSource for the RPG guard hit sound in the Inspector.

    public void PlayGuardRPGHitSound()
    {
        if (guardRPGHitSound != null)
        {
            guardRPGHitSound.Play(); // Play the RPG guard hit sound.
        }
    }
}
