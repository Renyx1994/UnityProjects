using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using MercuryMessaging;

public class CreateObject : MmBaseResponder {

    public GameObject righthand;
    public GameObject lefthand;
    public GameObject CubePrefab;
    public GameObject CylinderPrefab;
    public float sizingFactor;
    public float positionZ;

    private GameObject lastSpawn = null;
    private int signal;
    private int lastsig;
    private Vector3 lastpos;
    int typ;
    private Vector3 fst;
    private Vector3 snd;
    private bool mode;

    //private float startSizeZ;
    //private float startSizeX;
    //private float startSizeY;

    // Use this for initialization
    public override void Start()
    {
        signal = 0;
        typ = 0;
        mode = true;
    }

    public override void Update()
    {
        if (mode)
        {
            if (typ == 1)
                BuildBlock();
            if (typ == 2)
                BuildCylinder();
        }
        else
        {
            if (typ == 1)
                BuildBlock2();
            if (typ == 2)
                BuildCylinder2();
        }
    }

    public void Switchmode()
    {
        mode = !mode;
        Debug.Log(mode);
    }

    void BuildCylinder()
    {
        if (signal > 0)
        {
            if (lastsig <= 0)
            {
                //fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(0).TipPosition.ToVector3();
                //Debug.Log(signal);
                fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                Vector3 position = new Vector3(fst.x, fst.y+0.2f, positionZ);
                //BuildBlock(position);
                lastSpawn = Instantiate(CylinderPrefab, position, CylinderPrefab.transform.rotation) as GameObject;
                /*startSizeZ = lastSpawn.transform.localScale.z;
                startSizeX = lastSpawn.transform.localScale.x;
                startSizeY = lastSpawn.transform.localScale.y;*/
            }

            switch (signal)
            {
                case 1:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 size = lastSpawn.transform.localScale;
                    size.x = Mathf.Abs(snd.x - fst.x) * sizingFactor;
                    size.z = size.x;
                    lastSpawn.transform.localScale = size;
                    break;
                case 2:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 sizeZ = lastSpawn.transform.localScale;
                    sizeZ.y = Mathf.Abs(snd.z - fst.z) * sizingFactor / 2f;
                    lastSpawn.transform.localScale = sizeZ;
                    Vector3 tpos = lastSpawn.transform.position;
                    tpos.z = positionZ + (snd.z - fst.z) * sizingFactor / 4f;
                    lastSpawn.transform.position = tpos;
                    break;
                case 3:
                    signal = 0;
                    typ = 0;
                    lastSpawn.GetComponent<Rigidbody>().useGravity = true;
                    break;
                default:
                    Debug.Log(signal);
                    break;
            }
        }
        lastsig = signal;
    }

    void BuildBlock()
    {
        /*GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = pos;
        //cube.transform.localScale = snd - fst;
        cube.AddComponent<Rigidbody>();
        return cube;*/
        if (signal > 0)
        {
            if (lastsig <= 0)
            {
                //fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(0).TipPosition.ToVector3();
                //Debug.Log(signal);
                fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                Vector3 position = new Vector3(fst.x, fst.y, positionZ);
                //BuildBlock(position);
                lastSpawn = Instantiate(CubePrefab, position, transform.rotation) as GameObject;
                /*startSizeZ = lastSpawn.transform.localScale.z;
                startSizeX = lastSpawn.transform.localScale.x;
                startSizeY = lastSpawn.transform.localScale.y;*/
            }

            switch (signal)
            {
                case 1:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 size = lastSpawn.transform.localScale;
                    size.x = Mathf.Abs(snd.x - fst.x) * sizingFactor;
                    size.y = Mathf.Abs(snd.y - fst.y) * sizingFactor;
                    lastSpawn.transform.localScale = size;
                    Vector3 temppos = new Vector3(fst.x + (snd.x - fst.x) * sizingFactor / 2f, fst.y + (snd.y - fst.y) * sizingFactor / 2f, positionZ);
                    lastSpawn.transform.position = temppos;
                    break;
                case 2:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 sizeZ = lastSpawn.transform.localScale;
                    sizeZ.z = Mathf.Abs(snd.z - fst.z) * sizingFactor;
                    lastSpawn.transform.localScale = sizeZ;
                    Vector3 tpos = lastSpawn.transform.position;
                    tpos.z = positionZ + (snd.z - fst.z) * sizingFactor / 2f;
                    lastSpawn.transform.position = tpos;
                    break;
                case 3:
                    signal = 0;
                    typ = 0;
                    lastSpawn.GetComponent<Rigidbody>().useGravity = true;
                    break;
                default:
                    Debug.Log(signal);
                    break;
            }
        }
        lastsig = signal;
    }

