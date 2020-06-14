using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCommand : ICommand
{
    private Transform _player;
    private float _speed;

    public LeftCommand(Transform player, float speed) {
        _player = player;
        _speed = speed;
    }

    public void Execute() {
        _player.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void Undo() {
        _player.Translate(Vector3.right * _speed * Time.deltaTime);
    }

}
