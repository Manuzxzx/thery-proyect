using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float verticalInput;
    private float horizontalINput;
    protected float speed = 5;
    protected Vector3 playerPos;
    protected Vector3 mousePos;
    private float angle;
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        ShieldRotation();
    }
    public void PlayerMovement() 
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalINput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalINput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime,Space.World);
    }
    public void ShieldRotation()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 12.99f;
        playerPos = Camera.main.WorldToScreenPoint(target.position);
        mousePos.x = mousePos.x - playerPos.x;
        mousePos.y = mousePos.y - playerPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

    }
    
}
