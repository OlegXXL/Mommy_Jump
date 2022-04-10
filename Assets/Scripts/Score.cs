using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Transform doodle;
    public int maxScore = 0;

    void Update()
    {
        if (int.Parse(doodle.position.y.ToString("0")) > maxScore)
            maxScore = int.Parse(doodle.position.y.ToString("0"));

        score.text = maxScore.ToString();
    }
}
