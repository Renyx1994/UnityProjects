using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class TunnelController : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Name;
    public Text Rate;
    public Text Description;
    public int x;

    private StringReader sr;
    private string[][] rock;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
        TextAsset fs = (TextAsset) Resources.Load("rock");
        sr = new StringReader (fs.text);
        string str = "";
        rock = new string[5][];
        for (int i = 0; i < 5; i++)
        {
            str = sr.ReadLine();
            rock[i] = str.Split(',');
        }
        sr.Close();
    }

    void OnMouseEnter()
    {
        mat.color = Color.yellow;
        Name.text = rock[x][1];
        Rate.text = "围岩等级：" + rock[x][2];
        Description.text = "描述：" + rock[x][3];
    }

    void OnMouseExit()
    {
        mat.color = col;
    }
}
