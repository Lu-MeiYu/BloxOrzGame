using HomeWork.GameInput;
using UnityEngine;
using System;

public interface ICuboidView 
{
    /// <summary>
    /// �X�k���ʰʵe���񧹲�����檺�ƥ�
    /// </summary>
    public event Action OnFinishLegalAnimation;

    /// <summary>
    /// �D�k���ʰʵe���񧹲�����檺�ƥ�
    /// </summary>
    public event Action OnFinishIllegalAnimtion;

    /// <summary>
    /// �NCuboid��m���w��m�ê�l�ƪ��A�W
    /// </summary>
    /// <param name="startPointWorldPosition">�_�l��m</param>
    public void Initialize(Vector3 startPointWorldPosition);

    /// <summary>
    /// ����X�k���ʮɪ��ʵe
    /// </summary>
    /// <param name="direction">��J����V</param>
    /// <param name="blockState">��e���A</param>
    public void DisplayLegalMove(InputDirection direction, BlockState blockState);

    /// <summary>
    /// ����D�k���ʮɪ��ʵe
    /// </summary>
    /// <param name="direction">��J����V</param>
    /// <param name="blockState">��e���A</param>
    public void DisplayIllegalMove(InputDirection direction, BlockState blockState);
}
