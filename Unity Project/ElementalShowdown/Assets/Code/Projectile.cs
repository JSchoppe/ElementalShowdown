using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Fire, Ice, Wind
}
public class Projectile : MonoBehaviour
{

    private Vector2 startingLocation;

    private float Damage = .1f;
    private Element Elemental = Element.Fire;

    [SerializeField]
    private SpriteRenderer ProjectileImage;


    public void SetProperties(int owningPlayer, Vector2 velocity, Element element, float damage)
    {
        switch (owningPlayer)
        {
            case 1:
                gameObject.layer = 10;
                break;
            case 2:
                gameObject.layer = 11;
                break;
        }

        Elemental = element;
        Damage = damage;

        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.gameObject.GetComponent<>)
        //{

        //}
        //else
        //{
            Destroy(gameObject);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        startingLocation = transform.position;
    }

    private void FixedUpdate()
    {
        // Projectile is outside of its designated range.
        //if (Vector2.Distance(transform.position, startingLocation) > Range)
        //{
        //    Debug.Log("Destroyed");
        //    Destroy(gameObject);
        //}
    }
}