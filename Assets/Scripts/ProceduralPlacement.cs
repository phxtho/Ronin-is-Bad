﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralPlacement : MonoBehaviour
{
    public static ProceduralPlacement instance;
    const int MAX_ENEMY_COUNT = 10;
    const float MIN_ENEMY_RADIUS = 10;
    const int MAX_LEVEL = 10;
    public GameObject enemyPrefab, ammoPrefab;
    public int CurrentLevel;
    public AnimationCurve difficultyCurve;
    [Range(0, 100)]
    public float difficultyBufferPercentage;
    int numberOfEnemies;

    private List<GameObject> _ammoClips, _enemies;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        _ammoClips = new List<GameObject>();
        _enemies = new List<GameObject>();
        GenerateLevel(0);
    }

    void PlaceEnemies()
    {
        //Figure out the number of enemies
        numberOfEnemies = CurrentLevel;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Get a placement position
            Vector3 enemyPos = RandomPosition();
            if (Mathf.Sqrt(enemyPos.sqrMagnitude) <= MIN_ENEMY_RADIUS)
            {
                enemyPos = enemyPos.normalized * MIN_ENEMY_RADIUS;
            }

            // Place enemy
            GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
            // Add enemy to list
            _enemies.Add(enemy);
        }
    }

    void PlaceAmmo()
    {
        //Figure out the number of clips
        int numberOfClips = 0;
        numberOfClips = (int)(numberOfEnemies + (difficultyBufferPercentage / 10));
        for (int j = 0; j < numberOfClips; j++)
        {
            // Get a placement position
            Vector3 ammoPos = RandomPosition();
            // if (_ammoClips.Count > 0)
            // {
            //     foreach (var clip in _ammoClips)
            //     {
            //         if (clip.transform.position == ammoPos)
            //         {
            //             ammoPos = RandomPosition();
            //         }
            //     }
            // }
            // Instantiate ammo
            GameObject ammo = Instantiate(ammoPrefab, ammoPos, Quaternion.identity);
            // Add ammo to list
            _ammoClips.Add(ammo);
        }
    }

    public void GenerateLevel(int level)
    {
        CurrentLevel = level;
        Reset();
        PlaceEnemies();
        PlaceAmmo();
        GameController.instance.gameState = GameState.PLAYING;
    }

    public Vector3 RandomPosition()
    {
        float x = Random.Range(-10, 10);
        float z = Random.Range(-10, 10);
        return new Vector3(x, 1, z);
    }
    public void Reset()
    {
        FindObjectOfType<GameController>().gameOverTime = 30.0f;
        FindObjectOfType<Player.PlayerController>().gameObject.transform.position = Vector3.up;
        ClearAmmo();
    }
    public void RemoveEnemy(GameObject enemy)
    {
        _enemies.Remove(enemy);
    }

    public int GetEnemyCount()
    {
        return _enemies.Count;
    }

    public void ClearAmmo()
    {
        foreach (var ammo in _ammoClips)
        {
            if (ammo != null)
            {
                Destroy(ammo);
            }
        }
    }
}
