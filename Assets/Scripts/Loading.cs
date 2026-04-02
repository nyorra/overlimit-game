using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Метод визуализации слайдера, пока только прогрузка слайдера
public class Loading: MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        
        StartCoroutine(AnimateSlider());
        Debug.Log("Загрузка завершена!");
    }

    IEnumerator AnimateSlider()
    {

        slider.value = 0f;

        while (slider.value < 1f)
        {
            slider.value += 0.0005f;
            yield return null; 
        }

        
    }

}