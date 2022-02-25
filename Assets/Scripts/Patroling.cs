using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : MonoBehaviour
{
    
    GameObject currentWaypoint;
    GameObject previousWaypoint;
    GameObject[] allWaypoints;

    public float moveSpeed = 10f;

    public float distance;

    public bool isGrounded;

    public float nextWaypointTime;
    public float wpChangeRate = 10f;
    
    

    bool isTravelling;

    private void Awake()
    {
        isGrounded = true;
    }
   
    void Start()
    {

        

        isTravelling = false;

        allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        currentWaypoint = GetRandomWaypoint();

        SetDestination();
        

    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sphere height: " + this.transform.position.y);
        }


        if (Time.time >= nextWaypointTime)
        {
            SetDestination();
            nextWaypointTime = Time.time + 1f / wpChangeRate;

        }
       

        


        Vector3 targetVector = currentWaypoint.transform.position; ;

        distance = Vector3.Distance(this.transform.position, targetVector);

        if (isTravelling && distance <= 1f)
        {
            isTravelling = false;

            SetDestination();

        }
        else
        {
            

            Vector3 movement = Vector3.MoveTowards(this.transform.position, targetVector, moveSpeed * Time.deltaTime);

            transform.position = movement;
        }


    }

    void SetDestination()
    {
        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        

        isTravelling = true;

    }

    public GameObject GetRandomWaypoint()
    {
        if (allWaypoints.Length == 0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
            
        }
    }

}
