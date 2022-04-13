using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public float forceJump;
    private Text score;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Doodle.instance.DoodleRigid.velocity = Vector2.up * forceJump;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        var TextList = GameObject.FindGameObjectsWithTag("TextTag").ToList();
        score = TextList[0].GetComponent<Text>();

        if (collision.collider.name == "DeadZone")
        {
            if (gameObject.tag != "PTND" && int.Parse(score.text.ToString()) % 20 == 0)
            {
                Destroy(gameObject);
            }
            float RandX = Random.Range(-2f, 2f);
            float Randy = transform.position.y + 20.8f;

            transform.position = new Vector3(RandX, Randy, 0);
        }
    }
}
