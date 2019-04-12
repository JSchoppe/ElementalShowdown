using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeter : MonoBehaviour
{
    [SerializeField]
    private RawImage meterFill;
    [SerializeField]
    private RawImage background;
    [SerializeField]
    private Texture[] wandFills;


    public void UpdateWandCharges(int newCharges)
    {
        background.texture = wandFills[newCharges];
    }

    public void UpdateHealth(float newHealth)
    {
        meterFill.rectTransform.localScale = new Vector3(newHealth, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //Debug:
    int currentWand = 100;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentWand--;
            if (currentWand < 0)
            {
                currentWand = 0;
            }
            UpdateHealth(currentWand / 100f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentWand++;
            if (currentWand > 100)
            {
                currentWand = 100;
            }
            UpdateHealth(currentWand / 100f);
        }
    }
}
