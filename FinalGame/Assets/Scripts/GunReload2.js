var ReloadSound: AudioSource;
var CrossObject : GameObject;
var MechanicsObject: GameObject;
var ClipCount : int;
var ReserveCount: int;
var ReloadAvailable: int;


function Update()
{
    ClipCount = Global2Ammo.LoadedAmmo;
    ReserveCount = Global2Ammo.CurrentAmmo;

    if(ReserveCount == 0)
    {
        ReloadAvailable =  0;
    }
    else
    {
        ReloadAvailable = 10 - ClipCount;
    }

    // the magic of the reload gun machanics 
   
    if(Input.GetButtonDown("Reload2"))               //checking if we are pressing reload button
    {
        if(ReloadAvailable >=1)                      //where should we add bullets too
        {
            if(ReserveCount <= ReloadAvailable)
            {
                Global2Ammo.LoadedAmmo += ReserveCount;
                Global2Ammo.CurrentAmmo -= ReserveCount;
                ActionReload();
            }
            else                     
            {
                Global2Ammo.LoadedAmmo += ReloadAvailable;
                Global2Ammo.CurrentAmmo -= ReloadAvailable;
                ActionReload();
            }
        }
        EnableScripts();
        
    }
}

function EnableScripts()
{
    yield WaitForSeconds(1.1);                             // wait for the reload of the gun
    this.GetComponent("GunFire2").enabled=true;
    CrossObject.SetActive(true);
    MechanicsObject.SetActive(true);
}
function ActionReload() 
{
    this.GetComponent("GunFire2").enable = false;
    CrossObject.SetActive(false);                             // so player cant shoot during reloading
    MechanicsObject.SetActive(false);
    ReloadSound.Play();

    //GetComponent.<Animation>().Play("HandGunReload");

    //15.02
}