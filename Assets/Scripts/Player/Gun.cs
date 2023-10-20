using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject arrow;
    public Transform shotPoint;
    public Move arrowScore;

    private float TimeBeforeShots;
    public float startTimeShots;

    private void Start()
    {
        arrowScore = FindAnyObjectByType<Move>();
    }
    private void Update()
    {
        Vector3 difference = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        
        if (TimeBeforeShots <= 0 && ScoreAll.ScoreOfArrow > 0)
        {
            if (Input.GetMouseButton(0))
            {
                ScoreAll.ScoreOfArrow--;
                Instantiate(arrow, shotPoint.position, transform.rotation);
                TimeBeforeShots = startTimeShots;
            }
        }
        else
        {
            TimeBeforeShots -= Time.deltaTime;
        }
        
    }

    
}
