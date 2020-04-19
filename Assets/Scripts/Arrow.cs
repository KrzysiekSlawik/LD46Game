using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Skip")&&PlayerPrefs.GetInt("Skip") != 0)
        {
            gameObject.SetActive(false);
        }
    }
}
