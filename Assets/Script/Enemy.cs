using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        health = health - damage;
        Invoke("ReserColor", 0.5f);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
