using System;
using System.Text;
using RollSample.Spec;
using UnityEngine;

namespace RollSample.Data
{
	public static class OutputDataExt
	{
		public static bool CheckIsEqual(this OutputLog outputLog, OutputLog value)
		{
			var CheckLog = new StringBuilder();
			var isEqual = true;
			if (outputLog.IsClear != value.IsClear)
			{
				CheckLog.AppendLine($"IsClear: {outputLog.IsClear} != {value.IsClear}");
				isEqual = false;
			}
			if (outputLog.StepPositions.Count != value.StepPositions.Count)
			{
				CheckLog.AppendLine($"StepPositions.Count: {outputLog.StepPositions.Count} != {value.StepPositions.Count}");
				isEqual = false;
			}
			for (int i = 0; i < Math.Min(outputLog.StepPositions.Count, value.StepPositions.Count); i++)
			{
				if (outputLog.StepPositions[i].Count != value.StepPositions[i].Count)
				{
					CheckLog.AppendLine($"StepPositions[{i}].Count: {outputLog.StepPositions[i].Count} != {value.StepPositions[i].Count}");
					var StepPositions = new StringBuilder();
					StepPositions.Append($"outputLog.StepPositions[{i}]: ");
					for (int j = 0; j < outputLog.StepPositions[i].Count; j++)
					{
						StepPositions.Append($"[{j}]{outputLog.StepPositions[i][j]}, ");
					}
					CheckLog.AppendLine(StepPositions.ToString());
					StepPositions.Clear();
					StepPositions.Append($"value.StepPositions[{i}]: ");
					for (int j = 0; j < value.StepPositions[i].Count; j++)
					{
						StepPositions.Append($"[{j}]{value.StepPositions[i][j]}, ");
					}
					CheckLog.AppendLine(StepPositions.ToString());

					isEqual = false;
				}
				if (outputLog.StepPositions[i].Count == 1)
				{
					if (outputLog.StepPositions[i][0] != value.StepPositions[i][0])
					{
						CheckLog.AppendLine($"StepPositions[{i}][0]: {outputLog.StepPositions[i][0]} != {value.StepPositions[i][0]}");
						isEqual = false;
					}
				}
				else if (outputLog.StepPositions[i].Count == 2)
				{
					if (value.StepPositions[i].Count == 2)
					{
						if (outputLog.StepPositions[i][0] != value.StepPositions[i][0] &&
						outputLog.StepPositions[i][0] != value.StepPositions[i][1])
						{
							CheckLog.AppendLine($"StepPositions[{i}][0]: {outputLog.StepPositions[i][0]} != {value.StepPositions[i][0]}||{value.StepPositions[i][1]}");
							isEqual = false;
						}
						if (outputLog.StepPositions[i][1] != value.StepPositions[i][0] &&
							outputLog.StepPositions[i][1] != value.StepPositions[i][1])
						{
							CheckLog.AppendLine($"StepPositions[{i}][1]: {outputLog.StepPositions[i][1]} != {value.StepPositions[i][0]}||{value.StepPositions[i][1]}");
							isEqual = false;
						}
					}
				}
			}
			if (!isEqual)
			{
				Debug.LogError(CheckLog.ToString());
			}
			return isEqual;
		}
	}
}
