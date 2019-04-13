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
    private SpriteRenderer bgRenderer;
    [SerializeField]
    private Sprite[] backgrounds;


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
    private AudioSource p1Source;
    [SerializeField]
    private AudioSource p2Source;

    private static AudioSource source1;
    private static AudioSource source2;


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
        source1 = p1Source;
        source2 = p2Source;

        Fire = fire;
        Ice = ice;
        Lightning = lightning;
        pickup = pickupPrefab;
        locations = locationsToSpawn;

        FireShard = fireShard;
        IceShard = iceShard;
        LightningShard = lightningShard;

        playerHealths = new float[]{ 1, 1 };

        bgRenderer.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }

    int lastCountP1 = 0;
    int lastCountP2 = 0;
    private void Update()
    {
        if (playerCollectedElements[0].Count != lastCountP1)
        {
            if (playerCollectedElements[0].Count > lastCountP1)
            {
                if (playerCollectedElements[0].Count < 3)
                {
                    p1Source.clip = Startup.GetRandomPickupNoise();
                    p1Source.Play();
                }
                else
                {
                    p1Source.clip = Startup.WandClip;
                    p1Source.Play();
                }
            }
            lastCountP1 = playerCollectedElements[0].Count;
        }
        if (playerCollectedElements[1].Count != lastCountP2)
        {
            if (playerCollectedElements[1].Count > lastCountP2)
            {
                if (playerCollectedElements[1].Count < 3)
                {
                    p2Source.clip = Startup.GetRandomPickupNoise();
                    p2Source.Play();
                }
                else
                {
                    p2Source.clip = Startup.WandClip;
                    p2Source.Play();
                }
            }
            lastCountP2 = playerCollectedElements[1].Count;
        }

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
        if (playerHealths[player - 1] < 0)
        {
            if (player == 1)
            {
                Startup.ChangeAudioTrack(Startup.Track.Victory);
                UnityEngine.SceneManagement.SceneManager.LoadScene("End Screen", UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
            else if (player == 2)
            {
                Startup.ChangeAudioTrack(Startup.Track.Victory);
                UnityEngine.SceneManagement.SceneManager.LoadScene("End Screen 2", UnityEngine.SceneManagement.LoadSceneMode.Single);
            }
        }

        HUDSystem.UpdateHealth(player, playerHealths[player - 1]);
    }

    public static void SpawnPiece(Element toSpawn)
    {
        Transform randomSpot = locations[Random.Range(0, locations.Length)];
        StaffPickup newPickup = Instantiate(pickup, randomSpot.position, Quaternion.identity).GetComponent<StaffPickup>();
        newPickup.elementType = toSpawn;
    }
}