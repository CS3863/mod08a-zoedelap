using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data; 
    
    int rowNum = 0;

    private int startDelay = 1.0f;
    private int timeInterval = 0.5f;

    void Awake()
    {
        data = CSVReader.Read("narrow_co2");

        for (var i = 0; i < data.Count; i++)
        {
            print("CO2 (row " + i + ") " + data[i]["xco2"]);
        }
    }

    void Start()
    {
        InvokeRepeating("spawnObj", startDelay, timeInterval);
    }

    void spawnObj() {
        
    }
}