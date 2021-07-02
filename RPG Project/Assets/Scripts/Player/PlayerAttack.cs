using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 3.0f;
    Transform enemy;
    PlayerMove playerMove;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        enemy = GameObject.Find("Enemy").transform;
    }

    void Update()
    {
        // 캐릭터 일반공격
        if (Input.GetMouseButtonDown(0))
        {
            playerMove.Point = Vector3.zero;
           
            // 레이를 생성하고 카메라 정면 방향으로 발사하고 싶다.

            // 1. 레이를 생성한다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 2. 레이가 부딪친 대상의 정보를 담을 변수를 선언한다.
            RaycastHit hitinfo;

            // 3. 레이를 발사한다.
            if (Physics.Raycast(ray, out hitinfo))
            {
                // 부딪힌 대상의 이름을 콘솔에 출력한다.
                //print(hitinfo.transform.name);
                    
                if (hitinfo.transform.name.Contains("Enemy"))
                {
                    // 방법1) 부딪힌 대상이 Enemy라면 EnemyFSM 컴포넌트를 가져와서, Damaged 함수를 실행한다.

                    if (Vector3.Distance(enemy.position, transform.position) < attackRange)
                    {
                        // EnemyFSM 컴포넌트를 가져와서, Damaged 함수를 실행한다.
                        EnemyHP efsm = hitinfo.transform.GetComponent<EnemyHP>();
                        efsm.Damaged(attackDamage);
                    }
                }
            }
            
        }
    }
}
