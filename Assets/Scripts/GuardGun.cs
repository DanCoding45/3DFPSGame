using UnityEngine;

public class GuardGun : MonoBehaviour
{
    public GameObject guardBulletPrefab;  // The GuardBullet prefab.
    public Transform bulletSpawnPoint;    // The spawn point for bullets.
    public float fireRate = 3.0f;         // Rate of fire in bullets per second.
    public float shootRange = 10.0f;      // Range at which the guard starts shooting.

    private float nextFireTime;
    private Transform player; // Reference to the player's transform.

    private void Start()
    {
        // Set an initial delay before shooting.
        nextFireTime = Time.time + Random.Range(1.0f, 3.0f); // Adjust the delay as needed.
        player = GameObject.FindGameObjectWithTag("Player").transform; // Adjust the tag as needed.
    }

    private void Update()
    {
        // Check if the player is within shooting range.
        if (IsPlayerWithinRange() && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1.0f / fireRate;
        }
    }

    bool IsPlayerWithinRange()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            return distanceToPlayer <= shootRange;
        }
        return false;
    }

    void Shoot()
    {
        if (guardBulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate a bullet at the bullet spawn point.
            GameObject bullet = Instantiate(guardBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}