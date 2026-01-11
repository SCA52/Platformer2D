using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    }

    private void Update()
    {
        StartCoroutine(TurnOn());
        
    }
    private IEnumerator TurnOn()
    {
        Debug.Log("Green");
        yield return new WaitForSeconds(1f);
        Debug.Log("Yellow");
        yield return new WaitForSeconds(1f);
        Debug.Log("Red");
    }
}
