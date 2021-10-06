using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TargetBox : MonoBehaviour
{
    //InputField iField;
    [SerializeField]
    private GameObject _targetPrefab;

    void Start()
    {
        int numberOfRows = UserInputField.targetBoxes.targetUserInput;
        //_targetPrefab= gameObject;
        //transform.position = new Vector3(0, 6, 4);

        Vector3 targetBoxPos = new Vector3(0,numberOfRows-1,4);
       
        Debug.Log(numberOfRows);
        for(int row= 1; row <= numberOfRows; row++)
        {
            for(int column= 0; column < (row*2-1); column++)
            {
                Vector3 newPos = new Vector3((targetBoxPos.x + column),targetBoxPos.y, targetBoxPos.z);
                Instantiate(_targetPrefab, newPos, Quaternion.identity);
            }
            targetBoxPos = new Vector3(targetBoxPos.x-1, targetBoxPos.y-1, targetBoxPos.z);
        }
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    Vector3 targetBoxPos = new Vector3();
    //    targetBoxPos = transform.position;
    //    targetBoxPos.y += transform.pos

    //    //Instantiate(_targetPrefab);

    //}
}
