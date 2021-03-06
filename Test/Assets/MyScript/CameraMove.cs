using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{

    public static CameraMove Instance;

    private Vector3 dirVector3;
    private Vector3 rotaVector3;
    private float paramater = 0.1f;
    //旋转参数
    private float xspeed = -0.05f;
    private float yspeed = 0.1f;


    void Awake()
    {
        Instance = this;
        Cursor.visible = false;
    }

    private void Start()
    {
        rotaVector3 = transform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //旋转
        if (Input.GetMouseButton(1))
        {
            rotaVector3.y += Input.GetAxis("Horizontal") * yspeed;
            rotaVector3.x += Input.GetAxis("Vertical") * xspeed;
            transform.rotation = Quaternion.Euler(rotaVector3);
        }

        //移动
        dirVector3 = Vector3.zero;
        if(Input.GetKey(KeyCode.Space))
        {
            dirVector3.y = 1;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            dirVector3.y = -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.z = 3;
            else dirVector3.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.z = -3;
            else dirVector3.z = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.x = -3;
            else dirVector3.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.x = 3;
            else dirVector3.x = 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.y = -3;
            else dirVector3.y = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.LeftShift)) dirVector3.y = 3;
            else dirVector3.y = 1;
        }
        Instance.transform.Translate(dirVector3 * paramater, Space.Self);
    }
}
