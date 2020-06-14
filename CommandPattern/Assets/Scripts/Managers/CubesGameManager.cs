using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CubesGameManager : MonoSingleton<CubesGameManager> {

    private List<ICommand> _commandBuffer = new List<ICommand>();

    public CubesGameManager() {
    }

    public void AddCommand(ICommand command) {
        _commandBuffer.Add(command);
    }

    public void Play() {
        StartCoroutine(PlayRoutine());
    }

    IEnumerator PlayRoutine() {
        foreach (var command in _commandBuffer) {
            command.Execute();
            yield return new WaitForSeconds(1);
        }        
    }

    public void Rewind() {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine() {
        foreach (var command in Enumerable.Reverse(_commandBuffer)) {
            command.Undo();
            yield return new WaitForSeconds(1);
        }
    }

    public void Done() {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes) {
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    public void Clear() {
        _commandBuffer.Clear();
    }

}
