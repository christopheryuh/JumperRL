using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{   

    public Rigidbody rb;

    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "player"){
            int x = Random.Range(-5,5);
            int y = Random.Range(1,5);
            int z = Random.Range(-5,5);

            rb.position = new Vector3(x,y,z);        
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(-5,5);
            int y = Random.Range(1,5);
            int z = Random.Range(-5,5);

            rb.position = new Vector3(x,y,z);  
    }

}
