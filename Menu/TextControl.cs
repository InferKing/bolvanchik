using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private bool _score, _fade, _moving;
    private Data data;
    private void Start()
    {
        if (_score)
        {
            data = new Data();
            data.LoadData();
            data.SaveData();
            _text.text = $"Best score: {data.loadData.BestScore}";

        }
        if (_fade)
        {
            StartCoroutine(Fade());
        }
        if (_moving)
        {
            StartCoroutine(Moving());
        }
    }

    private IEnumerator Fade()
    {
        float duration = 0.005f;
        float current = 1f;
        bool dir = false;
        while (true)
        {
            if (dir) current += duration;
            else current -= duration;
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, Mathf.Lerp(0f, 1f, current));
            if (current < 0.4f) dir = true;
            else if (current > 0.99f) dir = false;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    private IEnumerator Moving()
    {
        while (true)
        {
            _text.transform.position = new Vector3(_text.transform.position.x, 
                _text.transform.position.y + Mathf.Sin(Time.timeSinceLevelLoad*3)/90,_text.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
