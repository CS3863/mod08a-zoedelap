using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data; 
    public GameObject myCube; //prefab
    int cubeCount; //variable 

    private float startDelay = 2.0f;
    private float timeInterval = 0.5f;

    void Awake()
    {
        data = CSVReader.Read("narrow_co2");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            print("CO2 (row " + i + ") " + data[i]["xco2"]);
        }
    }

    void Start()
    {
        for (var i = 0; i < data.Count; i++)
        {
            object xco2 = data[i]["xco2"]; //get age data
            cubeCount += (int)xco2; //convert age data to int and add to cubeCount
            Debug.Log("cubeCount " + cubeCount);
        }

        InvokeRepeating("spawnObj", startDelay, timeInterval);

    }

    void Update()
    {
        //As long as cube count is not zero, instantiate prefab
        // while (cubeCount > 0)
        // {
        //     Instantiate(myCube);
        //     cubeCount--;
        //     Debug.Log("cubeCount " + cubeCount);
        // }
    }

    void spawnObj() {
        if (cubeCount > 0) {
            Instantiate(myCube);
            cubeCount--;
            Debug.Log("cubeCount" + cubeCount);
        }
    }
}