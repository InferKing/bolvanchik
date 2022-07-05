using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawns;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private int numberOfSpawner;
    private GameObject temp;

    public void StartEnemy(float delay, int index = -1, int amount = 1)
    {
        StartCoroutine(Play(delay, index, amount));
    }
    private IEnumerator Play(float delay, int ind, int amount)
    {
        int index;
        for (int i = 0; i < amount; i++)
        {
            if (ind == -1)
            {
                index = Random.Range(0, _spawns.Length - 2);
            }
            else
            {
                index = ind;
            }
            yield return new WaitForSeconds(delay);
            temp = Instantiate(_spawns[index]);
            temp.GetComponentInChildren<EnemyBehaviour>().SetNumberOfSpawner(numberOfSpawner);
            temp.transform.position = transform.position;
            temp.transform.Rotate(0, 0, 90f * numberOfSpawner);
            foreach (var item in temp.GetComponentsInChildren<Rigidbody2D>())
            {
                item.velocity = _direction * SpawnerManager.speed;
            }
        }
    }

}
