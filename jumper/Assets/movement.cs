using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float force = 100;
    public Transform cube;
    public float bottom_distance;
    public float exaggeration;
    public float reward;
    public Transform target;


    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "target"){
            reward = 1;
        }
    }

    public void CollectObservations(VectorSensor sensor)
    {
            sensor.AddObservation(cube.rotation.z);
            sensor.AddObservation(cube.transform.rotation.x);
            sensor.AddObservation(cube.transform.rotation.y);
            sensor.AddObservation(cube.position - target.position);
            sensor.AddObservation(rb.velocity);
    }   
    // Start is called before the first frame update
    void Start()
    {
        // we dont need this
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0.0f,0.0f,0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            direction.y = force;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {   
            direction.x = -force;
            print("a key was pressed");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {   
            direction.x = force;
            print("d key was pressed");
        }


        if (Input.GetKeyDown(KeyCode.W))
        {   
            direction.z = force;
            print("w key was pressed");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {   
            direction.z = -force;
            print("s key was pressed");
        }



        if (cube.position.y < -10){

            rb.position = new Vector3(0.0f,1.87f,0.0f);
            reward = -exaggeration;
            print(reward);
        }




        rb.AddForce(direction);

        print("reward:"+reward);
        SetReward(reward);
        reward = exaggeration/1000;
        
    }
}
