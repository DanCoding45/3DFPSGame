// PlayerInventory.cs
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform pistolMountPoint;
    public Transform rpgMountPoint;
    public GameObject bulletPrefab; // Prefab for bullet ammo object
    public GameObject rocketPrefab; // Prefab for rocket ammo object

    private Transform currentWeaponMount;
    private bool hasPistol = true; // Flag to track if the player has the pistol

    private int pistolAmmo = 6; // Number of pistol bullets
    private int rpgAmmo = 1;    // Number of RPG rockets

    private void Start()
    {
        EquipWeapon(pistolMountPoint);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasPistol)
                EquipWeapon(rpgMountPoint);
            else
                EquipWeapon(pistolMountPoint);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reload button pressed.");
            ReloadAmmo();
        }
    }

    public void EquipWeapon(Transform weaponMount)
    {
        // Deactivate the current weapon mount
        if (currentWeaponMount != null)
        {
            currentWeaponMount.gameObject.SetActive(false);
        }

        // Activate the new weapon mount
        weaponMount.gameObject.SetActive(true);
        currentWeaponMount = weaponMount;

        // Update the weapon flag based on the currently equipped weapon
        hasPistol = (currentWeaponMount == pistolMountPoint);
    }

    private void ReloadAmmo()
    {
        if (hasPistol)
        {
            if (pistolAmmo < 6) // If pistol ammo is less than 6, you can pick up more.
            {
                pistolAmmo = Mathf.Min(6, pistolAmmo + 1); // Refill pistol ammo to a maximum of 6 bullets.
                SpawnAmmoObject(bulletPrefab); // Spawn a new bullet ammo object.
                // Optionally, you can add a code to remove the ammo pickup object.
            }
        }
        else
        {
            if (rpgAmmo < 1) // If RPG ammo is less than 1, you can pick up more.
            {
                rpgAmmo = Mathf.Min(1, rpgAmmo + 1); // Refill RPG ammo to a maximum of 1 rocket.
                SpawnAmmoObject(rocketPrefab); // Spawn a new rocket ammo object.
                // Optionally, you can add a code to remove the ammo pickup object.
            }
        }
    }

    private void SpawnAmmoObject(GameObject ammoPrefab)
    {
        if (ammoPrefab != null && currentWeaponMount != null)
        {
            GameObject ammoObject = Instantiate(ammoPrefab, currentWeaponMount.Find("AmmoSpawnPoint"));
            ammoObject.transform.localPosition = Vector3.zero; // Ensure the new ammo object spawns at the spawn point.
        }
    }

    public void PickUpAmmo(GameObject ammoPrefab, int amount)
    {
        if (hasPistol && ammoPrefab == bulletPrefab)
        {
            pistolAmmo = Mathf.Min(6, pistolAmmo + amount); // Refill pistol ammo to a maximum of 6 bullets.
        }
        else if (!hasPistol && ammoPrefab == rocketPrefab)
        {
            rpgAmmo = Mathf.Min(1, rpgAmmo + amount); // Refill RPG ammo to a maximum of 1 rocket.
        }
    }
}
