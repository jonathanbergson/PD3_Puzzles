using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    public HingeJoint joint;  
    
    private void OnTriggerEnter(Collider other)
    {
        joint.useSpring = false;
    }

}
