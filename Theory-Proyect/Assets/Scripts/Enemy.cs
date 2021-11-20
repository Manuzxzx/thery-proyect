using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected GameObject gameManager;
    protected float speed= 2;
    protected Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        StartCoroutine(AgresiveAction());
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        EndGame();
    }
    public void FollowPlayer()
    {
        player = GameObject.Find("Plaayer");
        lookDirection = (player.transform.position - transform.position).normalized;
        Vector3 lookDirection2 = (player.transform.position - transform.position);
        transform.Translate( lookDirection.x * speed * Time.deltaTime,0, lookDirection.z * speed * Time.deltaTime,Space.World);
        float angle = Mathf.Atan2(lookDirection2.z, lookDirection2.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -angle+180, transform.rotation.z+90));
    }
    public virtual IEnumerator AgresiveAction()
    {

        yield return new WaitForSeconds(2);
        speed = 7;
    }
    protected void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Escudo"))
        {
            Destroy(gameObject);
            gameManager.gameObject.GetComponent<GameManager>().score += 1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
           
            gameManager.gameObject.GetComponent<GameManager>().gameOver = true;
        }

    }
    public void EndGame()
    {
        if (gameManager.gameObject.GetComponent<GameManager>().gameOver)
        {
            Destroy(gameObject);
        }
    }

}
