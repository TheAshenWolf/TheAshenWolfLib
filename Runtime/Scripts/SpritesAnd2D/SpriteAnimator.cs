using System.Collections.Generic;
using UnityEngine;

namespace TheAshenWolfLib.Runtime.Scripts.SpritesAnd2D
{
  /// <summary>
  /// Custom component added to all entities, providing the option of animation from a list of sprites.
  /// </summary>
  public class SpriteAnimator : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Coroutine _currentAnimation;
    private float _timer;
    private List<Sprite> _frames;
    private int _fps;
    private int _currentFrame;
    private bool _playOnce;
    private List<Sprite> _defaultFrames;
    private int _defaultFps;

    /// <summary>
    /// Starts the animation
    /// </summary>
    /// <param name="frames">Frames of the animation</param>
    /// <param name="framesPerSecond">Animation speed</param>
    /// <param name="reset">If set to false (default), the animation will not start again, if it is already playing</param>
    /// <param name="setDefault">Set this animation as the default one</param>
    public void Play(List<Sprite> frames, int framesPerSecond, bool reset = false, bool setDefault = false)
    {
      if (!reset && frames == _frames && _timer > 0)
      {
        return;
      }
      
      _frames = frames;
      _fps = framesPerSecond;
      _timer = 1f / _fps;
      _currentFrame = 0;

      if (!setDefault) return;
      _defaultFps = framesPerSecond;
      _defaultFrames = frames;
    }

    /// <summary>
    /// Sets a list of frames and fps as the default animation,
    /// The default animation is played in a loop when no other animation is playing. (For example the idle animation)
    /// </summary>
    public void SetDefaultAnimation(List<Sprite> frames, int framesPerSecond, bool play = false)
    {
      _defaultFrames = frames;
      _defaultFps = framesPerSecond;
      if (play) PlayDefault();
    }

    public void PlayDefault()
    {
      if (_defaultFrames == _frames && _timer > 0)
      {
        return;
      }
      
      _frames = _defaultFrames;
      _fps = _defaultFps;
    }
    
    /// <summary>
    /// Plays the animation once
    /// </summary>
    /// <param name="frames">List of frames of the animation</param>
    /// <param name="framesPerSecond">Speed of the animation</param>
    /// <param name="reset">If set to false (default), the animation will not start again, if it is already playing</param>
    /// <param name="continueWithDefault">If true, animation will revert back to default</param>
    public void PlayOnce(List<Sprite> frames, int framesPerSecond, bool reset = false, bool continueWithDefault = false)
    {
      _playOnce = true;
      Play(frames, framesPerSecond, reset, continueWithDefault);
    }
  
  
    

    private void Update()
    {
      if (_fps <= 0 || _frames == null) return;
      
      _timer += Time.deltaTime;
      if (!(_timer > 1f / _fps)) return;
      _timer -= 1f / _fps;
      _currentFrame++;
      if (_playOnce && _currentFrame >= _frames.Count)
      {
        _currentFrame = 0;
        _timer = 0;
        _playOnce = false;
        _frames = null;
        if (_defaultFrames != null) Play(_defaultFrames, _defaultFps);
        return;
      }
      spriteRenderer.sprite = _frames[_currentFrame % _frames.Count];
    }
  }
}