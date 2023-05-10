using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int maxHealth = 10;
    public int health;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }


    public void LostPV(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            //menu mort
            Destroy(gameObject);
        }  
    }
}
