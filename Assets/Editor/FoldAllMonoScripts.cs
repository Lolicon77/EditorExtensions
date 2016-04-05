using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorExtension {
	public class FoldAllMonoScripts : MonoBehaviour {

		enum FoldOrUnfold {
			Fold,
			Unfold
		}


		/// <summary>
		/// 折叠
		/// </summary>
		[MenuItem("Test/Fold All %&LEFT")]
		static void FoldAll() {
			Handle(FoldOrUnfold.Fold);
		}

		/// <summary>
		/// 展开
		/// </summary>
		[MenuItem("Test/Unfold All %&RIGHT")]
		static void UnfoldAll() {
			Handle(FoldOrUnfold.Unfold);
		}

		static void Handle(FoldOrUnfold mode) {
			var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.InspectorWindow");
			var window = EditorWindow.GetWindow(type);
			FieldInfo info = type.GetField("m_Tracker", BindingFlags.NonPublic | BindingFlags.Instance);
			ActiveEditorTracker tracker = info.GetValue(window) as ActiveEditorTracker;

			for (int i = 0; i < tracker.activeEditors.Length; i++) {
				//可以通过名字单独判断组件展开或不展开
				//				if (tracker.activeEditors[i].target.GetType().Name != "??") 
				//这里1就是展开，0就是合起来
				tracker.SetVisible(i, mode == FoldOrUnfold.Fold ? 0 : 1);
			}
			window.Repaint();
		}

	}
}