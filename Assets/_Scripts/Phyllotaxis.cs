using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Phyllotaxis : MonoBehaviour {

	public AudioPeerScript _audioPeer;
	private Material _trailMat;
	public Color _trailColor;
	
	public float _degree, _scale;
	public int _numberStart;
	public int _stepSize;
	public int _maxIteration;

	//Lerping variables
	public bool _useLerping;
	private bool _isLerping;
	private Vector3 _startPosition, _endPosition;
	private float _lerpPosTimer, _lerpPosSpeed;
	public Vector2 _lerpPosSpeedMinMax;
	public AnimationCurve _lerpPosAnimCurve;
	public int _lerpPosBand;

	private int _number;
	private int _currentIteration;
	private TrailRenderer _trailRenderer;
	private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
	{
		double angle = number * (degree * Mathf.Deg2Rad);
		float r = scale * Mathf.Sqrt (number);
		float x = r * (float)System.Math.Cos (angle);
		float y = r * (float)System.Math.Sin (angle);

		Vector2 vec2 = new Vector2 (x, y);
		return vec2;
	}

	private Vector2 _phyllotaxisPosition;

	private bool _forward; //go forward if true, backwards if false
	public bool _repeat, _invert;

	//Scaling
	public bool _useScaleAnimation, _useScaleCurve;
	public Vector2 _scaleAnimMinMax;
	public AnimationCurve _scaleAnimCurve;
	public float _scaleAnimSpeed;
	public int _scaleBand;

	private float _scaleTimer, _currentScale;

	void SetLerpPositions()
	{
		/*_phyllotaxisPosition = CalculatePhyllotaxis (_degree, _currentScale, _number);
		_startPosition = this.transform.localPosition;
		_endPosition = new Vector3 (_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);*/

		_phyllotaxisPosition = CalculatePhyllotaxis(_degree, _currentScale, _number);
		_startPosition = this.transform.localPosition;
		if ((!System.Single.IsNaN(_phyllotaxisPosition.x)) || (!System.Single.IsNaN(_phyllotaxisPosition.y)))
		{
			_endPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
		}

	}

	// Use this for initialization
	void Awake () {
		_currentScale = _scale;
		_forward = true;
		_trailRenderer = GetComponent<TrailRenderer> ();
		_trailMat = new Material (_trailRenderer.material);
		_trailMat.SetColor ("_TintColor", _trailColor);
		_trailRenderer.material = _trailMat;
		_number = _numberStart;
		transform.localPosition = CalculatePhyllotaxis (_degree, _currentScale, _number);
		if (_useLerping) {
			_isLerping = true;
			SetLerpPositions ();
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){ //"back" button for desktop
			SceneManager.LoadScene("Menu");
		}

		if (Input.touchCount == 1) { //"back" button for android
			SceneManager.LoadScene("Menu");
		}
		
		if (_useScaleAnimation) {
			if (_useScaleCurve) {
				_scaleTimer += (_scaleAnimSpeed * _audioPeer._audioBand [_scaleBand]) * Time.deltaTime;
				if (_scaleTimer >= 1) {
					_scaleTimer -= 1;
				}
				_currentScale = Mathf.Lerp (_scaleAnimMinMax.x, _scaleAnimMinMax.y, _scaleAnimCurve.Evaluate (_scaleTimer));
			} else {
				_currentScale = Mathf.Lerp (_scaleAnimMinMax.x, _scaleAnimMinMax.y, _audioPeer._audioBand [_scaleBand]);
			}
		}
		
		if (_useLerping) {
			if (_isLerping) {
				_lerpPosSpeed = Mathf.Lerp (_lerpPosSpeedMinMax.x, _lerpPosSpeedMinMax.y, _lerpPosAnimCurve.Evaluate(_audioPeer._audioBand[_lerpPosBand]));
				_lerpPosTimer += Time.deltaTime * _lerpPosSpeed;
				transform.localPosition = Vector3.Lerp (_startPosition, _endPosition, Mathf.Clamp01(_lerpPosTimer));
				if (_lerpPosTimer >= 1) {
					_lerpPosTimer -= 1;
					if (_forward) {
						_number += _stepSize;
						_currentIteration++;
					} 
					else {
						_number -= _stepSize;
						_currentIteration--;
					}
					if ((_currentIteration > 0) && (_currentIteration < _maxIteration)) {
						SetLerpPositions ();
					} 
					else //current iteration has hit 0 or max iteration
					{ 
						if (_repeat) {
							if (_invert) {
								_forward = !_forward;
								SetLerpPositions ();
							} 
							else {
								_number = _numberStart;
								_currentIteration = 0;
								SetLerpPositions ();
							}
						} 
						else {
							_isLerping = false;
						}
					}
				}
			}

		} 
		if(!_useLerping) {
			_phyllotaxisPosition = CalculatePhyllotaxis (_degree, _currentScale, _number);
			transform.localPosition = new Vector3 (_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
			_number += _stepSize;
			_currentIteration++;
		}
	}
}
