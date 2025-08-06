using System.Collections.Generic;
using UnityEngine;
using RollSample.Spec;
using HomeWork.GameSystem;
using HomeWork.GameInput;
using System;
namespace HomeWork.Output
{
    public class OutputHelper
    {
        /// <summary>
        /// �ھڿ�J��ư��� GameLogic�A���ͨC�@�B�������m�P�L�����G�C
        /// </summary>
        public static OutputLog GenerateOutput(InputData inputData)
        {
            var levelData = ScriptableObject.CreateInstance<LevelData>();
            levelData.StartPoint = inputData.StartPosition;
            levelData.EndPoint = inputData.EndPosition;
            levelData.Tiles = inputData.MapData;

            IBlockLogic blockLogic = new CuboidBlock();
            IGameLogic gameLogic = new GameLogic(blockLogic);
            gameLogic.SetGame(levelData);

            var outputLog = new OutputLog
            {
                StepPositions = new List<List<Vector2>>
            {
                new List<Vector2> { gameLogic.GetBlockState(out BlockState _)[0] }
            },
                IsClear = false
            };

            foreach (var dir in inputData.MoveSteps)
            {
                var inputDir = Map(dir);

                if (gameLogic.IsValidMove(inputDir))
                {
                    gameLogic.MoveBlock(inputDir);

                    var positions = gameLogic.GetBlockState(out BlockState blockState);

                    outputLog.StepPositions.Add(
                        blockState == BlockState.Stand
                            ? new List<Vector2> { positions[0] }
                            : new List<Vector2>(positions)
                    );

                }
                else 
                {
                    var positions = gameLogic.GetBlockState(out BlockState blockState);

                    outputLog.StepPositions.Add(
                        blockState == BlockState.Stand
                            ? new List<Vector2> { positions[0] }
                            : new List<Vector2>(positions)
                    );

                }
                if (gameLogic.IsWin())
                {
                    outputLog.IsClear = true;
                }
            }

            return outputLog;
        }

        /// <summary>
        /// ���ҹ�ڰ��浲�G�P�w�� OutputLog �O�_�@�P�A�ç��ﵲ�G��X�� Console�C
        /// </summary>
        public static void ValidateOutput(InputData inputData, OutputLog expectedLog)
        {
            var actual = GenerateOutput(inputData);
            int steps = Math.Min(actual.StepPositions.Count, expectedLog.StepPositions.Count);

            for (int i = 0; i < steps; i++)
            {
                var actualRow = actual.StepPositions[i];
                var expectedRow = expectedLog.StepPositions[i];

                int cols = Math.Min(actualRow.Count, expectedRow.Count);
                for (int j = 0; j < cols; j++)
                {
                    if (actualRow[j] == expectedRow[j])
                    {
                        Debug.Log($"�B�� {i}�A��l {j}�G�ŦX ({actualRow[j]})");
                    }
                    else
                    {
                        Debug.LogError($"�B�� {i}�A��l {j}�G���šA�w�� {expectedRow[j]}�A��� {actualRow[j]}");
                    }
                }
            }

            if (actual.IsClear == expectedLog.IsClear)
            {
                Debug.Log("�q�����G�ŦX�w��");
            }
            else
            {
                Debug.LogError($"�q�����G���šA�w�� {expectedLog.IsClear}�A��� {actual.IsClear}");
            }
        }

        /// <summary>
        /// �N MoveDirection �ഫ�������� InputDirection�]�̭�l�޿�������Y�^�C
        /// </summary>
        private static InputDirection Map(MoveDirection dir) => dir switch
        {
            MoveDirection.Up => InputDirection.Left,
            MoveDirection.Down => InputDirection.Right,
            MoveDirection.Left => InputDirection.Down,
            MoveDirection.Right => InputDirection.Up,
            _=>default
        };
    }
}
