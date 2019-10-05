using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NvpAudioEvent), true)]
public class AudioEventEditor : Editor
{

	[SerializeField] private AudioSource _previewer;

	public void OnEnable()
	{
		_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.None, typeof(AudioSource)).GetComponent<AudioSource>();
		
	}

	public void OnDisable()
	{
		DestroyImmediate(_previewer.gameObject);
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
		if (GUILayout.Button("Preview"))
		{
			((NvpAudioEvent) target).Play(_previewer);
		}
		EditorGUI.EndDisabledGroup();
	}
}