using Godot;
using System;
using Steamworks;

public class SteamInit : Node
{
   private const int APP_ID = 480;

    public override void _Ready() {
		runOnSteam();
		if (SteamAPI.Init()) {
        	GD.Print(SteamFriends.GetPersonaName());
        } else {
            GD.Print("[STEAMWORKS] Failed to initialize Steam. Please make sure that the Steam client is open.");
        }
    }
	
	private void runOnSteam() {
		if(SteamAPI.RestartAppIfNecessary((AppId_t) APP_ID)) {
			GD.Print("Restarting through Steam...");
			GetTree().Quit();	
		}	
	}
	
	public override void _Process(float delta) {
		SteamAPI.RunCallbacks();	
	}
}
