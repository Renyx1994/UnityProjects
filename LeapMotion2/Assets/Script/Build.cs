using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using MercuryMessaging;

public enum Build_Methods
{
    Sig = 105, Objtyp = 106
}

public class Build : MonoBehaviour {

    MmRelayNode _myRelayNode;
    bool check;
    bool lastcheck;


    // Use this for initialization
    void Start()
    {
        
        _myRelayNode = GetComponent<MmRelayNode>();
        check = false;
        lastcheck = false;
    }

    public void startbuild()
    {
        check = true;
    }


    public void stopbuild()
    {
        check = false;
    }

    void Update()
    {

        if ((check) && (!lastcheck))
        {
            _myRelayNode.MmInvoke((MmMethod)Build_Methods.Sig,
               new MmMetadataBlock(MmLevelFilter.Child));
        }
        lastcheck = check;
    }

    /*public void buildObj()
    {
        if (check)
        {
        Vector3 fstp = lefthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(1).TipPosition.ToVector3();
             MmMessageVector3 fstpoint = new MmMessageVector3(fstp);
             _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Fst, fstpoint, MmMessageType.MmVector3,
                            new MmMetadataBlock(MmLevelFilter.Child));
             Vector3 sndp = righthand.GetComponent<CapsuleHand>().GetLeapHand().Finger(1).TipPosition.ToVector3();
             MmMessageVector3 sndpoint = new MmMessageVector3(sndp);
             _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Snd, sndpoint, MmMessageType.MmVector3,
                            new MmMetadataBlock(MmLevelFilter.Child));
            _myRelayNode.MmInvoke((MmMethod)Leap_Methods.BuildObject, true,
                           new MmMetadataBlock(MmLevelFilter.Child));
        }
    }*/
}
