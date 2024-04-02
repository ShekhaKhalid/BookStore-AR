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

    private void Awake()
    {
        foreach (GameObject pref in prefabs)
        {
            GameObject newPrefab = Instantiate(pref, Vector3.zero, Quaternion.identity);
            newPrefab.name = pref.name;
            newPrefab.SetActive(false);
            _instantiatedPrefabs.Add(pref.name, newPrefab);
           
        }
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

        }

    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        

        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(false);
           
            return;
        }

        if(prefabs !=null)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].gameObject.SetActive(true);
            _instantiatedPrefabs[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
           
        }
    }


  
}
