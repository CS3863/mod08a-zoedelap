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
        data = CSVReader.Read("udata");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("name " + data[i]["name"] + " " +
                   "age " + data[i]["age"] + " " +
                   "speed " + data[i]["speed"] + " " +
                   "desc " + data[i]["description"]);
        }
    }

    void Start()
    {
        for (var i = 0; i < data.Count; i++)
        {
            object age = data[i]["age"]; //get age data
            cubeCount += (int)age; //convert age data to int and add to cubeCount
            Debug.Log("cubeCount " +cubeCount);
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