using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _canonPrefab;
    [SerializeField]
    private float mouseSensitivity = 100f;
    public float roadWidth;

    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        float mid = screenBounds.x/2;
        roadWidth = mid / 2;
        
        Debug.Log(screenBounds);
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        objectWidth = transform.GetComponent<MeshRenderer>().bounds.size.x; //extents = size of width / 2
        Debug.Log(objectWidth);
        objectHeight = transform.GetComponent<MeshRenderer>().bounds.size.y; //extents = size of height / 2
        Debug.Log(objectHeight);
    }

    
    void Update()
    {
       PlayerMovement();
       if(Input.GetMouseButtonDown(0))
        {
            Instantiate(_canonPrefab, transform.position, Quaternion.identity);
        }
       

    }

    

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * mouseSensitivity /* Time.deltaTime*/ ;
        float verticalInput = Input.GetAxis("Mouse Y") * mouseSensitivity;// * Time.deltaTime;

        Vector3 playerDirection = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(playerDirection * _speed * Time.deltaTime);
        //if (transform.position.x >= 9.2f)
        //{
        //    transform.position = new Vector3(9.2f, transform.position.y, 0);
        //}
        //else if (transform.position.x <= -9.2f)
        //{
        //    transform.position = new Vector3(-9.2f, transform.position.y, 0);
        //}
        //if (transform.position.y >= 4.9f)
        //{
        //    transform.position = new Vector3(transform.position.x, 4.9f, 0);
        //}
        //else if (transform.position.y <= -4.9f)
        //{
        //    transform.position = new Vector3(transform.position.x, -4.9f, 0);
        //}
    }
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x - roadWidth) + objectWidth, (screenBounds.x - roadWidth) * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        Debug.Log(screenBounds.x -roadWidth);
        transform.position = viewPos;
    }
}
