using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float curX = 0;
    void Start()
    {
        StartCoroutine(To100());
    }

    private IEnumerator To100()
    {
        while (curX < slider.maxValue * 0.6f)
        {
            curX += Random.value + 0.4f;
            slider.value = curX;
            yield return new WaitForSeconds(Time.deltaTime * 2);
        }
        yield return new WaitForSeconds(1f);
        while (curX < slider.maxValue)
        {
            curX++;
            slider.value = Mathf.Clamp(curX,slider.minValue,slider.maxValue);
            yield return new WaitForSeconds(Time.deltaTime * 0.01f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("MainGame");
    }
}
