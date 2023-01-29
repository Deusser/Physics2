using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippersScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = -45f;
    public float hitStrenght = 10000f;
    public float flipperDamper = 150f;

    HingeJoint joint;


    void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useSpring = true;
    }


    void Update()
    {
        JointSpring flipperspring = new JointSpring();
        flipperspring.spring = hitStrenght;
        flipperspring.damper = flipperDamper;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            flipperspring.targetPosition = pressedPosition;
        }
        else
        {
            flipperspring.targetPosition = restPosition;
        }
        joint.spring = flipperspring;
        joint.useLimits = true;
    }
}
