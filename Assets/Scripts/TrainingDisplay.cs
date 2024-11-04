using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TrainingDisplay : MonoBehaviour
{

    public float EvadeTime = 30;
    public TargetAgent targetAgent;
    public GameObject tagAgent;
    public BoxCollider environmentBounds;

    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI TaggedText;
    public TextMeshProUGUI EvadeText;

    private int numTagged;
    private int numEscaped;
    private float timeLeft;


    public void Awake()
    {
        numTagged = 0;
        numEscaped = 0;
        timeLeft = EvadeTime;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            Debug.Log("Escaped!");
            numEscaped += 1;
            targetAgent.SetReward(5f);
            targetAgent.EndEpisode();
        }

        else if (Vector3.Distance(tagAgent.transform.position, targetAgent.transform.position) < 1)
        {
            float reward = GetRewardBasedOnTime();
            Debug.Log("Tagged! Reward: " + reward);
            numTagged += 1;
            targetAgent.SetReward(reward);
            targetAgent.EndEpisode();
        }

        TimeText.text = (int)timeLeft + "s";
        EvadeText.text = "" + numEscaped;
        TaggedText.text = "" + numTagged;
    }

    public float GetRewardBasedOnTime()
    {
        return (0.5f - (timeLeft / EvadeTime)) * 2;
    }

    public void HitWall()
    {
        Debug.Log("Hit Wall!");
        numTagged += 1;
        targetAgent.SetReward(-1f);
        targetAgent.EndEpisode();
    }

    public void ResetEnvironment()
    {
        timeLeft = EvadeTime;

        MoveAgentToRandomLocation(tagAgent);
        MoveAgentToRandomLocation(targetAgent.gameObject);
    }

    public void MoveAgentToRandomLocation(GameObject agent)
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 randPoint = GetRandomPointInBounds();
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randPoint, out hit, 0.5f, NavMesh.AllAreas))
            {
                randPoint.y = 0.5f;
                agent.transform.position = randPoint;
            }
        }
    }

    public Vector3 GetRandomPointInBounds()
    {
        float x = Random.Range(environmentBounds.bounds.min.x, environmentBounds.bounds.max.x);
        float y = Random.Range(environmentBounds.bounds.min.y, environmentBounds.bounds.max.y);
        float z = Random.Range(environmentBounds.bounds.min.z, environmentBounds.bounds.max.z);

        return new Vector3(x, y, z);
    }

    

}
