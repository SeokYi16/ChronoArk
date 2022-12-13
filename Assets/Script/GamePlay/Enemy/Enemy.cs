using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] enemyprefabs;

    public void All_Dead_Enemy()
    {
        Destroy(gameObject);
    }
}
