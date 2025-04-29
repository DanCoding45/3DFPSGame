using UnityEngine;

public class GuardBulletHit : MonoBehaviour
{
    public AudioSource guardHitSound; // Assign the AudioSource for the guard hit sound in the Inspector.

    public void PlayGuardHitSound()
    {
        if (guardHitSound != null)
        {
            guardHitSound.Play(); // Play the guard hit sound.
        }
    }
}
