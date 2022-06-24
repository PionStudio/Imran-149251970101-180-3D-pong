using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWallController : MonoBehaviour
{
    BallManager ballManager;
    [SerializeField]private PlayerNumber playerNum;

    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        ballManager = BallManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !playerDead)
        {
            Destroy(collision.gameObject);
            ballManager.MinusBallCount();
            ScoreManager.Instance.AddScore(playerNum);
        }
    }
}
