using UnityEngine;

public class RPGShooting : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public Transform projectilePrefab;
    public float projectileSpeed = 10;

    public AudioSource rpgFireSound; // RPG firing sound field.
    public AudioSource guardRPGHitSound; // RPG guard hit sound field.

    private PlayerInventory playerInventory;

    private bool canShoot = true;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ShootRPG();
            PlayRPGFireSound(); // Call the method to play the RPG firing sound.
        }
    }

    void ShootRPG()
    {
        var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Use Rigidbody for 3D projects.

        // Set the speed and direction of the projectile.
        rb.velocity = projectileSpawnPoint.forward * projectileSpeed;

        // Disable shooting to prevent rapid firing.
        canShoot = false;

        // Check if the RPG projectile hits a guard.
        CheckHitGuard(projectile);
    }

    void CheckHitGuard(Transform projectile)
    {
        RaycastHit hit;
        if (Physics.Raycast(projectile.position, projectile.forward, out hit))
        {
            if (hit.collider.CompareTag("Guard"))
            {
                PlayGuardRPGHitSound(hit.collider.gameObject); // Call the method to play the RPG guard hit sound.
            }
        }
    }

    void PlayRPGFireSound()
    {
        // Check if the audio source is assigned and play the RPG firing sound.
        if (rpgFireSound != null)
        {
            rpgFireSound.Play();
        }
    }

    void PlayGuardRPGHitSound(GameObject guardObject)
    {
        GuardRPGHit guardAudio = guardObject.GetComponent<GuardRPGHit>();
        if (guardAudio != null)
        {
            guardAudio.PlayGuardRPGHitSound();
        }
    }

    public void ReloadAmmo()
    {
        canShoot = true; // Re-enable shooting RPG after reloading.
    }
}