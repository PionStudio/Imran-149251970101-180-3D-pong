using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region Singleton
    public static BallManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private GameObject[] ballSpawnPos;
    [SerializeField] private GameObject ball;
    [SerializeField] private int maxBall;
    [SerializeField] private float spawnTimer;
    private float spawnCounter;

    private int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter += Time.deltaTime;

        if (ballCount < maxBall)
        {
            if (spawnCounter >= spawnTimer)
            {
                spawnCounter = 0f;

                int randomInt = Random.Range(0, ballSpawnPos.Length);
                GameObject spawnedBall = Instantiate(ball, ballSpawnPos[randomInt].transform.position, Quaternion.identity);
                spawnedBall.transform.SetParent(ballSpawnPos[randomInt].transform);
                spawnedBall.transform.localRotation = Quaternion.Euler(Vector3.zero);
                spawnedBall.transform.SetParent(null);

                spawnedBall.GetComponent<Rigidbody>().velocity = ((spawnedBall.transform.forward + new Vector3 (Random.Range(0.3f, 0.5f), 0f, 0f)) 
                                                                + (spawnedBall.transform.right + new Vector3(Random.Range(0.3f, 0.5f), 0f, 0f))) * 10;

                ballCount++;

            }
        }
    }

    public void MinusBallCount()
    {
        ballCount--;
    }
}
