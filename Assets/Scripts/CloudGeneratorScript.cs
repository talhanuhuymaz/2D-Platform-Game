using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;


    [SerializeField]
    GameObject enPoint;

    Vector3 startPos;

    void Start()
    {

        startPos = transform.position;
        PreWarm();
        Invoke("AttemptSpawn", spawnInterval);
    }
    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, 3);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        float startY = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 1f);

        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);
        
        
        float scale = UnityEngine.Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale, scale);


        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<cloudscript>().StartFloating(speed, enPoint.transform.position.x);
    }


    void AttemptSpawn()
    {

        SpawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }


    void PreWarm()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
        }


    }
}
