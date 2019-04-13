using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button instructButton;
    [SerializeField]
    private Button creditsButton;

    // Start is called before the first frame update
    void Start()
    {
        Startup.ChangeAudioTrack(Startup.Track.Main);

        //startButton.onClick.AddListener(startClick);
        //instructButton.onClick.AddListener(instructClick);
        //creditsButton.onClick.AddListener(creditsClick);
    }


    public void startClick()
    {
        SceneManager.LoadScene("SamScene", LoadSceneMode.Single);
    }
    public void instructClick()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }
    public void creditsClick()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
