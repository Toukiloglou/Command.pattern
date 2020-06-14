using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMouseClick : ICommand {

    private GameObject _go;
    private Color _color;
    private Color _previousColor;

    public LeftMouseClick(GameObject go, Color color) {
        _go = go;
        _color = color;
    }

    public void Execute() {
        _previousColor = _go.GetComponent<MeshRenderer>().material.color;
        _go.GetComponent<MeshRenderer>().material.color = _color;
    }

    public void Undo() {
        _go.GetComponent<MeshRenderer>().material.color = _previousColor;
    }
}
