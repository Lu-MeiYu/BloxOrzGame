using System.Collections.Generic;
using RollSample.Spec;
using UnityEngine;

namespace RollSample.Data
{
	public class TestInputData
	{
		#region Map
		private static List<Vector2> _mapA = new List<Vector2>()
		{
			new Vector2(0, 0),new Vector2(0, 1),new Vector2(0, 2),
			new Vector2(1, 0),new Vector2(1, 1),new Vector2(1, 2),
			new Vector2(2, 0),new Vector2(2, 1),new Vector2(2, 2)
		};
		private static List<Vector2> _mapB = new List<Vector2>()
		{
			new Vector2(0, 0),new Vector2(0, 1),new Vector2(0, 2),new Vector2(0, 3),
			new Vector2(1, 0),new Vector2(1, 1),new Vector2(1, 2),new Vector2(1, 3),                    new Vector2(1, 5),new Vector2(1, 6),new Vector2(1, 7),
			new Vector2(2, 0),new Vector2(2, 1),new Vector2(2, 2),new Vector2(2, 3),new Vector2(2, 4),  new Vector2(2, 5),new Vector2(2, 6),new Vector2(2, 7),
			new Vector2(3, 0),new Vector2(3, 1),new Vector2(3, 2),new Vector2(3, 3),                    new Vector2(3, 5),new Vector2(3, 6),new Vector2(3, 7),
			new Vector2(4, 0),new Vector2(4, 1),new Vector2(4, 2),new Vector2(4, 3)
		};
		private static List<Vector2> _mapC = new List<Vector2>()
		{
			new Vector2(0, 0),new Vector2(0, 1),new Vector2(0, 2),new Vector2(0, 3),new Vector2(0, 4),
			new Vector2(1, 0),new Vector2(1, 1),new Vector2(1, 2),new Vector2(1, 3),new Vector2(1, 4),
			new Vector2(2, 0),new Vector2(2, 1),new Vector2(2, 2),new Vector2(2, 3),new Vector2(2, 4),
			new Vector2(3, 0),new Vector2(3, 1),new Vector2(3, 2),new Vector2(3, 3),new Vector2(3, 4),
			new Vector2(4, 0),new Vector2(4, 1),new Vector2(4, 2),new Vector2(4, 3),new Vector2(4, 4)
		};
		private static List<Vector2> _mapD = new List<Vector2>()
		{
			new Vector2(0, 0),new Vector2(0, 1),new Vector2(0, 2),new Vector2(0, 3),new Vector2(0, 4),
			new Vector2(1, 0),new Vector2(1, 1),new Vector2(1, 2),                  new Vector2(1, 4),
			new Vector2(2, 0),new Vector2(2, 1),                  new Vector2(2, 3),new Vector2(2, 4),
			new Vector2(3, 0),                  new Vector2(3, 2),new Vector2(3, 3),new Vector2(3, 4),
			new Vector2(4, 0),new Vector2(4, 1),new Vector2(4, 2),new Vector2(4, 3),new Vector2(4, 4)
		};
		#endregion

