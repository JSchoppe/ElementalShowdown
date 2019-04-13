using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public enum Track
    {
        Main, Game, Victory
    }


    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private AudioClip mainTrack;
    [SerializeField]
    private AudioClip gameTrack;
    [SerializeField]
    private AudioClip endTrack;
    [SerializeField]
    private AudioClip[] shootNoises;
    [SerializeField]
    private AudioClip[] pickupNoises;
    [SerializeField]
    private AudioClip wandNoise;

    public static AudioClip WandClip;
    private static AudioClip[] PickupClips;
    private static AudioClip[] ShootingClips;
    private static AudioSource AudioPlayer;
    private static AudioClip MainTrack;
    private static AudioClip GameTrack;
    private static AudioClip EndTrack;

    private static Track currentTrack = Track.Game;

    // Start is called before the first frame update
    void Start()
    {
        WandClip = wandNoise;
        PickupClips = pickupNoises;
        AudioPlayer = audioPlayer;
        MainTrack = mainTrack;
        GameTrack = gameTrack;
        EndTrack = endTrack;
        ShootingClips = shootNoises;

        DontDestroyOnLoad(gameObject);
        // Load the main menu
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static AudioClip GetRandomShootNoise()
    {
        return ShootingClips[Random.Range(0, ShootingClips.Length)];
    }

    public static AudioClip GetRandomPickupNoise()
    {
        return PickupClips[Random.Range(0, PickupClips.Length)];
    }

    public static void ChangeAudioTrack(Track track)
    {
        if (track != currentTrack)
        {
            currentTrack = track;
            switch (track)
            {
                case Track.Game:
                    AudioPlayer.loop = true;
                    AudioPlayer.clip = GameTrack;
                    break;
                case Track.Main:
                    AudioPlayer.loop = true;
                    AudioPlayer.clip = MainTrack;
                    break;
                case Track.Victory:
                    AudioPlayer.loop = false;
                    AudioPlayer.clip = EndTrack;
                    break;
            }
            AudioPlayer.Play();
        }
    }
}
