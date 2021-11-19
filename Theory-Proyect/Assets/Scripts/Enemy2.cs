using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AgresiveAction());
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    public override IEnumerator AgresiveAction()
    {
        yield return new WaitForSeconds(3);
        transform.localScale -= new Vector3(0, 0.5f, 0);

    }

}
