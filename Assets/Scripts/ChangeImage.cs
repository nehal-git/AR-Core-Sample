using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChangeImage : MonoBehaviour
{
    public GameObject prefab;
    public string imageURL = "https://drive.google.com/uc?export=download&id=16r4OKdaO5C8RhnQilfVFuUYnclhSbyG4";
    public Texture2D texture2D;
    public ARTrackedImageManager manager;
    [SerializeField]
    XRReferenceImageLibrary serializedLibrary;
    RuntimeReferenceImageLibrary runtimeLibrary;

    public Material image;

    bool ImageAdded;

    private void OnEnable()
    {

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        // manager.enabled = false;
        // runtimeLibrary = new RuntimeReferenceImageLibrary();

       
       
         manager = gameObject.AddComponent<ARTrackedImageManager>();
        manager.referenceLibrary = manager.CreateRuntimeLibrary(serializedLibrary);
        manager.requestedMaxNumberOfMovingImages = 1;
        manager.trackedImagePrefab = prefab;
        manager.trackedImagesChanged += Manager_trackedImagesChanged;
        manager.enabled = false;
        manager.SetTrackablesActive(false);

    }

    public void download()
    {

        StartCoroutine(GetTexture());
    }


    IEnumerator GetTexture()
    {
        if (!string.IsNullOrEmpty(imageURL))
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
            yield return www.SendWebRequest();

            if (www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Loaded");
                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                // image.SetTexture(0, myTexture);

                StartCoroutine(imageToAdd(myTexture));
            }
        }
        else
        {

        StartCoroutine(imageToAdd(texture2D));
            yield return null;
        }
    }


    IEnumerator imageToAdd(Texture2D imageToAdd)
    {
        Debug.Log("JobStarted");
        Debug.Log(DoesSupportMutableImageLibraries());
        MutableRuntimeReferenceImageLibrary mutableLibrary = manager.referenceLibrary as MutableRuntimeReferenceImageLibrary;

        var job = mutableLibrary.ScheduleAddImageWithValidationJob(imageToAdd, "image", 0.1f);
        while (!job.jobHandle.IsCompleted)
        {

            Debug.Log("JobRunning");
            yield return null;
        }

    }
    private void Manager_trackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log("Added");



            ImageAdded = true;

        }
        foreach (var updatedImage in eventArgs.updated)
        {
            Debug.Log("Updated");
            // Handle updated event
        }

        foreach (var removedImage in eventArgs.removed)
        {
            Debug.Log("Removed");
            // Handle removed event
        }
    }
   

   
    bool DoesSupportMutableImageLibraries()
    {
        return manager.descriptor.supportsMutableLibrary;
    }
}
