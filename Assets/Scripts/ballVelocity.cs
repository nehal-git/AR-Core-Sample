using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(20f);
        Destroy(this.gameObject);
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

}
