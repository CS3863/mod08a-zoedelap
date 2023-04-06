using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{
    /**
    * Tutorial link
    * https://github.com/tikonen/blog/tree/master/csvreader
    * */

    List<Dictionary<string, object>> data; 

    private float startDelay = 1.0f;
    private float timeInterval = 0.25f;

    private int rowCount = 0;
    private int rowMax;

    private object tempObj;
    private float tempFloat;

    // private Renderer objRenderer;

    void Awake()
    {
        // objRenderer = gameObject.GetComponent<Renderer>();

        data = CSVReader.Read("narrow_co2");

        rowMax = data.Count;
        
        for (var i = 0; i < data.Count; i++)
        {
            print("CO2 (row " + i + ") " + data[i]["xco2"]);
        }
    }

    void Start()
    {
        InvokeRepeating("modifyObj", startDelay, timeInterval);
    }

    void modifyObj() {
        if (rowCount < rowMax) {
            // get and convert the value, increment rowCount for the next iteration
            tempObj = data[rowCount]["xco2"];
            tempFloat = System.Convert.ToSingle(tempObj);
            // Debug.Log("current tempFloat: " + tempFloat + ", current row number: " + rowCount);
            rowCount++;

            // // update the color of the object
            // float colorValue = (tempFloat - 388) / (427 - 388);
            // Debug.Log("color value: " + colorValue + ", " + 0.0f + ", " + 0.02745f);
            // Color color = new Color(colorValue, 0.0f, 0.02745f, 1.0f);
            // Color color = Color.grey;
            // objRenderer.material.SetColor("_Color", color);
            
            // update the size of the item that this is attached to 
            tempFloat = (tempFloat - 350) * 5;
            transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);
        }
    }
}