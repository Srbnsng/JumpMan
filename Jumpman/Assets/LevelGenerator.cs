using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject boostPlatformPrefab;
    public GameObject brokenPlatformPrefab;

    public int nrOfPlatforms = 50;
    public float levelwidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        float x;
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < nrOfPlatforms; i++)
        {
            x = -levelwidth;
            spawnPosition.y += Random.Range(minY, maxY);
            
          
            for(int j = 0; j < 4; j++)
            {
                spawnPosition.x = Random.Range(x,x+levelwidth/2);
                x = x + levelwidth/2;
                var random = Random.Range(0f, 1f);
                if (random < .1f)
                {
                    Instantiate(boostPlatformPrefab, spawnPosition, Quaternion.identity);

                }
                else if (random > .1f && random < .3f)
                {
                    Instantiate(brokenPlatformPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
