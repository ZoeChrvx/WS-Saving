using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public static Ui instance;
    public GameObject[] hearts;

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
        playerHealth = PlayerHealth.instance;
    }


    public void ChangeLifeStates()
    {
        if(playerHealth.health >= -1) hearts[playerHealth.health].SetActive(false);
    }
}
