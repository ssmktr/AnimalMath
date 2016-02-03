using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

	public const int MAX_HEART = 20;
	public const int MAX_GOLD = 99999;
	public const int MAX_DP = 99999;
	public const int MAX_HEARTTIME = 60 * 5;

	public static Transform FindChild(Transform Root, string TargetName) {
		Transform[] arrTran = Root.GetComponentsInChildren<Transform>();
		for (int i = 0; i < arrTran.Length; ++i) {
			if (TargetName == arrTran[i].name) {
				return arrTran[i];
			}
		}
		return null;
	}

	public static List<EventDelegate> SetBtn(Transform Root, string TargetName, string Method, MonoBehaviour Target) {
		List<EventDelegate> list = new List<EventDelegate>();
		EventDelegate dele = new EventDelegate();
		dele.target = Target;
		dele.methodName = Method;
		list.Add(dele);
		EventDelegate.Parameter param = dele.parameters[0];
		param.obj = FindChild(Root, TargetName).gameObject;
		FindChild(Root, TargetName).gameObject.GetComponent<UIEventTrigger>().onClick = list;
		return list;
	}
	public static List<EventDelegate> SetOnClick(MonoBehaviour Target, string Method, GameObject obj) {
		List<EventDelegate> list = new List<EventDelegate>();
		EventDelegate dele = new EventDelegate();
		dele.target = Target;
		dele.methodName = Method;
		list.Add(dele);
		EventDelegate.Parameter param = dele.parameters[0];
		param.obj = obj;
		return list;
	}

	public static string GetUniqueID() {
		string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#";
		string ticks = DateTime.UtcNow.Ticks.ToString();
		var code = "";
		for (var i = 0; i < characters.Length; i += 2) {
			if ((i + 2) <= ticks.Length) {
				var number = int.Parse(ticks.Substring(i, 2));
				if (number > characters.Length - 1) {
					var one = double.Parse(number.ToString().Substring(0, 1));
					var two = double.Parse(number.ToString().Substring(1, 1));
					code += characters[Convert.ToInt32(one)];
					code += characters[Convert.ToInt32(two)];
				} else
					code += characters[number];
			}
		}
		return code;
	}
}
