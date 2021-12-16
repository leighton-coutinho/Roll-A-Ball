using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float boosttimer;
    private bool boosting;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Transform respawnPoint;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movememntY;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        boosttimer = 0;
        boosting = false;
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);

        SetCountText();
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }

        if (boosting)
        {
            boosttimer += Time.deltaTime;
            if (boosttimer >= 3)
            {
                speed = 10;
                boosttimer = 0;
                boosting = false;
            }
        } 
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movememntY = movementVector.y;
        movementX = movementVector.x;

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movememntY);
        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Slowdown"))
        {
            boosting = true;
            speed = 0;
        }
        if (other.gameObject.CompareTag("Boost"))
        {
            boosting = true;
            speed = 20;
        }



    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }
}

