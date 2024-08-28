using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballz : MonoBehaviour
{
    [SerializeField] private float speeed;
    [SerializeField] private float pitch;
    
    private CharacterController controller;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = speeed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 2 * speeed;

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        
        Vector3 preTransform = new Vector3(x, 0, z);
        //ax + by
        //cx + dy
        float theta = transform.eulerAngles.y * Mathf.Deg2Rad;

        float a = Mathf.Cos(theta) * z - Mathf.Sin(theta) * x;
        float b = Mathf.Sin(theta) * z + Mathf.Cos(theta) * x;

        Vector3 t = new Vector3(b,0,a);

        controller.SimpleMove(t * speed * Time.fixedDeltaTime);
    
        transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X") * pitch * Time.fixedDeltaTime;
    
        transform.eulerAngles -= Vector3.right * Input.GetAxis("Mouse Y") * pitch * Time.fixedDeltaTime;
    }

}
