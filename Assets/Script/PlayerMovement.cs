using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [Header("Information Player")]
    [Space]
    public Rigidbody2D rb;
    public int speed;
    public float jump;
    float direction;

    public GameObject sword;
    public Camera cam;

    Enemy enemy;

    bool isGrounded;

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
        rb = GetComponent<Rigidbody2D>();
        sword.SetActive(false);
        cam.transform.localPosition = new Vector3(1.35f, 0.16f, -15f);
        sword.transform.localPosition = new Vector2(0.65f, -1f);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * Time.deltaTime * speed, 0, 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        
        direction =context.ReadValue<float>() * speed * Time.deltaTime;
        if (direction != 0)
        {
            sword.transform.localPosition = new Vector2(context.ReadValue<float>() * 0.65f, -0.1f);
            GetComponent<SpriteRenderer>().flipX = (context.ReadValue<float>() > 0);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sword.SetActive(true);
        }
        else if (context.canceled)
        {
            sword.SetActive(false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        else if(collision.gameObject.tag == "Trap")
        {
            PlayerHealth.instance.LostPV(10);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            PlayerHealth.instance.LostPV(enemy.damage);
        }
    }
}
