using UnityEngine;

public class RPGProjectileBehavior : MonoBehaviour
{
    private bool hasHitGuard = false; // Flag to track if the RPG rocket has hit the guard

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHitGuard && collision.gameObject.CompareTag("Guard"))
        {
            GuardBehavior guard = collision.gameObject.GetComponent<GuardBehavior>();

            if (guard != null)
            {
                guard.GetHitByRPG(); // Tell the guard it's been hit by an RPG rocket
                hasHitGuard = true; // Mark that the RPG rocket has hit the guard
            }

            Destroy(gameObject); // Destroy the RPG rocket
        }
    }
}