using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static int gold;
    int goalGold;
    int winScreen;

    public static event Action<int> onPlayerWon;
    public static event Action<int> onRestart;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
    }

    void Start()
    {
        goalGold = 1000;
        winScreen = 3;

        onPlayerWon += RestartScore;
        onRestart += RestartScore;
    }

    void Update()
    {
        if (gold >= goalGold && onPlayerWon != null)
            onPlayerWon(winScreen);
    }

    void RestartScore(int screen)
    {
        gold = 0;
    }
}