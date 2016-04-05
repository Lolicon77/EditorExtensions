using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EditorExtension {
	public class HierarchyPopMenu {
		[MenuItem("Window/Test/yusong")]
		private static void Test() {
		}

		[MenuItem("Window/Test/momo")]
		private static void Test1() {
		}

		[MenuItem("Window/Test/雨松/MOMO")]
		private static void Test2() {
		}


		[InitializeOnLoadMethod]
		private static void StartInitializeOnLoadMethod() {
			EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
		}

		private static void OnHierarchyGUI(int instanceID, Rect selectionRect) {
			if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
				&& Event.current.button == 1 && Event.current.type <= EventType.mouseUp) {
				GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
				//这里可以判断selectedGameObject的条件
				if (selectedGameObject) {
					Vector2 mousePosition = Event.current.mousePosition;

					EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "Window/Test", null);
					Event.current.Use();
				}
			}
		}

	}
}