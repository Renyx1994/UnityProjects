using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class SupportC : MonoBehaviour {

    private Text Station;
    private Text Support;

    private float Z;
    private int a;
    private StringReader sr;
    private string[][] support;

    void Start()
    {
        TextAsset fs = (TextAsset)Resources.Load("support");
        sr = new StringReader(fs.text);
        string str = "";
        support = new string[5][];
        for (int i = 0; i < 5; i++)
        {
            str = sr.ReadLine();
            support[i] = str.Split(',');
        }
        sr.Close();
        Station = GameObject.Find("Canvas").transform.FindChild("Panel2").FindChild("Stat").gameObject.GetComponent<Text>();
        Support = GameObject.Find("Canvas").transform.FindChild("Panel2").FindChild("Text").gameObject.GetComponent<Text>();
    }

    void LateUpdate()
    {
        Z = GetComponent<Transform>().position.z;
        a = (int)(-0.416f * Z + 973.16f);
        Station.text = "桩号：K0+" +a.ToString();
        if (a <= 875)
        {
            Support.text = "支护条件：喷射混凝土平均厚度为" + support[1][1] + "，钢支撑支护类型为" + support[1][2] + "，榀数" + support[1][3] + "，间距" + support[1][4] + "厘米";
        }
        else if (a <= 910)
        {
            Support.text = "支护条件：喷射混凝土平均厚度为" + support[2][1] + "，钢支撑支护类型为" + support[2][2] + "，榀数" + support[2][3] + "，间距" + support[2][4] + "厘米";
        }
        else if (a <= 935)
        {
            Support.text = "支护条件：喷射混凝土平均厚度为" + support[3][1] + "，钢支撑支护类型为" + support[3][2] + "，榀数" + support[3][3] + "，间距" + support[3][4] + "厘米";
        }
        else
        {
            Support.text = "支护条件：喷射混凝土平均厚度为" + support[4][1] + "，钢支撑支护类型为" + support[4][2] + "，榀数" + support[4][3] + "，间距" + support[4][4] + "厘米";
        }
    }
}
