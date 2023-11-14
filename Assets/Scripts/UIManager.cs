using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Health Player;


    private void Update()
    {
        healthText.text = Player.healthAmount.ToString() + "/100";
    }
}
