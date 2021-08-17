using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    bool objectFound;
    bool findingDirection;
    GameObject dest;
    public Text dist;
    

    void Start()
    {
        StartCoroutine(routine());
    }

    IEnumerator routine() {
        yield return new WaitUntil(()=> GameObject.FindGameObjectWithTag("spawn"));
        dest = GameObject.FindGameObjectWithTag("spawn").gameObject;
        objectFound = true;
        yield return new WaitUntil(()=> objectFound);
        findingDirection = true;
    
    
    }
    // Update is called once per frame
    void Update()
    {
        if (findingDirection)
        {

            float distance = Vector3.Distance( transform.position,dest.transform.position);
            Debug.Log(distance);
            dist.text ="Distance from camera: "+ distance.ToString("0.00");
        
        }
        
    }
}
