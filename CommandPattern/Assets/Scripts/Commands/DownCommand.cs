using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownCommand : ICommand {

    private Transform _player;
    private float _speed;

    public DownCommand(Transform player, float speed) {
        _player = player;
        _speed = speed;
    }

    public void Execute() {
        _player.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void Undo() {
        _player.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
