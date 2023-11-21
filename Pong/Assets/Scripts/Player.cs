using UnityEngine;

public class Player : Paddle
{
    private Vector2 dir;
    public Camera cam;

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
        #region Управление одним пальцем (Выкл)
        if (false)
        {
            dir += Input.GetMouseButton(0) ? Vector2.up : Vector2.down;
        }
        #endregion
        #region Управление касанием
        if (Input.GetMouseButton(0))
        {
            dir += Input.mousePosition.y < (Screen.height / 2) ? Vector2.down : Vector2.up;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dir = Vector2.zero;
        }
        #endregion

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
