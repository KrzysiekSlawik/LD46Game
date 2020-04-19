using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public GameObject on;
    public GameObject off;
    public void Switch()
    {
        int skip = PlayerPrefs.GetInt("Skip");
        skip = skip == 0 ? 1 : 0;
        PlayerPrefs.SetInt("Skip", skip);
        UpdateState();
    }
    private void Start()
    {
        UpdateState();
    }
    public void UpdateState()
    {
        if(!PlayerPrefs.HasKey("Skip"))
        {
            PlayerPrefs.SetInt("Skip", 0);
        }
        int skip = PlayerPrefs.GetInt("Skip");
        if(skip == 1)
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        else
        {
            on.SetActive(true);
            off.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
