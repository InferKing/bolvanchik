using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimBreak : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool _started = false;
    private void Update()
    {
        if (!_started && MainManager.playingType == PlayingType.Stop)
        {
            _started = true;
            GetComponent<SpriteRenderer>().enabled = true;
            animator.SetBool("IsDied", _started);
        }
    }

}
