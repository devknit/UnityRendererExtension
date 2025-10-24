
using System.Collections.Generic;

namespace UnityEngine
{
	[RequireComponent( typeof( LineRenderer))]
	sealed class LineRendererPositions : MonoBehaviour
	{
	#if UNITY_EDITOR
		void Reset()
		{
			m_Renderer = GetComponent<LineRenderer>();
			m_Transforms.Clear();
			
			for( int i0 = 0; i0 < transform.childCount; ++i0)
			{
				m_Transforms.Add( transform.GetChild( i0));
			}
			LateUpdate();
		}
	#endif
		void LateUpdate()
		{
			if( (m_Positions?.Length ?? -1) != m_Transforms.Count)
			{
				m_Positions = new Vector3[ m_Transforms.Count];
				m_Renderer.positionCount = m_Positions.Length;
			}
			for( int i0 = 0; i0 < m_Positions.Length; ++i0)
			{
				m_Positions[ i0] = m_Transforms[ i0].transform.position;
			}
			m_Renderer.SetPositions( m_Positions);
		}
		[SerializeField, HideInInspector]
		LineRenderer m_Renderer;
		[SerializeField]
		List<Transform> m_Transforms;
		[System.NonSerialized]
		Vector3[] m_Positions;
	}
}
