using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform doodlePosition;
    void Update()
    {
        if (doodlePosition.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, doodlePosition.position.y, -10);
        }
    }
}
