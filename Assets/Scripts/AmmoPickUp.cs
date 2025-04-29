using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public string ammoType; // Type of ammo (e.g., "Bullet" or "Rocket").
    public int ammoAmount; // Amount of ammo to provide.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                if (ammoType == "Bullet")
                {
                    playerInventory.PickUpAmmo(playerInventory.bulletPrefab, ammoAmount);
                    Debug.Log("Collected " + ammoAmount + " bullets!");
                }
                else if (ammoType == "Rocket")
                {
                    playerInventory.PickUpAmmo(playerInventory.rocketPrefab, ammoAmount);
                    Debug.Log("Collected " + ammoAmount + " rockets!");
                }
            }

            // Disable the visual representation of the pickup object.
            gameObject.SetActive(false);
        }
    }
}
