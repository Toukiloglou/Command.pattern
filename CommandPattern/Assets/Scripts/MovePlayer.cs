using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2.0f;

    private ICommand moveUp, moveDown, moveLeft, moveRight;


    void Update() {

        if(Input.GetKey(KeyCode.UpArrow)) {
            moveUp = new UpCommand(this.transform, _speed);
            moveUp.Execute();
            MoveGameManager.Instance.AddCommand(moveUp);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            moveDown = new DownCommand(this.transform, _speed);
            moveDown.Execute();
            MoveGameManager.Instance.AddCommand(moveDown);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            moveLeft = new LeftCommand(this.transform, _speed);
            moveLeft.Execute();
            MoveGameManager.Instance.AddCommand(moveLeft);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            moveRight = new RightCommand(this.transform, _speed);
            moveRight.Execute();
            MoveGameManager.Instance.AddCommand(moveRight);
        }

    }
}
