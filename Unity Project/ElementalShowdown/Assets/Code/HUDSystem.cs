using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerMeter[] PlayerUIs;


    [SerializeField]
    private static PlayerMeter[] playerUIs;


    public void Awake()
    {
        playerUIs = PlayerUIs;
    }


    public static void ResetGame()
    {
        foreach(PlayerMeter meter in playerUIs)
        {
            meter.UpdateHealth(1);
            meter.UpdateWandCharges(0);
        }
    }

    public static void UpdateHealth(int player, float healthAsRange)
    {
        playerUIs[player - 1].UpdateHealth(healthAsRange);
    }

    public static void UpdateWandFill(int player, int newFill)
    {
        playerUIs[player - 1].UpdateWandCharges(newFill);
    }
}