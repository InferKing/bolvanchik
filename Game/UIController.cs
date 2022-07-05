using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _waveText;
    [SerializeField] private TMP_Text _endTime;
    [SerializeField] private TMP_Text _pauseText;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private GameObject[] _sides;

    private bool _isPlaying = false;
    public float curTime = 0;
    
    private void OnEnable()
    {
        SpawnerManager.setSpawners += FadeSides;
    }

    private void OnDisable()
    {
        SpawnerManager.setSpawners -= FadeSides;
    }

    private void Update()
    {
        if (MainManager.playingType == PlayingType.Play)
        {
            curTime += Time.deltaTime*1.6f;
            _score.text = Mathf.Round(curTime).ToString();
            _endTime.text = $"Wave ends in: {Mathf.Round(MainManager.waveTime)}";
        }
        else if (MainManager.playingType == PlayingType.Stop)
        {
            _retryButton.gameObject.SetActive(true);
        }
        else if ((MainManager.playingType == PlayingType.Complete || MainManager.playingType == PlayingType.OnStart) && !_isPlaying)
        {
            _waveText.text = $"Wave {MainManager.wave}";
            StartCoroutine(Fade(_waveText));
        }
    }

    private IEnumerator Fade(TMP_Text _text)
    {
        _isPlaying = true;
        for (float current = 0f; current < 1f; current+=Time.deltaTime * 2)
        {
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, Mathf.Lerp(0f, 1f, current));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(1f);
        for (float current = 1f; current > 0f; current -= Time.deltaTime * 2)
        {
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, Mathf.Lerp(0f, 1f, current));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0f);
        _isPlaying = false;
    }

    private IEnumerator Fade(Image _sprite)
    {
        for (int i = 0; i < 3; i++)
        {
            for (float current = 0f; current < 1f; current += Time.deltaTime * 3)
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, Mathf.Lerp(0f, 1f, current));
                yield return new WaitForSeconds(Time.deltaTime);
            }
            for (float current = 1f; current > 0f; current -= Time.deltaTime * 3)
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, Mathf.Lerp(0f, 1f, current));
                yield return new WaitForSeconds(Time.deltaTime);
            }
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0f);
        }
    }

    private void FadeSides(List<int> indexes)
    {
        foreach (var item in indexes)
        {
            StartCoroutine(Fade(_sides[item].GetComponent<Image>()));
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void RetryButton()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
}
