using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class movement : Agent
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

    public override void CollectObservations(VectorSensor sensor)
    {       
            Vector3 distance = cube.position - target.position;

            sensor.AddObservation(cube.transform.rotation.z);
            sensor.AddObservation(cube.transform.rotation.x);
            sensor.AddObservation(cube.transform.rotation.y);
            sensor.AddObservation(distance.x);
            sensor.AddObservation(distance.y);
            sensor.AddObservation(distance.z);
            sensor.AddObservation(rb.velocity.x);
            sensor.AddObservation(rb.velocity.y);
            sensor.AddObservation(rb.velocity.z);
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





    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actionZ = 2f * Mathf.Clamp(actionBuffers.DiscreteActions[0], -1f, 1f);
        var actionX = 2f * Mathf.Clamp(actionBuffers.DiscreteActions[1], -1f, 1f);


        float w = actionBuffers.DiscreteActions[0];
        float a = actionBuffers.DiscreteActions[1];
        float s = actionBuffers.DiscreteActions[2];
        float d = actionBuffers.DiscreteActions[3];
        float space = actionBuffers.DiscreteActions[4];

        Vector3 direction = new Vector3(0.0f,0.0f,0.0f);

        print(w);


        if (space >= .5)
        {
            print("space key was pressed");
            direction.y = force;
        }
        
        if (a >= .5)
        {   
            direction.x = -force;
            print("a key was pressed");
        }
        if (d >= .5)
        {   
            direction.x = force;
            print("d key was pressed");
        }


        if (w >= .5)
        {   
            direction.z = force;
            print("w key was pressed");
        }
        if (s >= .5)
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
