using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    public static Action start;
    public static Action<List<int>> setSpawners;
    public static float speed = 1f + Mathf.Sqrt(MainManager.wave) / 10;
    private List<int> _sideSpawners = new List<int>(); // need for UI

    private void OnEnable()
    {
        start += StartWave;
        _sideSpawners.Clear();
    }

    private void OnDisable()
    {
        start -= StartWave;
        _sideSpawners.Clear();
    }

    private void StartWave()
    {
        speed = 1 + Mathf.Sqrt(MainManager.wave) / 10;
        _sideSpawners.Clear();
        switch (MainManager.wave % 7)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    _spawners[i].StartEnemy(0);
                    _sideSpawners.Add(i);
                }
                MainManager.waveTime = 6;
                break;
            case 1:
                _spawners[1].StartEnemy(0);
                _spawners[3].StartEnemy(0);
                _sideSpawners.Add(1);
                _sideSpawners.Add(3);
                MainManager.waveTime = 6;
                break;
            case 2:
                _spawners[0].StartEnemy(0);
                _spawners[2].StartEnemy(0);
                _sideSpawners.Add(0);
                _sideSpawners.Add(2);
                MainManager.waveTime = 6;
                break;
            case 3:
                _spawners[0].StartEnemy(0);
                _spawners[2].StartEnemy(0);
                _spawners[1].StartEnemy(1);
                for (int i = 0; i < 3; i++)
                {
                    _sideSpawners.Add(i);
                }
                MainManager.waveTime = 5;
                break;
            case 4:
                _spawners[1].StartEnemy(0);
                _spawners[3].StartEnemy(0);
                _spawners[0].StartEnemy(2.5f);
                _spawners[2].StartEnemy(2.5f);
                for (int i = 0; i < 4; i++)
                {
                    _sideSpawners.Add(i);
                }
                MainManager.waveTime = 6;
                break;
            case 5:
                _spawners[0].StartEnemy(0, 6);
                _spawners[1].StartEnemy(0, 6);
                _spawners[2].StartEnemy(0, 6);
                MainManager.waveTime = 6;
                break;
            case 6:
                for (int i = 0; i < 4; i++)
                {
                    _spawners[i].StartEnemy(0.3f, 7, 10);
                    _sideSpawners.Add(i);
                }
                MainManager.waveTime = 8;
                break;
        }
        setSpawners?.Invoke(_sideSpawners);
    }
}
