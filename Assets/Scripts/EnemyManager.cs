using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    // UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    Rigidbody rb;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // agent.destination = target.position;
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // agent.destination = target.position;




    }

    public void FixedUpdate() {
        Vector3 ePos = transform.position;  // 自分(敵キャラクタ)の世界座標
        Vector3 pPos = target.position;  // プレイヤーの世界座標
        // プレイヤーの方向に動くベクトル(move_speedで速度を調整)
        Vector3 force = (pPos - ePos) * moveSpeed;
        // じわじわ追跡
        rb.velocity = force;
    }
    
}
