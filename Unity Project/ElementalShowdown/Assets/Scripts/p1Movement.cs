using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    Rigidbody2D playerRB;
    [SerializeField]
    Transform childSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 rotInput = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        Debug.Log(rotInput);

        // player 1 movement
        playerRB.velocity = playerInput * movementSpeed;

        if (rotInput.y == 0)
        {
            if(rotInput.x == 0)
            {
                // do nothing
            }
            else if (rotInput.x > 0)
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            else
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (rotInput.x == 0)
        {
            if (rotInput.y > 0)
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (rotInput.y > 0)
        {
            if (rotInput.x > 0) // Q1
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * Mathf.Atan(rotInput.y / rotInput.x) - 90);
            }
            else // Q2
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * Mathf.Atan(-rotInput.x / rotInput.y));
            }
        }
        else
        {
            if (rotInput.x < 0) // Q3
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * Mathf.Atan(-rotInput.y / -rotInput.x) + 90);
            }
            else // Q4
            {
                childSprite.transform.eulerAngles = new Vector3(0, 0, 270 - (180 / Mathf.PI) * Mathf.Atan(rotInput.y / -rotInput.x));
            }
        }
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * movementSpeed;
    }
}
