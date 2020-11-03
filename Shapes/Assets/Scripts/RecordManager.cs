using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recorder
{
    //Called by UIManager
    //a part of the plug-in for recording audio/screencapture for MovieMaker
    //https://www.youtube.com/watch?v=j3zGzbe9V1o

    [RequireComponent(typeof(ScreenRecorder))]
    public class RecordManager : MonoBehaviour
    {
        ScreenRecorder recorder;
		private void Start()
		{
            recorder = GetComponent<ScreenRecorder>();
		}		

        public void StartRecord()
        {
            recorder.PrepareRecorder();
            StartCoroutine(DelayCallRecord());
        }
        private IEnumerator DelayCallRecord()
        {
            yield return new WaitForSeconds(0.1f);
            recorder.StartRecording();
        }


        public void StopRecord()
        {
            recorder.StopRecording();
            StartCoroutine(DelaySaveVideo());
        }
        private IEnumerator DelaySaveVideo()
        {
            yield return new WaitForSeconds(1);
            recorder.SaveVideoToGallery();
        }
    }
}

