using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject[] prefabs;
    private Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    [SerializeField] private AudioClip[] synopsis;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private GameObject avatra;
    private void Awake()
    {
        foreach (GameObject pref in prefabs)
        {
            GameObject newPrefab = Instantiate(pref, Vector3.zero, Quaternion.identity);
            newPrefab.name = pref.name;
            newPrefab.SetActive(false);
            _instantiatedPrefabs.Add(pref.name, newPrefab);
           
        }
        avatra.SetActive(false);
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(false);
            avatra.SetActive(false);

        }

    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        

        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(false);
            avatra.SetActive(false);
            return;
        }

        if(prefabs !=null)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(true);
            avatra.SetActive(true);
            _instantiatedPrefabs[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;

            // Get the position of the tracked image
            Vector3 trackImagePos = trackedImage.transform.position;

            // Calculate the position to the left of the tracked image
            float offset = 0.08f; // Adjust this value to control the distance from the tracked image
            Vector3 avatarPos = new Vector3(trackImagePos.x - offset, trackImagePos.y, trackImagePos.z);

            avatra.transform.position = avatarPos;
        }
    }


  
}
