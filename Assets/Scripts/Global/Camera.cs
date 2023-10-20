
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.y = player.position.y;
        temp.x = player.position.x;
        transform.position = temp;

    }
}
