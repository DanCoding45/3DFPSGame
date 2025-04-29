using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            GuardBehavior guard = collision.gameObject.GetComponent<GuardBehavior>();

            if (guard != null)
            {
                guard.GetHitByPistol(); // Tell the guard it's been hit by a pistol bullet
                Debug.Log("Bullet hit the guard!");
            }

            Destroy(gameObject); // Destroy the bullet
        }
    }
}
