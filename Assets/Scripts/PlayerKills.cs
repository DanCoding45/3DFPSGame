using UnityEngine;
using UnityEngine.UI;

public class PlayerKills : MonoBehaviour
{
    private int kills = 0;
    public Text killsText;

    private void Start()
    {
        killsText.text = "Kills: ";
    }

    public void IncreaseKills()
    {
        kills++;
        killsText.text = "Kills: " + kills;
    }
}
