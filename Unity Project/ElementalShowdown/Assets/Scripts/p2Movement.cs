using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Movement : MonoBehaviour
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
        // player 1 movement
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")) * movementSpeed;


    }
}
