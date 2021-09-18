using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string objectTag;
    public Animator animator;
    public MeteorPooler meteorPooler;
    public string projectilePrefab;
    public Transform projectileSpawn;
    public Transform enemyPos;
    public Rigidbody2D enemyRb;
    public Transform target;
    public bool targetSelected = false;
    public bool inRange = false;
    public int points;
}
