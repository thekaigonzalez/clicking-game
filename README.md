# Clicking Game

Clicking game is an addictive, interactive clicker game where you click to earn money.

Clicking game is a fast, asynchronous game and runs with little to no NET dependencies

## Features

- AutoClicker(s)
	- An AP (Automatic Press) System is a bot that collects money for you. You can upgrade it or buy more!
- Free & Open Source
	- Clicking Game is open source software and you can edit it and add modifications to it!
- Easy to use [Scripting API](#player-api)
	- The Scripting API can get and set player data.

## File Format

Save files go in this order.

```

(int, int, bool, int, bool)

Coins
Multiplier
Addons Enabled?
AutoClicker speed
Has autolicker?

```

# Player API

CustomShop.cs

```csharp

Player ply = new Player();

if (ply.Coins() >= 100) {
	var umap = new UserDataManipAPI();
	umap.LoadData();
	/* this function switches out the data for new data (you can add data using inceptions) */
	umap.SwitchData(ply.Coins().ToString() + 1000 /* add new coins */, ply.Multiplier().ToString(), ply.HasAddonsEnabled().ToString(), ply.APSpeed().ToString(), ply.OwnsAutoClick()); 
}

```
