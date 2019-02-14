using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportController : MonoBehaviour {

    public GameObject player;
    public Text Station;
    public Text Support;

    private float Z;
    private int a;
    private int b;
	
	void LateUpdate () {
        Z = player.transform.position.z;
        a = (int)-Z / 10;
        b = (int)((-Z - a * 10) * 100);
        Station.text = "桩号：" + a.ToString() + "+" + b.ToString("000");
        if(Z <= -30)
        {
            Support.text = "超前支护、二次衬砌";
        }
        else
        {
            Support.text = "超前支护、湿喷砼施工";
        }
    }
}
