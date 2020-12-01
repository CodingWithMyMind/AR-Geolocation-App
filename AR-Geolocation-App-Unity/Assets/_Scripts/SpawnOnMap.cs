namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

	
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject[] POIPrefabs;

		List<GameObject> _spawnedObjects;

		void Start()
		{
			_locations = new Vector2d[POIPrefabs.Length];
			_spawnedObjects = new List<GameObject>();

			for (int i = 0; i < POIPrefabs.Length; i++)
			{
				//var locationString = _locationStrings[i];

				var locationString = POIPrefabs[i].GetComponent<POIObject>().locationString;

				_locations[i] = Conversions.StringToLatLon(locationString);


				var instance = Instantiate(POIPrefabs[i]);
				
				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				//instance.transform.localScale = new Vector3(_spawnScale, instance.transform.localScale.y, _spawnScale);
				_spawnedObjects.Add(instance);
			}
		}

		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			}
			
		}
	}
}