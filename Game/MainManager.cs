using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public enum PlayingType
{
    Stop,
    Play,
    Wait,
    OnStart,
    Complete,
    End
}


public class MainManager : MonoBehaviour
{
    [SerializeField] private GameObject _heart;
    [SerializeField] private UIController _controller;
    private Data _data;
    private Settings _settings;
    public static DataSettings settings;
    public static bool isDebug;
    public static PlayingType playingType;
    public static int wave;
    public static float waveTime;

    private void Awake()
    {
        _data = new Data();
        _data.LoadData();
        _settings = new Settings();
        settings = _settings.LoadJson();
    }
    private void Start() // here i made initialization
    {
        isDebug = false;
        Time.timeScale = 1;
        playingType = PlayingType.OnStart;
        wave = 1;
        StartCoroutine(GameStates());
    }

    private IEnumerator GameStates()
    {
        while (true)
        {
            // Debug.Log($"MainManager.playingType = {playingType}");
            if (playingType == PlayingType.OnStart)
            {
                yield return new WaitForEndOfFrame(); // need for Update() method in others scripts
                yield return new WaitForSeconds(1);
                SpawnerManager.start?.Invoke();
                playingType = PlayingType.Play;
            }
            else if (playingType == PlayingType.Complete)
            {
                FieldController.ClearField();
                yield return new WaitForSeconds(1.7f);
                playingType = PlayingType.Play;
                SpawnerManager.start?.Invoke();
            }
            else if (playingType == PlayingType.Play)
            {
                waveTime -= Time.deltaTime;
                if (waveTime < 0.1f)
                {
                    playingType = PlayingType.Complete;
                    wave++;
                }
                yield return new WaitForSeconds(Time.deltaTime);
            }
            else if (playingType == PlayingType.Stop)
            {
                FieldController.ClearField();
                SetEndAnim();
                if ((int)_controller.curTime+1 > _data.loadData.BestScore)
                {
                    _data.loadData.BestScore = (int)_controller.curTime+1;
                    _data.WriteJson(_data.loadData);
                    _data.SaveData();
                }
                playingType = PlayingType.End;
                yield return new WaitForSeconds(Time.deltaTime);
            }
            else if (playingType == PlayingType.End)
            {
                yield return null;
            }
        }
    }

    private void SetEndAnim()
    {
        _heart.SetActive(false);
    }

}
