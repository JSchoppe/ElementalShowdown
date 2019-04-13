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

    private static AudioSource AudioPlayer;
    private static AudioClip MainTrack;
    private static AudioClip GameTrack;
    private static AudioClip EndTrack;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = audioPlayer;
        MainTrack = mainTrack;
        GameTrack = gameTrack;
        EndTrack = endTrack;

        DontDestroyOnLoad(gameObject);
        // Load the main menu
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static void ChangeAudioTrack(Track track)
    {
        switch (track)
        {
            case Track.Game:
                AudioPlayer.clip = GameTrack;
                break;
            case Track.Main:
                AudioPlayer.clip = MainTrack;
                break;
            case Track.Victory:
                AudioPlayer.clip = EndTrack;
                break;
        }
    }
}
