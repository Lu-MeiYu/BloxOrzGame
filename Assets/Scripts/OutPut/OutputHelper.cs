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
        /// 根據輸入資料執行 GameLogic，產生每一步的方塊位置與過關結果。
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
        /// 驗證實際執行結果與預期 OutputLog 是否一致，並把比對結果輸出到 Console。
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
                        Debug.Log($"步數 {i}，格子 {j}：符合 ({actualRow[j]})");
                    }
                    else
                    {
                        Debug.LogError($"步數 {i}，格子 {j}：不符，預期 {expectedRow[j]}，實際 {actualRow[j]}");
                    }
                }
            }

            if (actual.IsClear == expectedLog.IsClear)
            {
                Debug.Log("通關結果符合預期");
            }
            else
            {
                Debug.LogError($"通關結果不符，預期 {expectedLog.IsClear}，實際 {actual.IsClear}");
            }
        }

        /// <summary>
        /// 將 MoveDirection 轉換成對應的 InputDirection（依原始邏輯對應關係）。
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
