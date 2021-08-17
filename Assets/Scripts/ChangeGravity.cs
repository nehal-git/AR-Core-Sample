using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Physics.gravity = Vector3.ClampMagnitude(-transform.up * 9.8f,9.8f);
    }
}