    void BuildCylinder2()
    {
        if (signal > 0)
        {
            if (lastsig <= 0)
            {
                //fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(0).TipPosition.ToVector3();
                //Debug.Log(signal);
                fst = lefthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                //Vector3 position = new Vector3(fst.x, fst.y + 0.2f, positionZ);
                lastpos = new Vector3((fst.x + snd.x) / 2f, (fst.y + snd.y) / 2f, positionZ);
                //BuildBlock(position);
                lastSpawn = Instantiate(CylinderPrefab, lastpos, CylinderPrefab.transform.rotation) as GameObject;
                /*startSizeZ = lastSpawn.transform.localScale.z;
                startSizeX = lastSpawn.transform.localScale.x;
                startSizeY = lastSpawn.transform.localScale.y;*/
            }

            switch (signal)
            {
                case 1:
                    fst = lefthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 size = lastSpawn.transform.localScale;
                    size.x = Mathf.Abs(snd.x - fst.x) * sizingFactor / 2f;
                    size.z = size.x;
                    lastSpawn.transform.localScale = size;
                    Vector3 temppos = new Vector3((fst.x + snd.x) / 2f, (fst.y + snd.y) / 2f, positionZ);
                    lastSpawn.transform.Translate((temppos - lastpos)*1.5f*sizingFactor, Space.World);
                    lastpos = temppos;
                    //Vector3 temppos = new Vector3(fst.x, fst.y + 0.2f, positionZ);
                    //lastSpawn.transform.position = temppos;
                    break;
                case 2:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 sizeZ = lastSpawn.transform.localScale;
                    sizeZ.y = Mathf.Abs(snd.z - fst.z) * sizingFactor;
                    lastSpawn.transform.localScale = sizeZ;
                    Vector3 tpos = lastSpawn.transform.position;
                    tpos.z = positionZ + (snd.z - fst.z) * sizingFactor / 2f;
                    lastSpawn.transform.position = tpos;
                    break;
                case 3:
                    signal = 0;
                    typ = 0;
                    lastSpawn.GetComponent<Rigidbody>().useGravity = true;
                    break;
                default:
                    Debug.Log(signal);
                    break;
            }
        }
        lastsig = signal;
    }

    void BuildBlock2()
    {
        if (signal > 0)
        {
            if (lastsig <= 0)
            {
                //fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(0).TipPosition.ToVector3();
                //Debug.Log(signal);
                fst = lefthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                lastpos = new Vector3((fst.x + snd.x) / 2f, (fst.y + snd.y) / 2f, positionZ);

                //BuildBlock(position);
                lastSpawn = Instantiate(CubePrefab, lastpos, transform.rotation) as GameObject;
                /*startSizeZ = lastSpawn.transform.localScale.z;
                startSizeX = lastSpawn.transform.localScale.x;
                startSizeY = lastSpawn.transform.localScale.y;*/
            }

            switch (signal)
            {
                case 1:
                    fst = lefthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 size = lastSpawn.transform.localScale;
                    size.x = Mathf.Abs(snd.x - fst.x) * sizingFactor;
                    size.y = Mathf.Abs(snd.y - fst.y) * sizingFactor;
                    lastSpawn.transform.localScale = size;
                    Vector3 temppos = new Vector3((fst.x + snd.x) / 2f, (fst.y + snd.y) / 2f, positionZ);
                    lastSpawn.transform.Translate((temppos - lastpos)*1.5f*sizingFactor, Space.World);
                    lastpos = temppos;
                    //lastSpawn.transform.position = temppos;
                    break;
                case 2:
                    snd = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
                    Vector3 sizeZ = lastSpawn.transform.localScale;
                    sizeZ.z = Mathf.Abs(snd.z - fst.z) * sizingFactor;
                    lastSpawn.transform.localScale = sizeZ;
                    Vector3 tpos = lastSpawn.transform.position;
                    tpos.z = positionZ + (snd.z - fst.z) * sizingFactor / 2f;
                    lastSpawn.transform.position = tpos;
                    break;
                case 3:
                    signal = 0;
                    typ = 0;
                    lastSpawn.GetComponent<Rigidbody>().useGravity = true;
                    break;
                default:
                    Debug.Log(signal);
                    break;
            }
        }
        lastsig = signal;
    }

    public override void MmInvoke(MmMessageType msgType, MmMessage message)
    {
        var type = message.MmMethod;

        switch (type)
        {
            case (MmMethod)Build_Methods.Sig:
                if (typ > 0)
                    signal += 1;
                //Debug.Log(signal);
                break;
            case (MmMethod)Build_Methods.Objtyp:
                if (signal == 0)
                    typ = ((MmMessageInt)message).value;
                Debug.Log(typ);
                break;
            default:
                base.MmInvoke(msgType, message);
                break;
        }
    }
}


/*            case (MmMethod)Leap_Methods.Snd:
                snd = ((MmMessageVector3)message).value;
                break;
*/