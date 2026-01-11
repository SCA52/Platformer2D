using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform patrolPath;
    [SerializeField] private float speed = 5f;
    
    private List<Vector3> patrolPoints = new List<Vector3>();
    private int index = 0;

    private void Awake()
    {
        foreach (Transform child in patrolPath)
        {
            patrolPoints.Add(child.position);
        }
    }
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[index], speed * Time.deltaTime);

        if (transform.position == patrolPoints[index])
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        index = (index + 1) % patrolPoints.Count;
        
        transform.eulerAngles = transform.position.x > patrolPoints[index].x ? new Vector3(0, 180, 0) : Vector3.zero;
    }
}
