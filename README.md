# WindowsGSM.Palworld
🧩WindowsGSM plugin that provides Palworld Dedicated server

# PLEASE ⭐STAR⭐ THE REPO IF YOU LIKE IT! THANKS!

# WindowsGSM Installation: 
1. Download  WindowsGSM https://windowsgsm.com/ 
2. Create a Folder at a Location you wan't all Server to be Installed and Run.
4. Drag WindowsGSM.Exe into previoulsy created folder and execute it.

# Plugin Installation:
1. Download [latest](https://github.com/ohmcodes/WindowsGSM.Palworld/releases/latest) release
2. Extract then Move **Palworld.cs** folder to **plugins** folder
3. OR Press on the Puzzle Icon in the left bottom side and install this plugin by navigating to it and select the Zip File.
4. Click **[RELOAD PLUGINS]** button or restart WindowsGSM
5. Navigate "Servers" and Click "Install Game Server" and find "Palworld Dedicated Server [Palworld.cs]

### Official Documentation
🗃️ [https://Palworld.fandom.com/wiki/Dedicated_servers](https://tech.palworldgame.com/dedicated-server-guide)

### Unofficial Documentation
🗃️ https://www.Palworld.com/blog/Palworld-dedicated-server/

### The Game
🕹️ https://store.steampowered.com/app/1623730/Palworld/

### Dedicated server info
🖥️ https://steamdb.info/app/2394010/info/

### Port Forwarding
- 8211 UDP - Default
- TCP for 27015 - cant be change
- RCONPort can be change to anything so thats for another forwarding TCP/UDP

### Available Params
All these params are automatically set by WGSM
- EpicApp=PalServer	            Setup server as a community server. Do not change this parameter.
- -publicip=192.168.xxx.xxx     Usualy the local port of the server (Change via WGSM settings)
- -publicport=8211              cant be change and its not really working (Change via WGSM settings)
- -port=8211                    can be change and working (Change via WGSM settings)
- -queryport=27015              this is a test not confirmed if its working or not
- -players=32                   can be set how much you want, as far as i know it can be 128 (Change via WGSM settings)
- -servername=""                can override via Server Start Param box (WGSM Edit button)
- -serverdescription=""         can override via Server Start Param box (WGSM Edit button)
- -adminpassword=""             can override via Server Start Param box (WGSM Edit button)
- -serverpassword=""            can override via Server Start Param box (WGSM Edit button)
- -rconenabled=true             can override via Server Start Param box (WGSM Edit button)
- -rconport=25572               default can override via Server Start Param box (WGSM Edit button)

### Config Guide
I've tried setting up PublicPort and PublicIP from here it looks like it gets overriden by launch parameters and its better than changing here
- Copy all the contents of `\DefaultPalWorldSettings.ini` to `\Pal\Saved\Config\WindowsServer\PalWorldSettings.ini`
- Change ServerName
- Change PublicIP= x.x.x.x (Local Server IP eg: 192.168.x.x)
- AdminPassword (Console can be perform in Chatbox using /AdminPassword then /Broadcast Test)
- RCONEnabled (if you are using thirdparty apps this is useful for saving the game outside for example discord slash commands /Save)
- RCONPort (Can be set any port you preferred and must be forwarded as well)
- Any other settings can be set (WARNING: Changing world settings server administrators reported that their saves is being wipe after changing values)

### Connecting on a locked server (with password)
- direct connect using ip:port
- then go to Recent Servers click then input password

### Blank Console?
- Try Install Required Redist insde `_CommonRedist` folder
- VC++ latest  DirectX offline version or latest
- download and install steam launcher on your server will do the fix
- you should be seeing `Setting breakpad minidump AppID = 1623730`

### Stuck in loading?
- Delete profile (For now now other fix)
- To get the profile either open up a new server and let corrupted player to join and copy the save hex
- Or backup all the players and start the server, let corrupted player to join and remember the hex and restore profiles then delete the corrupted profile save
- if you have the player id you can conver it the hex https://www.binaryhexconverter.com/decimal-to-hex-converter
- https://www.youtube.com/watch?v=fwLamiy30Qc&ab_channel=EpicLazyPanda 
- It is advisable to put your pal in palbox and items in storages before logging out

# Other notes
- Server listing - Please be aware that the whole world is listing their own dedicated server it is advisable to use direct connect instead looking for it. The game is not region lock and max 200 items
- The game is currently in Early Access Stage WGSM and this plugin is not taking liability if something happens to your server, the app is only for managing your server easily

### Support
[Palworld](https://discord.com/channels/505994577942151180/1196354410868117525)

[WGSM](https://discord.com/channels/590590698907107340/645730252672335893)

# Give Love!
[Buy me a coffee](https://www.buymeacoffee.com/ohmcodes)

[Paypal](https://www.paypal.com/donate/?business=8389QZ23QRDPE&no_recurring=0&item_name=Game+Server%2FTools+Community+Donations&currency_code=CAD)

# License
This project is licensed under the MIT License - see the <a href="https://github.com/ohmcodes/WindowsGSM.Palworld/blob/main/LICENSE">LICENSE.md</a> file for details