		#region MapA
		public static InputData GetIn_A_01()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapA;
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(2, 2);

			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
			};
			return inputData;
		}
		public static OutputLog GetOut_A_01()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 1) }, };
			ret.IsClear = false;
			return ret;
		}
		public static InputData GetIn_A_02()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapA;
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(2, 2);

			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
			};
			return inputData;
		}
		public static OutputLog GetOut_A_02()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(1, 1) }, new List<Vector2> { new Vector2(2, 0), new Vector2(2, 1) }, new List<Vector2> { new Vector2(2, 2) }, };
			ret.IsClear = true;
			return ret;
		}
		#endregion

		#region MapB
		public static InputData GetIn_B_01()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapB;
			inputData.StartPosition = new Vector2(2, 4);
			inputData.EndPosition = new Vector2(2, 6);

			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,//OutOfMap
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,//OutOfMap
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right
			};
			return inputData;
		}
		public static OutputLog GetOut_B_01()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(2, 4) }, new List<Vector2> { new Vector2(2, 2), new Vector2(2, 3) }, new List<Vector2> { new Vector2(1, 2), new Vector2(1, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(3, 1) }, new List<Vector2> { new Vector2(3, 1) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(4, 2), new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 1) }, new List<Vector2> { new Vector2(2, 1), new Vector2(3, 1) }, new List<Vector2> { new Vector2(2, 2), new Vector2(3, 2) }, new List<Vector2> { new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0), new Vector2(1, 1) }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 1), new Vector2(3, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(2, 1), new Vector2(2, 2) }, new List<Vector2> { new Vector2(2, 3) }, new List<Vector2> { new Vector2(2, 4), new Vector2(2, 5) }, new List<Vector2> { new Vector2(2, 6) }, };
			ret.IsClear = true;

			return ret;
		}
		#endregion

		#region MapC
		public static InputData GetIn_C_01()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapC;
			inputData.StartPosition = new Vector2(1, 1);
			inputData.EndPosition = new Vector2(3, 3);
			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
			};
			return inputData;
		}
		public static OutputLog GetOut_C_01()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(1, 1) }, new List<Vector2> { new Vector2(1, 1) }, new List<Vector2> { new Vector2(2, 1), new Vector2(3, 1) }, new List<Vector2> { new Vector2(1, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(1, 3) }, new List<Vector2> { new Vector2(1, 4) }, new List<Vector2> { new Vector2(1, 2), new Vector2(1, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, };
			ret.IsClear = true;
			return ret;
		}
		public static InputData GetIn_C_02()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapC;
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(4, 4);
			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
			};
			return inputData;
		}
		public static OutputLog GetOut_C_02()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(3, 1) }, new List<Vector2> { new Vector2(3, 1) }, new List<Vector2> { new Vector2(3, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(3, 2) }, new List<Vector2> { new Vector2(3, 0), new Vector2(3, 1) }, new List<Vector2> { new Vector2(3, 2) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3), new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 3), new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 3), new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3), new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 2), new Vector2(2, 2) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 1), new Vector2(3, 2) }, new List<Vector2> { new Vector2(2, 1), new Vector2(2, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 1), new Vector2(3, 1) }, new List<Vector2> { new Vector2(2, 2), new Vector2(3, 2) }, new List<Vector2> { new Vector2(2, 3), new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3) }, new List<Vector2> { new Vector2(1, 3) }, new List<Vector2> { new Vector2(2, 3), new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(2, 1), new Vector2(2, 2) }, new List<Vector2> { new Vector2(2, 0) }, new List<Vector2> { new Vector2(2, 1), new Vector2(2, 2) }, new List<Vector2> { new Vector2(3, 1), new Vector2(3, 2) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 1), new Vector2(3, 2) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 3) }, new List<Vector2> { new Vector2(1, 3), new Vector2(2, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 3) }, new List<Vector2> { new Vector2(2, 3), new Vector2(3, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(2, 3), new Vector2(3, 3) }, new List<Vector2> { new Vector2(2, 4), new Vector2(3, 4) }, new List<Vector2> { new Vector2(4, 4) }, };
			ret.IsClear = true;

			return ret;
		}
		#endregion

		#region MapD
		public static InputData GetIn_D_01()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapD;
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(4, 4);

			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
			};
			return inputData;
		}
		public static OutputLog GetOut_D_01()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 3) }, new List<Vector2> { new Vector2(2, 3), new Vector2(3, 3) }, new List<Vector2> { new Vector2(2, 4), new Vector2(3, 4) }, new List<Vector2> { new Vector2(4, 4) }, };
			ret.IsClear = true;

			return ret;
		}
		public static InputData GetIn_D_02()
		{
			InputData inputData = new InputData();
			inputData.MapData = _mapD;
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(4, 4);

			inputData.MoveSteps = new List<MoveDirection>()
			{
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Left,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Down,
				MoveDirection.Left,
				MoveDirection.Right,
				MoveDirection.Left,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Down,
				MoveDirection.Up,
				MoveDirection.Right,
				MoveDirection.Up,
				MoveDirection.Up,
				MoveDirection.Down,
			};
			return inputData;
		}
		public static OutputLog GetOut_D_02()
		{
			OutputLog ret = new OutputLog();
			ret.StepPositions = new List<List<Vector2>> { new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(4, 2), new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 1) }, new List<Vector2> { new Vector2(4, 2), new Vector2(4, 3) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(4, 2), new Vector2(4, 3) }, new List<Vector2> { new Vector2(4, 2), new Vector2(4, 3) }, new List<Vector2> { new Vector2(3, 2), new Vector2(3, 3) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(3, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 1), new Vector2(4, 2) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(4, 0) }, new List<Vector2> { new Vector2(2, 0), new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(1, 4), new Vector2(2, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 4) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 2), new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(0, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(2, 1) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(3, 0) }, new List<Vector2> { new Vector2(1, 0), new Vector2(2, 0) }, new List<Vector2> { new Vector2(0, 0) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 0) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(1, 1), new Vector2(1, 2) }, new List<Vector2> { new Vector2(0, 1), new Vector2(0, 2) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, new List<Vector2> { new Vector2(0, 3) }, };
			ret.IsClear = false;
			return ret;
		}
		#endregion

		public static InputData GetIn_X_XX()
		{
			InputData inputData = new InputData();
			inputData.MapData = new List<Vector2>()
			{
			};
			inputData.StartPosition = new Vector2(0, 0);
			inputData.EndPosition = new Vector2(0, 0);

			inputData.MoveSteps = new List<MoveDirection>()
			{
			};
			return inputData;
		}
		public static OutputLog GetOut_X_XX()
		{
			OutputLog ret = new OutputLog();
			return ret;
		}
	}
}
