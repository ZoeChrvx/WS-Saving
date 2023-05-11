using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public static Ui instance;

    public GameObject[] hearts;

    public int diamonds;
    public TextMeshProUGUI diamondTXT;

    PlayerHealth playerHealth;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        
    }

    private void Start()
    {
        diamondTXT.text = diamonds + "x ";
        playerHealth = PlayerHealth.instance;
    }


    public void ChangeLifeStates()
    {
        if(playerHealth.health >= -1) hearts[playerHealth.health].SetActive(false);
    }

    public void AddDiamond()
    {
        diamonds = diamonds + 1;
        diamondTXT.text = diamonds + " x ";
    }
}
