using UnityEngine;

public class GuardGunController : MonoBehaviour
{
    public Transform guard; // Reference to the guard (capsule) GameObject.
    public float distanceToGuard = 2.0f; // Adjust this distance as needed.

    private void Update()
    {
        if (guard != null)
        {
            // Calculate the position to the right of the guard.
            Vector3 newPosition = guard.position + guard.right * distanceToGuard;

            // Set the "GuardGun" position to the calculated position.
            transform.position = newPosition;

            // You can adjust the rotation as needed.
            // For example, you can make the "GuardGun" always face the same direction as the guard.
            // transform.rotation = guard.rotation;
        }
    }
}
