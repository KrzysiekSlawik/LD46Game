using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public float pitchMin;
    public float pitchMax;
    public GameObject scorePrefab;
    private static Score instance;
    private float score;
    public UnityEvent onScored; 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public static Score Instance()
    {
        return instance;
    }
    public float AddScore(float score)
    {
        this.score += score;
        onScored.Invoke();
        SpawnScore(score);
        return score;
    }
    public float GetScore()
    {
        return score;
    }
    public void Submit(GameObject newHS)
    {
        if(!PlayerPrefs.HasKey("HS") || PlayerPrefs.GetFloat("HS") < GetScore())
        {
            PlayerPrefs.SetFloat("HS", GetScore());
            newHS.SetActive(true);
        }
        newHS.SetActive(false);
    }
    public void ScoreToTMP(TMPro.TextMeshProUGUI text)
    {
        text.text = score.ToString();
    }
    public void HighScoreToTMP(TMPro.TextMeshProUGUI text)
    {
        text.text = PlayerPrefs.GetFloat("HS").ToString();
    }
    public void SpawnScore(float points)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject scObj = Instantiate(scorePrefab, hit.point, Quaternion.identity);
            TMPro.TextMeshProUGUI txt = scObj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            txt.text = "+" + points.ToString();
            txt.fontSize = (1 + points/5) * 5;
            scObj.GetComponent<AudioSource>().pitch = Random.Range(pitchMin, pitchMax);
        }
    }
    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
