using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed= 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        player = GameObject.Find("Plaayer");
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        Vector3 lookDirection2 = (player.transform.position - transform.position);
        transform.Translate( lookDirection.x * speed * Time.deltaTime,0, lookDirection.z * speed * Time.deltaTime,Space.World);
        float angle = Mathf.Atan2(lookDirection2.z, lookDirection2.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -angle+180, transform.rotation.z+90));
    }
}
