using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject[] enemyprefabs;
    int[] enemyhp = { 30, 16, 20, 27, 34, 50 };
    int[] enemystr = { 10, 5, 8, 9, 13, 17};
    int[] enemyspd = { 7, 4, 5, 11, 10, 13};
    int[] enemydef = { 5, 3, 4, 6, 7, 9};

    private void Start()
    {
        
    }
}
