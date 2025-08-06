using System;
using System.Collections.Generic;
using HomeWork.GameInput;
using HomeWork.GameSystem;
using UnityEngine;

/// <summary>
/// 使用 BFS 演算法，基於 IGameLogic 與 IBlockLogic 計算從起點到終點的最短路徑。
/// </summary>
public class BFSPathFinder :
    IPathFinder
{
    /// <summary>
    /// 記錄每個節點的前驅節點與從前驅節點通過哪個方向到達它。
    /// </summary>
    private struct NodeInfo
    {
        public Node Previous { get; }
        public InputDirection Direction { get; }

        public NodeInfo(Node previous, InputDirection direction)
        {
            Previous = previous;
            Direction = direction;
        }
    }

    /// <summary>
    /// 用於 BFS 的節點：包含方塊狀態與代表位置
    /// 。</summary>
    private struct Node
    {
        public BlockState State { get; }
        public Vector2 Position { get; }

        public Node(Vector2 position,BlockState state)
        {
            State = state;
            Position = position;
        }
    }

    private readonly IGameLogic _gameLogic;
    private readonly IBlockLogic _blockLogic;

    public BFSPathFinder(IGameLogic gameLogic, IBlockLogic blockLogic)
    {
        _gameLogic = gameLogic;
        _blockLogic = blockLogic;
    }

    public void SetData(LevelData levelData)
    {
        _gameLogic.SetGame(levelData);
    }

    public bool FindPath(out List<InputDirection> path)
    {
        var visited = new Dictionary<Node, NodeInfo>();
        var queue = new Queue<Node>();

        Vector2 position = _gameLogic.GetBlockState(out BlockState blockState)[0];
        var start = new Node(position, blockState);
        visited[start] = new NodeInfo(previous: default, direction: default);
        queue.Enqueue(start);
        Node goal = default;
        bool found = false;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            _blockLogic.SetState(current.Position, current.State);
            if (_gameLogic.IsWin())
            {
                goal = current;
                found = true;
                break;
            }

            foreach (InputDirection dir in Enum.GetValues(typeof(InputDirection)))
            {
                if (!_gameLogic.IsValidMove(dir))
                {
                    continue;
                }

                var next = SimulateMove(dir);
                if (visited.ContainsKey(next))
                {
                    continue;
                }

                visited[next] = new NodeInfo(current, dir);
                queue.Enqueue(next);
            }
        }

        if (!found)
        {
            path = new List<InputDirection>();
            return false;
        }

        path = ReconstructPath(visited, start, goal);
        return true;
    }
    private List<InputDirection> ReconstructPath(Dictionary<Node, NodeInfo> visited, Node start, Node goal)
    {
        var path = new List<InputDirection>();
        var current = goal;

        while (!current.Equals(start))
        {
            var info = visited[current];
            path.Add(info.Direction);
            current = info.Previous;
        }

        path.Reverse();
        return path;
    }
    private Node SimulateMove(InputDirection direction)
    {
        var positions = _blockLogic.CaculateMove(direction, out BlockState nextState);
        return new Node(positions[0], nextState);
    }
}
