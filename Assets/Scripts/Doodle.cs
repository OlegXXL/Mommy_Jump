using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;
    private float horizontal;
    public Rigidbody2D DoodleRigid;
    public Vector3 ChangeScale;
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject counterPoint;
    [SerializeField] private AdsCore myAds;
    [SerializeField] private Text bestScore;
    private int myBestScore;
    private void Start()
    {
        ChangeScale = transform.localScale;
        if (instance == null)
        {
            instance = this;
        }
        myBestScore = PlayerPrefs.GetInt("BestScore");
        Debug.Log(PlayerPrefs.GetInt("BestScore"));
        bestScore.text = $"Best score: {myBestScore}";
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
        if (-2.8 >= transform.position.x)
            transform.position = new Vector3(2.8f, transform.position.y, 0);
        else if (2.8 <= transform.position.x)
            transform.position = new Vector3(-2.8f, transform.position.y, 0);

        DoodleRigid.velocity = new Vector3(Input.acceleration.x * 10f, DoodleRigid.velocity.y, 0);
    }
    public void StartGame()
    {
        counterPoint.SetActive(true);
        MainUI.SetActive(false);
        DoodleRigid.constraints = RigidbodyConstraints2D.None;
        transform.position += new Vector3(transform.position.x + 0.000001f, transform.position.y, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            if(myBestScore < int.Parse(counterPoint.GetComponent<Text>().text))
            {
                myBestScore = int.Parse(counterPoint.GetComponent<Text>().text);
                PlayerPrefs.SetInt("BestScore", myBestScore);
            }
            myAds.ShowSkipVideo();
            SceneManager.LoadScene(0);
        }
    }
}
