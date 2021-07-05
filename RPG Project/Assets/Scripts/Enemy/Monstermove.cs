using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstermove : MonoBehaviour
{
    public enum eMonsterState 
    {
        idle,
        chase,
        attack,
        attacked,
        death
    }

    
    
    public GameObject target;

    public eMonsterState state;

    void Start()
    {
       state = eMonsterState.idle;

        target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void Update()
    {
      
        switch (state)
        {
            case eMonsterState.idle:
                Idle();
                break;
            case eMonsterState.chase:
                Chase();
                break;
            case eMonsterState.attack:
                Attack();
                break;
            case eMonsterState.attacked:
                Attacked();
                break;
            case eMonsterState.death:
                Death();
                break;
            default:
                break;
        }
    }

    //대기상태일떄 우리가 업제이트에서 홰야할것 
    public float findDistance = 5;
    
    public void Idle() 
    {
        //플레이어가 감지거리안에 들어오면 chase로 전이하고 싶다.
        // 1.나와 target의 거리를 구해서
        float distance = Vector3.Distance(transform.position, target.transform.position);
       // 2.만약 그 거리가 감지거리보다 작으면
       if(distance < findDistance)
        {
            // 3.Move상태로 전이하고 싶다
            state = eMonsterState.chase;
        }
        
    }
    // 추적 상태일 때 업데이트에서 해야 될 것.
    public float moveSpeed = 1.0f;
    public float attackDistance = 1.0f;
    public void Chase()
    {
        //플레이어 방향으로 이동하다가 플레이어가 공격범위 안으로 들어오면 attack으로 전이하고 싶다
        // 1.target 방향으로 이동하고 싶다
        Vector3 targetPostion = target.transform.position - transform.position;
        targetPostion.Normalize();
        transform.position += targetPostion * moveSpeed * Time.deltaTime;

        // 2.나와 target사이의 거리를 구해서
        float distance = Vector3.Distance(transform.position, target.transform.position);

        // 3.만약 그 거리가 공격거리보다 작으면
       if (distance < attackDistance)
        {
            // 4.attack상태로 전이하고 싶다
            state = eMonsterState.attack;
        }

    }
    float currentTime;
    float attackTime = 1;
    public void Attack()
    {
        // 일정시간마다 공격을 하되 공격시점에 target이 공격거리 밖에 있으면 Move 상태로 전이하고싶다 그렇지않으면 계속 반복공격!
        // 1.시간이 흐르다가
        currentTime = Time.deltaTime;
        // 2.현재시간이 공격시간이 되면
        if(currentTime > attackTime) 
        {
            // 3.현재시간을 초기화하고
            currentTime = 0;
            // 4.플레이어를 공격하고
            //target.AddDamage();

            // 5.나와 target사이의 거리를 구해서
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // 6.만약 그 거리가 공격거리보다 크면
            if (distance > attackDistance)
            {
                // 7.move상태로 전이하고 싶다
                state = eMonsterState.chase;
            }
            

        }

    }

    public void Attacked()
    {
        //플레이어에게 공격 받았을 때 데미지를 표현하고,hp가 0이 되었을 때 death로 전이하고 싶다
    }

    public void Death()
    {
        //HP가 0이 되었을 때 몬스터를 사라지게 하고 싶다
    }
}
