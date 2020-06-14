using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPlayer : MonoBehaviour
{

    void Update() {
        
        if(Input.GetMouseButtonDown(0)) {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo)) {
                if(hitInfo.collider.tag == "Cube") {
                    ICommand leftClickCommand = new LeftMouseClick(hitInfo.collider.gameObject, new Color(Random.value, Random.value, Random.value));
                    leftClickCommand.Execute();
                    CubesGameManager.Instance.AddCommand(leftClickCommand);
                }
            }
        }

    }
}
