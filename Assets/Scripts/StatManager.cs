using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int hp;
    public int startingHP = 3;
    public int ammo;
    public int startingAmmo = 128;
    public int ammoGain = 16;
    public int zombiesKilled = 0;
    public bool hasKey = false;
    public float timePlayed = 0f;
    public bool isRunning = false;
    private static StatManager instance;

    public static StatManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("StatManager").AddComponent<StatManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        hp = startingHP;
        ammo = startingAmmo;
        DontDestroyOnLoad(this);
        StartTimer();
    }

    void Update()
    {
        RunTimer();
        GameOver();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame();
        }
    }

    public void DecreaseHealth()
    {
        hp--;      
    }

    public void IncreaseHealth()
    {
        hp++;
    }

    public void Shoot()
    {
        ammo--;
    }

    public void GetAmmo()
    {
        ammo += ammoGain;
    }

    public void ZombieKilled()
    {
        zombiesKilled++;
    }


    public void GameOver()
    {
        if (hp == 0)
        {
            ResetGame();
        }      
    }

    public void ResetGame()
    {
        GameManager.Instance.LoadMainMenu();
        hp = startingHP;
        ammo = startingAmmo;
        zombiesKilled = 0;
        hasKey = false;
        StopTimer();
        ResetTimer();
    }

    #region timer
    public void StartTimer()
    {
        isRunning = true;
    }

    public void RunTimer()
    {
        if (isRunning == true)
        {
            timePlayed += Time.deltaTime;
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timePlayed = 0f;
    }
    #endregion

}
