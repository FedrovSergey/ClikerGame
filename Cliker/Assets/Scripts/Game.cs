using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] int Score;

    public Text ScoreText;

    private Save sv = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            Score = sv.Score;
        }
    }

    public void OnClickButton()
    {
        Score++;
    }

    private void Update()
    {
        ScoreText.text = Score + "₽";
    }

    private void OnAppicationQuit()
    {
        sv.Score = Score;
        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }
}
[Serializable]
public class Save
{
    public int Score;
}
