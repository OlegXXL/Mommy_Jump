using UnityEngine;
using UnityEngine.SceneManagement;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;
    float horizontal;
    public Rigidbody2D DoodleRigid;
    [SerializeField] public AdsCore MyAdwert;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }

        if (Input.acceleration.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.acceleration.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        DoodleRigid.velocity = new Vector3(Input.acceleration.x * 10f, DoodleRigid.velocity.y, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            MyAdwert.ShowSkipVideo();
            SceneManager.LoadScene(0);
        }
    }
}
