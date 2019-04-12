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

    private float Range = 5;
    private float Damage = .1f;
    private Element Elemental = Element.Fire;

    [SerializeField]
    private SpriteRenderer ProjectileImage;


    public void SetProperties(float range, Vector2 velocity, Element element, float damage)
    {
        Range = range;
        Elemental = element;
        Damage = damage;

        gameObject.GetComponent<Rigidbody>().velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.gameObject.GetComponent<>)
        //{

        //}
        //else
        //{
            Destroy(this);
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
        if (Vector2.Distance(transform.position, startingLocation) > Range)
        {
            Destroy(this);
        }
    }
}