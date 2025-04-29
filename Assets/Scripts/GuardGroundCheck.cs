using UnityEngine;

public class GuardGroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // Set this to the layer representing the ground/platform in the Inspector.

    private GuardBehavior guard;

    private void Start()
    {
        // Find the parent guard GameObject to access its GuardBehavior script
        guard = transform.parent.GetComponent<GuardBehavior>();
    }

    private void Update()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        // Create a raycast to check if the guard is grounded
        float raycastDistance = 0.1f; // Adjust this value based on your guard's size
        Vector3 raycastOrigin = transform.position;
        Ray ray = new Ray(raycastOrigin, Vector3.down);

        if (Physics.Raycast(ray, raycastDistance, groundLayer))
        {
            // Guard is grounded, do nothing
        }
    }
}
