using System.Collections;
using System.Collections.Generic;
using HomeWork.GameInput;
using HomeWork.GameSystem;
using UnityEngine;

public interface IPathFinder
{
    /// <summary>
    /// �Y�����|�^�� true�A�óz�L out �ѼƦ^�Ǹ��|�C��C
    /// </summary>
    public bool FindPath(out List<InputDirection> path);

    /// <summary>
    /// �]�w���d���
    /// </summary>
    public void SetData(LevelData levelData);
}
