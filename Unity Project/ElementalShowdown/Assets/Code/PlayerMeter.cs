using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeter : MonoBehaviour
{
    [SerializeField]
    private Texture fullWand;
    [SerializeField]
    private Texture drainedWand;

    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private RawImage[] wandCharges;


    public void UpdateWandCharges(int newCharges)
    {
        for (int i = 0; i < wandCharges.Length; i++)
        {
            if (i < newCharges) // This charge is filled.
            {
                wandCharges[i].texture = fullWand;
            }
            else
            {
                wandCharges[i].texture = drainedWand;
            }
        }
    }

    public void UpdateHealth(float newHealth)
    {
        healthSlider.value = newHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Debug:
    //int currentWand;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        currentWand--;
    //        if(currentWand < 0)
    //        {
    //            currentWand = 0;
    //        }
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        currentWand++;
    //        if (currentWand > 5)
    //        {
    //            currentWand = 5;
    //        }
    //    }
    //    UpdateWandCharges(currentWand);
    //}
}
