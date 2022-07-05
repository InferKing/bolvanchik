using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchManager : MonoBehaviour
{
    private Settings settings;
    private void Awake()
    {
        settings = new Settings();
        SoundManager.isSound = settings.LoadJson().isSound;
    }
    public void LoadingScene()
    {
        settings.SaveJson(new DataSettings());
        SceneManager.LoadSceneAsync("LoadingScene");
    }
}
