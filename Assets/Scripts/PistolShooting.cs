using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Transform bulletPrefab;
    public float bulletSpeed = 10;

    public AudioSource pistolShotSound; // Add this field.
    public AudioSource guardHitSound; // Add this field.

    private int remainingBullets = 10;
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && remainingBullets > 0)
        {
            Shoot();
            PlayShootSound(); // Call the method to play the shooting sound.
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

            // Decrease the remaining bullets count.
            remainingBullets--;

            if (remainingBullets <= 0)
            {
                // Disable shooting when no bullets are left.
                enabled = false;
            }

            // Check if the bullet hits a guard.
            CheckHitGuard(bullet);
        }
    }

    void CheckHitGuard(Transform bullet)
    {
        RaycastHit hit;
        if (Physics.Raycast(bullet.position, bullet.forward, out hit))
        {
            if (hit.collider.CompareTag("Guard"))
            {
                PlayGuardHitSound(); // Call the method to play the guard hit sound.
            }
        }
    }

    void PlayShootSound()
    {
        // Check if the audio source is assigned and play the shooting sound.
        if (pistolShotSound != null)
        {
            pistolShotSound.Play();
        }
    }

    void PlayGuardHitSound()
    {
        // Check if the audio source is assigned and play the guard hit sound.
        if (guardHitSound != null)
        {
            guardHitSound.Play();
        }
    }

    public void ReloadAmmo()
    {
        remainingBullets = 6; // Refill pistol ammo to 6 bullets.
    }
}