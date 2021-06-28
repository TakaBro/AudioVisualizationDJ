using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    [SerializeField] private GameObject _sampleCubePrefabLightBlue, _sampleCubePrefabBlue, 
        _sampleCubePrefabPurple, _sampleCubePrefabRed, _sampleCubePrefabYellow, _sampleCubePrefabGreen;
    [SerializeField] private GameObject[] _sampleCubes = new GameObject[42];
    private bool hasMusicStoped = false;
    
    public float _maxScale;

    private void OnEnable()
    {
        GlobalTimer.onMusicEnded += StopInstantiateCubes;
    }

    private void OnDisable()
    {
        GlobalTimer.onMusicEnded -= StopInstantiateCubes;
    }

    private void StopInstantiateCubes()
    {
        hasMusicStoped = true;
    }

    void Start()
    {
        for(int i = 0; i < 42; i++)
        {
            if (i != 0)
            {
                GameObject _instanceSampleCube = InstantiateSampleCubePrefab(i);
                _instanceSampleCube.transform.position = this.transform.position;
                _instanceSampleCube.transform.eulerAngles = new Vector3(-30,
                                                                        _instanceSampleCube.transform.eulerAngles.y,
                                                                        _instanceSampleCube.transform.eulerAngles.z);
                _instanceSampleCube.transform.parent = this.transform;
                _instanceSampleCube.name = "SampleCube" + i;
                this.transform.eulerAngles = new Vector3(-30, /*-5.625f*/ -8f * i, 0);
                _instanceSampleCube.transform.position = Vector3.forward * 80;
                _sampleCubes[i] = _instanceSampleCube;
            }
            else
            {
                GameObject _instanceSampleCube = InstantiateSampleCubePrefab(i);
                _instanceSampleCube.transform.position = new Vector3(this.transform.position.x, 
                                                                     this.transform.position.x -150, 
                                                                     this.transform.position.z);
                _instanceSampleCube.transform.parent = this.transform;
                _instanceSampleCube.name = "SampleCube" + i;
                //_instanceSampleCube.transform.position = Vector3.forward * 80;
                _sampleCubes[i] = _instanceSampleCube;
            }
        }
        this.transform.eulerAngles = new Vector3(-85.2f, 0, 0);
    }

    private GameObject InstantiateSampleCubePrefab(int i)
    {
        if (i <= 14)
        {
            return (GameObject)Instantiate(_sampleCubePrefabBlue);
        }
        else if (i > 14 && i <= 21)
        {
            return (GameObject)Instantiate(_sampleCubePrefabYellow);
        }
        else if (i > 21 && i <= 34)
        {
            return (GameObject)Instantiate(_sampleCubePrefabRed);
        }
        else
        {
            return (GameObject)Instantiate(_sampleCubePrefabGreen);
        }
    }

    void Update()
    {
        if (!hasMusicStoped)
        {
            for (int i = 0; i < 42; i++)
            {
                if (_sampleCubes != null)
                {
                    if (i == 0 || i == 1)
                    {
                        _sampleCubes[i].transform.localScale = new Vector3(20, AudioPeer.samples[i] * 0, 10);
                    }
                    else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 ||
                         i == 11 || i == 12 || i == 13 || i == 14 || i == 15)
                    {
                        _sampleCubes[i].transform.localScale = new Vector3(20, AudioPeer.samples[i] * 1000 + 2, 10);
                    }
                    else
                    {
                        _sampleCubes[i].transform.localScale = new Vector3(20, AudioPeer.samples[i] * 4000 + 2, 10);
                    }
                }
            }
        }
    }
}
