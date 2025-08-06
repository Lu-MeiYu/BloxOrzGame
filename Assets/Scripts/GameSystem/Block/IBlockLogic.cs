using System.Collections.Generic;
using UnityEngine;
using HomeWork.GameInput;
namespace HomeWork.GameSystem
{
    public interface IBlockLogic
    {
        /// <summary>
        /// ����@������
        /// </summary>
        public void Move(InputDirection direcion);

        /// <summary>
        /// �w���V���w��V���ʫ�A����|���Ϊ��Ҧ���l�y��(�ѥ��ܥk�A�U�ܤW�ƦC)�A�ΤU�Ӫ��A�C
        /// </summary>
        public List<Vector2> CaculateMove(InputDirection direcion,out BlockState state);

        /// <summary>
        /// ���o�����e�Ҧ���l�y��(�ѥ��ܥk�A�U�ܤW�ƦC)�C
        /// </summary>

        public List<Vector2> GetCurrentPosition();

        /// <summary>
        /// ���o�����e���A
        /// </summary>
        public BlockState GetBlockState();

        /// <summary>
        /// �H���w����m�P���A�A��s������u����ή�l�y�СC
        /// </summary>
        /// <param name="anchor">���߮ɬ������m�F���U�ɬ����ΤU�ݮ�l�y�СC</param>
        public void SetState(Vector2 leftOrDownPoint, BlockState blockState);
    }
}
