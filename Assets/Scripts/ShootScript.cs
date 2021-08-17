using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject sphere;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Shoot()
    {
        GameObject ball = Instantiate(sphere,gameObject.transform);
        ball.transform.SetParent(gameObject.transform.parent.parent);
    
    }

}
