using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class TargetAgent : Agent
{

    public GameObject tagAgent;
    public TrainingDisplay display;
    public float moveSpeed = 1;
    public float detectionDistance = 2;
    public int numDetectors = 8;

    private Rigidbody agentRigidbody;


    private void Awake()
    {
        agentRigidbody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        display.ResetEnvironment();
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 tagVector = tagAgent.transform.position - transform.position;

        sensor.AddObservation(tagVector.x);
        sensor.AddObservation(tagVector.z);

        for (int i = 0; i < numDetectors; i++)
        {
            float angle = 360 / numDetectors * i;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right, out hit, detectionDistance))
            {
                Debug.DrawRay(transform.position, Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right * hit.distance, Color.red);
                sensor.AddObservation(true);
            }
            else
            {
                Debug.DrawRay(transform.position, Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right * detectionDistance, Color.green);
                sensor.AddObservation(false);
            }

        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        agentRigidbody.velocity = new Vector3(vectorAction[0], 0, vectorAction[1]) * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Border")
        {
            display.HitWall();
        }
    }

    private void OnDrawGizmos()
    {
        /*
        Gizmos.color = Color.green;

        for(int i = 0; i < numDetectors; i++)
        {
            float angle = 360 / numDetectors * i;
            Gizmos.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(angle, Vector3.up) * Vector3.right * detectionDistance);
        }
        */
    }


}
