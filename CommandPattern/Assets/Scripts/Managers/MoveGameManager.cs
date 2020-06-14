using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveGameManager : MonoSingleton<MoveGameManager>
{
    private List<ICommand> _commandBuffer = new List<ICommand>();

    public void AddCommand(ICommand command) {
        _commandBuffer.Add(command);
    }

    public void Play() {
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine() {

        foreach (var command in _commandBuffer) {
            command.Execute();
            yield return new WaitForSeconds(0f);
        }
    }

    public void Rewind() {
        StartCoroutine(RewindRoutine());
    }

    private IEnumerator RewindRoutine() {
        foreach (var command in Enumerable.Reverse(_commandBuffer)) {
            command.Undo();
            yield return new WaitForSeconds(0f);
        }
    }

    public void Clear() {
        StopAllCoroutines();
        _commandBuffer.Clear();        
        GameObject go = GameObject.Find("Cube");
        go.transform.position = Vector3.zero;
    }


}
