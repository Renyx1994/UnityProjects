using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class SC : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;
    private float settlement;

    public Text Sensor;
    public Text Value;
    public int x;

    private StringReader sr;
    private string[][] mon;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
        TextAsset fs = (TextAsset)Resources.Load("monitor");
        sr = new StringReader(fs.text);
        string str = "";
        mon = new string[3][];
        for (int i = 0; i < 3; i++)
        {
            str = sr.ReadLine();
            mon[i] = str.Split(',');
        }
        sr.Close();
    }

    void OnMouseEnter()
    {
        mat.color = Color.red;
        Sensor.text = mon[x][1];
        settlement = float.Parse(mon[x][2]);
        if (settlement < 11.5)
        {
            Value.text = settlement + "厘米\n" +
                "不符合标准，危险！！！";
        }
        else
        {
            Value.text = settlement + "厘米";
        }
    }

    void OnMouseExit()
    {
        mat.color = col;
        Sensor.text = "";
        Value.text = "";
    }
}
