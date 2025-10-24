
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityEditor
{
	static class SelectAssetsInChildren
	{
		[MenuItem( "GameObject/Select Assets in Children/Material", validate = true)]
		static bool HasSelectMaterials()
		{
			return Selection.gameObjects.Length > 0;
		}
		[MenuItem( "GameObject/Select Assets in Children/Material", validate = false)]
		static void SelectMaterials()
		{
			var materials = new HashSet<Material>();
			
			foreach( var gameObject in Selection.gameObjects)
			{
				foreach( var renderer in gameObject.GetComponentsInChildren<Renderer>( true))
				{
					foreach( var material in renderer.sharedMaterials)
					{
						if( material != null && materials.Add( material) != false)
						{
							Debug.Log( $"Select Asset in Children <Material>\n{AssetDatabase.GetAssetPath( material)}\n", material);
						}
					}
				}
			}
			if( materials.Count > 0)
			{
				Selection.objects = materials.ToArray();
			}
		}
		[MenuItem( "GameObject/Select Assets in Children/Mesh", validate = true)]
		static bool HasSelectMeshs()
		{
			return Selection.gameObjects.Length > 0;
		}
		[MenuItem( "GameObject/Select Assets in Children/Mesh", validate = false)]
		static void SelectMeshs()
		{
			var meshes = new HashSet<Mesh>();
			
			foreach( var gameObject in Selection.gameObjects)
			{
				foreach( var meshFilter in gameObject.GetComponentsInChildren<MeshFilter>( true))
				{
					if( meshFilter.sharedMesh != null && meshes.Add( meshFilter.sharedMesh) != false)
					{
						Debug.Log( $"Select Asset in Children <Mesh>\n{AssetDatabase.GetAssetPath( meshFilter.sharedMesh)}\n", meshFilter.sharedMesh);
					}
				}
				foreach( var skinnedMeshRenderer in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>( true))
				{
					if( skinnedMeshRenderer.sharedMesh != null && meshes.Add( skinnedMeshRenderer.sharedMesh) != false)
					{
						Debug.Log( $"Select Asset in Children <Mesh>\n{AssetDatabase.GetAssetPath( skinnedMeshRenderer.sharedMesh)}\n", skinnedMeshRenderer.sharedMesh);
					}
				}
				foreach( var meshCollider in gameObject.GetComponentsInChildren<MeshCollider>( true))
				{
					if( meshCollider.sharedMesh != null && meshes.Add( meshCollider.sharedMesh) != false)
					{
						Debug.Log( $"Select Asset in Children <Mesh>\n{AssetDatabase.GetAssetPath( meshCollider.sharedMesh)}\n", meshCollider.sharedMesh);
					}
				}
			}
			if( meshes.Count > 0)
			{
				Selection.objects = meshes.ToArray();
			}
		}
	}
}
