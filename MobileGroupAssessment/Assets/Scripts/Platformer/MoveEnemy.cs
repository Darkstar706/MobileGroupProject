﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
            }
            else if (currentWaypoint < waypoints.Length + 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
            }
            else
            {
                Destroy(gameObject);

                //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                // TODO: deduct health
            }
        }
    }
    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        Sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}
