using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;
    float horizontal;
    public Rigidbody2D DoodleRigid;
    public Vector3 ChangeScale;

    void Start()
    {
        ChangeScale = transform.localScale;
        if (instance == null)
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;

        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }

        if (Input.acceleration.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(-ChangeScale.x, ChangeScale.y, 0);
        }

        if (Input.acceleration.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(ChangeScale.x, ChangeScale.y, 0);
        }

        DoodleRigid.velocity = new Vector3(Input.acceleration.x * 10f, DoodleRigid.velocity.y, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            SceneManager.LoadScene(0);
        }
    }
}
