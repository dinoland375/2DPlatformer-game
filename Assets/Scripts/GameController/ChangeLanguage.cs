using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    public GameObject engLanguage;
    public GameObject rusLanguage;
    public Dropdown dropdown1;
    public Dropdown dropdown2;

    private void Update()
    {
        if (dropdown2.value <= 0)
        {
            engLanguage.SetActive(true);
            rusLanguage.SetActive(false);
        }
        if (dropdown1.value >= 1)
        {
            engLanguage.SetActive(false);
            rusLanguage.SetActive(true);
        }
    }
}
