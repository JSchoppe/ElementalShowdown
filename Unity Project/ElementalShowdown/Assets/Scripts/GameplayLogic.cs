using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLogic : MonoBehaviour
{

    [SerializeField]
    private Sprite fire;
    [SerializeField]
    private Sprite ice;
    [SerializeField]
    private Sprite lightning;


    [SerializeField]
    private Sprite fireShard;
    [SerializeField]
    private Sprite iceShard;
    [SerializeField]
    private Sprite lightningShard;

    public static Sprite FireShard;
    public static Sprite IceShard;
    public static Sprite LightningShard;

    public static Sprite Fire;
    public static Sprite Ice;
    public static Sprite Lightning;


    [SerializeField]
    private Transform[] locationsToSpawn;

    private static Transform[] locations;

    [SerializeField]
    private GameObject pickupPrefab;

    private static GameObject pickup;

    static float[] playerHealths = { 1, 1 };
    public static List<Element>[] playerCollectedElements = { new List<Element>(), new List<Element>() };

    private void Awake()
    {
        Fire = fire;
        Ice = ice;
        Lightning = lightning;
        pickup = pickupPrefab;
        locations = locationsToSpawn;

        FireShard = fireShard;
        IceShard = iceShard;
        LightningShard = lightningShard;
    }

    // Start is called before the first frame update
    void Start()
    {
        HUDSystem.ResetGame();
        for (int i = 0; i < 3; i++)
        {
            SpawnPiece(Element.Fire);
            SpawnPiece(Element.Ice);
            SpawnPiece(Element.Lightning);
        }

        Startup.ChangeAudioTrack(Startup.Track.Game);
    }

    public static void DamagePlayer(int player, float amount)
    {
        playerHealths[player - 1] -= amount;
        HUDSystem.UpdateHealth(player, playerHealths[player - 1]);
    }

    public static void SpawnPiece(Element toSpawn)
    {
        Transform randomSpot = locations[Random.Range(0, locations.Length)];
        StaffPickup newPickup = Instantiate(pickup, randomSpot.position, Quaternion.identity).GetComponent<StaffPickup>();
        newPickup.elementType = toSpawn;
    }
}