using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorExtension {
	public class LockInspector : MonoBehaviour {
		[MenuItem("Test/Lock&unlock %&L")]
		private static void OnLock() {
			var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.InspectorWindow");
			var window = EditorWindow.GetWindow(type);
			MethodInfo info = type.GetMethod("FlipLocked", BindingFlags.NonPublic | BindingFlags.Instance);
			info.Invoke(window, null);
		}
	}

}