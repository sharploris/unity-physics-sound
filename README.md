# Unity Physics Sound

## Contents
- [Overview](#overview)
- [Installation](#installation)
- [Demo](#demo)
- [Usage](#usage)
  * [Scriptable Objects](#scriptable-objects)
    + [3D Physics Sounds](#3d-physics-sounds)
    + [3D Physics Sound Dictionary](#3d-physics-sound-dictionary)
    + [2D Physics Sounds](#2d-physics-sounds)
    + [2D Physics Sound Dictionary](#2d-physics-sound-dictionary)
  * [Dictionary Methods](#dictionary-methods)
    + [UpdateActiveAudioClips](#updateactiveaudioclips)
    + [GetClipsFromMaterial](#getclipsfrommaterial)

## Overview

This is a small utility designed for the purpose of being able to match audio clips to physics materials in Unity. A good example of when this might be needed is when you want different sounds to play when your player is walking on different surfaces. This utility supports both the 2D and 3D physics engine included with Unity, and will allow you to build simple dictionaries of physics materials and an arbitrary number of corresponding audio clips.

## Installation

You can find a .unitypackage file for this utility [here](UnityPhysicsSound.unitypackage). Downloading it and opening it in Unity will allow you to install all of the files you need. You only need to import the appropriate folder for the physics system your game uses (`Audio2D` or `Audio3D`) but you must also import the `Shared` folder for it to function correctly. The demo folder is completely optional, but useful for seeing how it works.

## Demo

A demo scene is included with a player that can move and jump. There is a grey surface with a concrete physics material, a brown surface with a mud physics material, and a yellow surface with no physics material set. This allows you to see that different sounds play when walking and landing on each of them, with the default sounds playing on a surface with no physics material. Everything necessary to understand how to use this utility is included in the demo folder of this repo.

## Usage

### Scriptable Objects

By right clicking in your project window in the Unity Editor and going to `Create -> Physics Sounds`, you will see the following options:

#### 3D Physics Sounds

This is what you use to configure the audio clips for a specific physics material in the 3D physics engine. For example, you might create one called `Player Footsteps Wood` and assign it the wood physics material. You would then add all of your wood footstep sounds.

#### 3D Physics Sound Dictionary

This is what you use to configure all of your available 3D physics sounds for a particular interaction. Continuing on from the above example, you might create one called `Player Footsteps` and assign it your `Player Footsteps Wood` 3D physics sounds, as well as others for Ice, Sand, Concrete, etc. You can also assign a number of default audio clips to be used when interacting with colliders that have no physics material set.

#### 2D Physics Sounds

This is what you use to configure the audio clips for a specific physics material in the 2D physics engine. For example, you might create one called `Player Footsteps Wood` and assign it the wood physics material. You would then add all of your wood footstep sounds.

#### 2D Physics Sound Dictionary

This is what you use to configure all of your available 2D physics sounds for a particular interaction. Continuing on from the above example, you might create one called `Player Footsteps` and assign it your `Player Footsteps Wood` 2D physics sounds, as well as others for Ice, Sand, Concrete, etc. You can also assign a number of default audio clips to be used when interacting with colliders that have no physics material set.

### Dictionary Methods

#### UpdateActiveAudioClips

This method takes a `PhysicMaterial` or `PhysicsMaterial2D` depending on whether you are dealing with the 2D or 3D version. It will update the cached property `ActiveAudioClips` within the PhysicsSoundDictionary to be the appropriate array of `AudioClip` for the physics material it was given. This is used in the demo for footsteps so that we don't need to find the array every single time we play a footstep sound, and only update it when the surface we're walking on changes. It works something like this:

```
if(surfaceChanged){
    _footstepSounds.UpdateActiveAudioClips(newSurface);
}

if(shouldPlayFootstep){
    var index = Random.Range(0, _footstepSounds.ActiveAudioClips.Length);
    _audioSource.PlayOneShot(_footstepSounds.ActiveAudioClips[i])
}
```

#### GetClipsFromMaterial

This method takes a `PhysicMaterial` or `PhysicsMaterial2D` depending on whether you are dealing with the 2D or 3D version. It will return an array of `AudioClip` that corresponds to the physics material it is given, and will return the default clips if given null or if the dictionary has no match for the received physics material. This is used in the demo for landing sounds, as these are not played constantly and so we can just look them up when needed. It works something like this:

```
var landingSounds = _landingSounds.GetClipsFromMaterial(landedMaterial);

var index = Random.Range(0, landingSounds.Length);
_audioSource.PlayOneShot(landingSounds[i])
```
