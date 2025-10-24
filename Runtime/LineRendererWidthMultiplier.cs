
namespace UnityEngine
{
	[RequireComponent( typeof( LineRenderer))]
	sealed class LineRendererWidthMultiplier : MonoBehaviour
	{
		enum Mode
		{
			Value,
			ScaleX,
			ScaleY,
			ScaleZ,
			ScaleMin,
			ScaleMax,
		}
		void Awake()
		{
			m_Renderer = GetComponent<LineRenderer>();
		}
		void LateUpdate()
		{
			Vector3 lossyScale = transform.lossyScale;
			m_Renderer.widthMultiplier = m_Mode switch
			{
				Mode.ScaleX => lossyScale.x * m_Multiplier,
				Mode.ScaleY => lossyScale.y * m_Multiplier,
				Mode.ScaleZ => lossyScale.z * m_Multiplier,
				Mode.ScaleMin => Mathf.Min( lossyScale.x, Mathf.Min( lossyScale.y, lossyScale.z)) * m_Multiplier,
				Mode.ScaleMax => Mathf.Max( lossyScale.x, Mathf.Max( lossyScale.y, lossyScale.z)) * m_Multiplier,
				_ => m_Multiplier
			};
		}
		[SerializeField]
		Mode m_Mode;
		[SerializeField]
		float m_Multiplier = 1.0f;
		[System.NonSerialized]
		LineRenderer m_Renderer;
	}
}