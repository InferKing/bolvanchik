using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private bool _withTarget;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector3 _target = Vector3.zero;
    private float radius = 6;
    private float time = 0;
    private int numberOfSpawner;

    private void Update()
    {
        if (_withTarget)
        {
            time += Time.deltaTime;
            radius -= Time.deltaTime * 0.7f;
            transform.position = new Vector3(radius * Mathf.Sin(time*4*SpawnerManager.speed + numberOfSpawner*2), 
                radius * Mathf.Cos(time*4*SpawnerManager.speed + numberOfSpawner*2), 1);
        }
    }

    public void SetNumberOfSpawner(int x)
    {
        numberOfSpawner = x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            if (!MainManager.isDebug)
                MainManager.playingType = PlayingType.Stop;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-(transform.position-collision.transform.position), ForceMode2D.Impulse);
        }
        else if (collision.collider.tag == "Player")
        {
            if (_withTarget)
            {
                _rigidbody.AddForce(-(_target - collision.transform.position) * 2, ForceMode2D.Impulse);
                _withTarget = false;
            }
        }
    }
}
