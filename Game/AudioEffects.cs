using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _heartBeating;
    [SerializeField] private AudioSource _crackingHeart;

    public void HeartBeating()
    {
        if (MainManager.settings.isSound)
            _heartBeating.Play();
    }

    public void CrackingHeart()
    {
        if (MainManager.settings.isSound)
            _crackingHeart.Play();
    }

}
