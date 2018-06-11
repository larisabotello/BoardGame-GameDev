
// Script used to pick up ammo and sound effects

var AmmoSound: AudioSource;
var AmmoSize;

function OnTriggerEnter (col : Collider)
    {
        AmmoSound.Play();
        // if our loaded ammo = 0 perform the switch
        if(Global2Ammo.LoadedAmmo == 0)
        {
            Global2Ammo.LoadedAmmo += 15;
            this.gameObject.SetActive(false);
        }
        else  //if not equal to zero.. which means we have bullets in the gun
        {
            Global2Ammo.CurrentAmmo += 10;
            this.gameObject.SetActive(false);
        }

    }