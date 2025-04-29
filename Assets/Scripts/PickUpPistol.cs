using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class PickUpPistol : MonoBehaviour
{
    public GameObject PistolOnPlayer;
    public Text weaponsText; // Reference to the UI Text component

    void Start()
    {
        PistolOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                PistolOnPlayer.SetActive(true);

                // Update the UI Text to display "Weapon #1: Pistol"
                if (weaponsText != null)
                {
                    weaponsText.text = "Weapon #1: Pistol";
                }
            }
        }
    }
}
