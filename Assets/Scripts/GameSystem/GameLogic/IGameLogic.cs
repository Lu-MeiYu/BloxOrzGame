using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
using System;
namespace HomeWork.GameSystem
{
    public interface IGameLogic
    {
        /// <summary>
        /// �]�m���d�C
        /// </summary>
        /// <param name="levelData">���d��ƪ���</param>
        public void SetGame(LevelData levelData);

        /// <summary>
        /// �ˬd�O�_�L���C
        /// </summary>
        /// <returns>�Y�w���߯��b���I�^�� true�A�_�h false</returns>
        public bool IsWin();

        /// <summary>
        /// �P�_�V���w��V���ʫ�A�Ҧ��U�@�B��l�O�_���O�X�k���C
        /// </summary>
        /// <param name="direction">���ˬd�����ʤ�V</param>
        /// <returns>�X�k�^�� true�A�_�h false</returns>
        public bool IsValidMove(InputDirection direction);

        /// <summary>
        /// ����@�����ʰʧ@
        /// </summary>
        /// <param name="direction">���ʤ�V</param>
        public void MoveBlock(InputDirection inputDirection);

        /// <summary>
        /// ���o��e������A�P���ή�l�y�СC
        /// </summary>
        /// <param name="blockState">��X�G��e������A</param>
        /// <returns>������Ϊ��Ҧ���l�y�вM��</returns>
        public List<Vector2> GetBlockState(out BlockState blockState);

    }
}
