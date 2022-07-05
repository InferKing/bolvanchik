using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBalls : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private GameObject _prefab;
    private List<GameObject> _balls;
    private float _param;
    private void Start()
    {
        _balls = new List<GameObject>();
        for (int i = 0; i < _count; i++)
        {
            _balls.Add(Instantiate(_prefab));
        }
        for (int i = 0; i < _count; i++)
        {
            _param = (Random.value - 0.5f);
            _balls[i].transform.position = new Vector3(Random.value*6-3, -6, 0);
            _balls[i].transform.localScale = new Vector3(Mathf.Clamp(0.3f + _param,0.1f,0.7f), Mathf.Clamp(0.3f + _param, 0.1f, 0.7f), 1);
            SpriteRenderer sprite =_balls[i].GetComponent<SpriteRenderer>();
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + Random.value/4);
            StartCoroutine(PauseMove(Random.value/2+i,_balls[i],_param));
        }
    }
    private IEnumerator PauseMove(float time, GameObject gObj, float _param)
    {
        yield return new WaitForSeconds(time);
        gObj.GetComponent<Rigidbody2D>().velocity = Vector2.up*(3f-_param*4);
    }

}
