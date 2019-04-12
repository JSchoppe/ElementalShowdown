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
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform gunTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("P2-Horizontal"), Input.GetAxis("P2-Vertical"));
        Vector2 rotInput = new Vector2(Input.GetAxis("P2-Horizontal2"), Input.GetAxis("P2-Vertical2"));

        playerRB.velocity = playerInput * movementSpeed;

        if (rotInput.y == 0)
        {
            if (rotInput.x == 0)
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

        if (Input.GetAxis("P2-Trigger") < -.2)
        {
            if (!onpress)
            {
                Projectile newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();

                newProjectile.SetProperties(2, 15 * (gunTarget.position - transform.position), Element.Fire, 10);
            }
            onpress = true;
        }
        else
        {
            onpress = false;
        }
    }
    bool onpress = false;

}
