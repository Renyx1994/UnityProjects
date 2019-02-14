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
            Support.text = "超前支护与加固（超前中空注浆锚杆、小导管和格栅钢架配合使用）——>初喷砼施工(首次喷射混凝土厚度不少于40毫米)——>锚杆、挂网施工——>钢架、钢格栅支护——>湿喷砼施工——>二次衬砌施工";
        }
        else
        {
            Support.text = "超前支护(小导管、中空注浆锚杆及普通砂浆锚杆配合使用)——>安设钢拱架(分为型钢钢架和格栅钢架两种,型钢钢架采用I22型I18型工字钢弯制而成,格栅钢架主要由四根Φ22主筋和其他钢筋制成)——>挂设钢筋网(钢筋网片采用Ⅰ级φ8/φ6钢筋焊制而成，钢筋网片的间距为20cm)——>湿喷砼施工";
        }
    }
}
