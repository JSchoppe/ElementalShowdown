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
                    renderer.sprite = GameplayLogic.FireShard;
                    break;
                case Element.Ice:
                    renderer.sprite = GameplayLogic.IceShard;
                    break;
                case Element.Lightning:
                    renderer.sprite = GameplayLogic.LightningShard;
                    break;

            }
            assignedElement = value;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8) //p1
        {
            if (GameplayLogic.playerCollectedElements[0].Count < 4)
            {
                GameplayLogic.playerCollectedElements[0].Add(elementType);
                GameplayLogic.SpawnPiece(elementType);
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.layer == 9) //p2
        {
            if (GameplayLogic.playerCollectedElements[1].Count < 4)
            {
                GameplayLogic.playerCollectedElements[1].Add(elementType);
                GameplayLogic.SpawnPiece(elementType);
                Destroy(gameObject);
            }
        }
    }
}