using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            Debug.Log("Enter");
        }
    }
}
