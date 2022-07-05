using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private GameObject[] gameObjects;
    private void Awake()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Music");
        if (gameObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (!MainManager.settings.isSound)
        {
            gameObjects[0].GetComponent<AudioSource>().Stop();
        }
    }
}
