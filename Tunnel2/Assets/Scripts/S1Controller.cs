using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1Controller : MonoBehaviour {

    private MeshRenderer mr;
    private MeshRenderer mr2;
    private Material mat;
    private Material mat2;
    private Color col;

    public Text Sensor;
    public Text Value;
    public GameObject S;
    public float displacement;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
        mr2 = S.GetComponent<MeshRenderer>();
        mat2 = mr2.material;
    }

    void OnMouseEnter()
    {
        mat.color = Color.blue;
        mat2.color = Color.blue;
        Sensor.text = "水平净空收敛监测";
        if (displacement > 0.5)
        {
            Value.text = displacement + "毫米\n" +
                "超过预警值，危险！！！";
        }
        else
        {
            Value.text = displacement + "毫米";
        }
    }

    void OnMouseExit()
    {
        mat.color = col;
        mat2.color = col;
        Sensor.text = "";
        Value.text = "";
    }
}
