﻿import UnityEngine.UI;

static var CurrentAmmo: int;
var InternalAmmo: int;
var AmmoDisplay : GameObject;

static var LoadedAmmo : int;
var InternalLoaded : int;
var LoadedDisplay : GameObject;

function Update () 
{
    InternalAmmo = CurrentAmmo;
    InternalLoaded = LoadedAmmo;


    AmmoDisplay.GetComponent.<Text>().text = "" + InternalAmmo;
    // for the loaded bullet of the player
    LoadedDisplay.GetComponent.<Text>().text = "" + LoadedAmmo;

}
