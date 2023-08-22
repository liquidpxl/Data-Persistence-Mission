using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BestScoreManager : MonoBehaviour
{
    [Serializable]
    public class BestScoreData
    {
        public string playerName;
        public int bestScore;
    }

    public static BestScoreManager Instance;

    public BestScoreData bestScoreData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScoreData();
    }

    private void LoadBestScoreData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "bestScoreData.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            bestScoreData = JsonUtility.FromJson<BestScoreData>(json);
        }
        else
        {
            bestScoreData = new BestScoreData
            {
                playerName = "No Name",
                bestScore = 0
            };
        }
    }

    public void SaveBestScoreData()
    {
        string json = JsonUtility.ToJson(bestScoreData);
        string filePath = Path.Combine(Application.persistentDataPath, "bestScoreData.json");
        File.WriteAllText(filePath, json);
    }
}
