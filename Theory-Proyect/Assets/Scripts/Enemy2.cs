using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    protected Rigidbody playerRB;
    protected float deltaPull = 4f;
    protected float timePased = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(AgresiveAction());
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EndGame();
    }
    public override IEnumerator AgresiveAction()
    {
        yield return new WaitForSeconds(1);
        
        while (timePased < 20)
        {
            player.transform.position += -lookDirection * deltaPull * Time.deltaTime;
            timePased += 1;
            yield return null;
        }
    }

}
