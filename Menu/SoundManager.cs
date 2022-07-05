using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private AudioSource _audioSource;
    public static bool isSound;
    private void Start()
    {
        if (isSound)
        {
            _image.sprite = _sprites[0];
        }
        else
        {
            _image.sprite = _sprites[1];
        }
    }
    public void SetButton()
    {
        isSound = !isSound;
        if (isSound)
        {
            _audioSource.Play();
            _image.sprite = _sprites[0];
        }
        else
        {
            _audioSource.Stop();
            _image.sprite = _sprites[1];
        }
    }
}
