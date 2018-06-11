var ReloadSound: AudioSource;
var CrossObject : GameObject;
var MechanicsObject: GameObject;
var ClipCount : int;
var ReserveCount: int;
var ReloadAvailable: int;


function Update()
{
    ClipCount = GlobalAmmo.LoadedAmmo;
    ReserveCount = GlobalAmmo.CurrentAmmo;

    if(ReserveCount == 0)
    {
        ReloadAvailable =  0;
    }
    else
    {
        ReloadAvailable = 10 - ClipCount;
    }

    // the magic of the reload gun machanics 
   
    if(Input.GetButtonDown("Reload"))               //checking if we are pressing reload button
    {
        if(ReloadAvailable >=1)                      //where should we add bullets too
        {
            if(ReserveCount <= ReloadAvailable)
            {
                GlobalAmmo.LoadedAmmo += ReserveCount;
                GlobalAmmo.CurrentAmmo -= ReserveCount;
                ActionReload();
            }
            else                     
            {
                GlobalAmmo.LoadedAmmo += ReloadAvailable;
                GlobalAmmo.CurrentAmmo -= ReloadAvailable;
                ActionReload();
            }
        }
        EnableScripts();
        
    }
}

function EnableScripts()
{
    yield WaitForSeconds(1.1);                             // wait for the reload of the gun
    this.GetComponent("GunFire").enabled=true;
    CrossObject.SetActive(true);
    MechanicsObject.SetActive(true);
}
function ActionReload() 
{
    this.GetComponent("GunFire").enable = false;
    CrossObject.SetActive(false);                             // so player cant shoot during reloading
    MechanicsObject.SetActive(false);
    ReloadSound.Play();

    //GetComponent.<Animation>().Play("HandGunReload");

    //15.02
}