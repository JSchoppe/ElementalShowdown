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
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform gunTarget;
    [SerializeField]
    private Transform gunLeft;
    [SerializeField]
    private Transform gunRight;

    [SerializeField]
    private AudioSource playerSource;

    bool onpress = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("P1-Horizontal"), Input.GetAxis("P1-Vertical"));
        Vector2 rotInput = new Vector2(Input.GetAxis("P1-Horizontal2"), Input.GetAxis("P1-Vertical2"));

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

        if (Input.GetAxis("P1-Trigger") < -.2)
        {
            if (!onpress)
            {
                List<Element> collectedElements = GameplayLogic.playerCollectedElements[0];

                if (collectedElements.Count > 2)
                {
                    playerSource.clip = Startup.GetRandomShootNoise();
                    playerSource.Play();


                    Debug.Log(collectedElements[0]);
                    Debug.Log(collectedElements[1]);
                    Debug.Log(collectedElements[2]);


                    if (collectedElements[0] == collectedElements[1] && collectedElements[1] == collectedElements[2] && collectedElements[0] == collectedElements[2])
                    {    // all three elements are the same.
                        Projectile projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                        projectile1.SetProperties(1, 45 * (gunTarget.position - transform.position), collectedElements[1], .30f);
                    }
                    else if (collectedElements[0] == collectedElements[1] || collectedElements[1] == collectedElements[2] || collectedElements[0] == collectedElements[2])
                    {    // two of the elements are the same.
                        if (collectedElements[0] != Element.Fire && collectedElements[1] != Element.Fire && collectedElements[2] != Element.Fire)
                        { // ice and lightning
                            Projectile projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            Projectile projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            projectile1.SetProperties(1, 30 * (gunRight.position - transform.position), Element.Ice, .20f);
                            projectile2.SetProperties(1, 30 * (gunLeft.position - transform.position), Element.Lightning, .20f);
                        }
                        else if (collectedElements[0] != Element.Ice && collectedElements[1] != Element.Ice && collectedElements[2] != Element.Ice)
                        { // fire and lightning
                            Projectile projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            Projectile projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            projectile1.SetProperties(1, 30 * (gunRight.position - transform.position), Element.Fire, .20f);
                            projectile2.SetProperties(1, 30 * (gunLeft.position - transform.position), Element.Lightning, .20f);
                        }
                        else if (collectedElements[0] != Element.Lightning && collectedElements[1] != Element.Lightning && collectedElements[2] != Element.Lightning)
                        { // ice and fire
                            Projectile projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            Projectile projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                            projectile1.SetProperties(1, 30 * (gunRight.position - transform.position), Element.Ice, .20f);
                            projectile2.SetProperties(1, 30 * (gunLeft.position - transform.position), Element.Fire, .20f);
                        }
                    }
                    else // all projectiles are different.
                    {
                        Projectile projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                        Projectile projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                        Projectile projectile3 = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Projectile>();
                        projectile1.SetProperties(1, 15 * (gunTarget.position - transform.position), Element.Fire, .10f);
                        projectile2.SetProperties(1, 15 * (gunLeft.position - transform.position), Element.Ice, .10f);
                        projectile3.SetProperties(1, 15 * (gunRight.position - transform.position), Element.Lightning, .10f);
                    }


                    GameplayLogic.playerCollectedElements[0].Clear();
                }
            }
            onpress = true;
        }
        else
        {
            onpress = false;
        }
    }
}
