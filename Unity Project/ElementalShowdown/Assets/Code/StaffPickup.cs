using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffPickup : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer renderer;

    private Element assignedElement;
    public Element elementType {
        get
        {
            return assignedElement;
        }
        set
        {
            switch (value)
            {
                case Element.Fire:
                    renderer.sprite = GameplayLogic.Fire;
                    break;
                case Element.Ice:
                    renderer.sprite = GameplayLogic.Ice;
                    break;
                case Element.Lightning:
                    renderer.sprite = GameplayLogic.Lightning;
                    break;

            }
        }
    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) //p1
        {
            GameplayLogic.playerCollectedElements[0].Add(elementType);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 9) //p2
        {
            GameplayLogic.playerCollectedElements[1].Add(elementType);
            Destroy(gameObject);
        }
    }
}
