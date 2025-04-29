using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class PickUpRPG : MonoBehaviour
{
    public GameObject RPGOnPlayer;
    public Text weaponsText; // Reference to the UI Text component

    void Start()
    {
        RPGOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                RPGOnPlayer.SetActive(true);

                // Update the UI Text to display "Weapon #2: RPG"
                if (weaponsText != null)
                {
                    weaponsText.text = "Weapon #2: RPG";
                }
            }
        }
    }
}
