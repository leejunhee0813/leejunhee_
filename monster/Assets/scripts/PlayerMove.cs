using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        //dashspeed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 상하 좌우 입력 값을 받아온다.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float moveSpeed = 5.0f;

        // 받은 입력값을 방향 값으로 만들고 싶다.
        Vector3 direction = new Vector3(h, v, 0);
        direction.Normalize();
        // 만일 좌측 shift 버튼을 누르면...
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //스피드를 두배로
            moveSpeed = moveSpeed * 2;
        }
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //스피드를 두배로
        //dashspeed = moveSpeed * 2;
        // }
        //그렇지 않고, 좌측 Shift 버튼을 떼면...
        // else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //moveSpeed = moveSpeed;
        //}
        print(moveSpeed);
        //그 방향으로 이동을 하겠다
        //p=p0+vt
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.position += direction * dashSpeed * Time.deltaTime;



    }
}