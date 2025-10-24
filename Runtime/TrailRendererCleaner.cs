
namespace UnityEngine
{
	[RequireComponent( typeof( TrailRenderer))]
	sealed class TrailRendererCleaner : MonoBehaviour
	{
		void OnDisable()
		{
			GetComponent<TrailRenderer>().Clear();
		}
	}
}
