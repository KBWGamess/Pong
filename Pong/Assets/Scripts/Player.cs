using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : Paddle
{
    private Vector2 dir;

    //public Button up;
    //public Button down;

    private void Start()
    {
        dir = Vector2.zero;

        //up.onClick.AddListener(OnUp);
        //down.onClick.AddListener(OnDown);
    }

    private void OnUp()
    {
        dir += Vector2.up;
        Debug.Log(dir);       
    }

    private void OnDown()
    {
        dir += Vector2.down;
        Debug.Log(dir);  
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            dir += Vector2.up;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            dir += Vector2.down;

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            dir -= Vector2.up;
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            dir -= Vector2.down;

        dir = Vector2.ClampMagnitude(dir, 1f);
    } 

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (dir.sqrMagnitude != 0)
        {
            rb.AddForce(dir * this.speed);
        }
    }
}
