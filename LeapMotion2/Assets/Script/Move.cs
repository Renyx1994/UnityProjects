using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using MercuryMessaging;

public class Move : MmBaseResponder
{
    public float movespeed = 5f;
    public float turnspeed = 5f;
    public GameObject righthand;

    private bool move;
    private bool rotate;
    private bool decre;
    private bool incre;
    private Vector3 lastpos;
    private Quaternion lastrot;
    //private float lastpitch;
    //private float lastyaw;
    //private float lastroll;

    // Use this for initialization
    public override void Start () {
        lastpos = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
        float x1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.x;
        float y1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.y;
        float z1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.z;
        float w1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.w;
        lastrot = new Quaternion(x1, y1, z1, w1); 
        //lastpitch = righthand.GetComponent<CapsuleHand>().GetLeapHand().Direction.Pitch;
        //lastyaw = righthand.GetComponent<CapsuleHand>().GetLeapHand().Direction.Yaw;
        //lastroll = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmNormal.Roll;
        move = false;
        rotate = false;
        decre = false;
        incre = false;
    }

    // Update is called once per frame
    public override void Update () {
        Vector3 handpos = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
        float x2 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.x;
        float y2 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.y;
        float z2 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.z;
        float w2 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.w;
        Quaternion handrot = new Quaternion(x2, y2, z2, w2);
        if (move)
        {
            transform.Translate((handpos - lastpos) * movespeed, Space.World);
        }
        if (rotate)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Inverse(lastrot) * handrot, turnspeed);
            //transform.rotation = Quaternion.Lerp(lastrot, handrot, 1f);
            transform.rotation = transform.rotation * Quaternion.Inverse(lastrot) * handrot;
        }
        Vector3 temp = transform.localScale;
        if (decre)
        {
            if (incre)
            {
                transform.localScale = temp * (1 + 0.1f * Time.deltaTime);
            }
            else {
                transform.localScale = temp * (1 - 0.1f * Time.deltaTime);
            }
        }
        
        lastpos = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
        float x1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.x;
        float y1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.y;
        float z1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.z;
        float w1 = righthand.GetComponent<CapsuleHand>().GetLeapHand().Rotation.w;
        lastrot = new Quaternion(x1, y1, z1, w1);
        //lastpitch = righthand.GetComponent<CapsuleHand>().GetLeapHand().Direction.Pitch;
        //lastyaw = righthand.GetComponent<CapsuleHand>().GetLeapHand().Direction.Yaw;
        //lastroll = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmNormal.Roll;
    }

    public override void MmInvoke(MmMessageType msgType, MmMessage message)
    {
        var type = message.MmMethod;

        switch (type)
        {
            case (MmMethod)Leap_Methods.Translate:
                move = ((MmMessageBool)message).value;
                break;
            case (MmMethod)Leap_Methods.Rotation:
                rotate = ((MmMessageBool)message).value;
                break;
            case (MmMethod)Leap_Methods.Increase:
                incre = ((MmMessageBool)message).value;
                break;
            case (MmMethod)Leap_Methods.Decrease:
                decre = ((MmMessageBool)message).value;
                break;
            default:
                base.MmInvoke(msgType, message);
                break;
        }
    }


    /*public void startmove()
    {
        move = true;
    }

    public void stopmove()
    {
        move = false;
    }

    public void startrotate()
    {
        rotate = true;
    }

    public void stoprotate()
    {
        rotate = false;
    }

    public void startscale()
    {
        scale = true;
    }

    public void stopscale()
    {
        scale = false;
    }

    public void startsincre()
    {
        incre = true;
    }

    public void startdecre()
    {
        incre = false;
    }

    public void backwards() {
           transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
       }

       public void frontwards()
       {
           transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
       }

       public void upwards()
       {
           transform.Translate(Vector3.up * movespeed * Time.deltaTime);
       }
       public void downwards()
       {
           transform.Translate(-Vector3.up * movespeed * Time.deltaTime);
       }

       public void leftwards()
       {
           transform.Translate(Vector3.left * movespeed * Time.deltaTime);
       }

       public void rightwards()
       {
           transform.Translate(Vector3.right * movespeed * Time.deltaTime);
       }

       public void increase()
       {
           Vector3 temp = transform.localScale;
           transform.localScale = temp * 1.1f;
       }

       public void decrease()
       {
           Vector3 temp = transform.localScale;
           transform.localScale = temp * 0.9f;
       }

       public void turnback()
       {
           transform.Rotate(Vector3.left, turnspeed * Time.deltaTime);
       }

       public void turnrignht()
       {
           transform.Rotate(Vector3.forward, -turnspeed * Time.deltaTime);
       }*/
}
