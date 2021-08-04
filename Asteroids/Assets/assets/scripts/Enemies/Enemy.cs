using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DistanceChecker distanceChecker;
    public RotateTowards rotateTowards;
    public ShootAtTarget shootAtTarget;
    public Animator animator;
    public MeteorPooler meteorPooler;
    public string projectilePrefab;
    public Transform projectileSpawn;
    public Transform enemyPos;
    public Rigidbody2D enemyRb;
    public Transform target;
    public float shootIntervall = 1f;
    public bool targetSelected = false;
    public float attackRadius = 0f;
    public bool inRange = false;
}
