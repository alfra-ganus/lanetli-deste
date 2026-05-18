using Godot;
using System;
using Godot.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LanetliDeste;
public partial class Spawner : Node2D
{
	private Player player;
	[Export] public Array<PackedScene> SpawnSceneleri { get; set; } = new(); 

	[Export] public Marker2D[] SpawnNoktalari;


	PackedScene silah;
	PackedScene enemy;
	PackedScene iksir;
	
	public void RandomAtama()
	{
		if(SpawnSceneleri.Count!=0){
		int index;
		foreach(Marker2D nokta in SpawnNoktalari)
		{
			index = GD.RandRange(0,SpawnSceneleri.Count-1);
			Node2D eleman = SpawnSceneleri[index].Instantiate<Node2D>();
			AddChild(eleman);
			eleman.GlobalPosition=nokta.GlobalPosition;
		}
		}
		
	}

	
	public override void _Ready()
	{
		silah=GD.Load<PackedScene>("res://Scenes/silah.tscn");
		enemy=GD.Load<PackedScene>("res://Scenes/enemy.tscn");
		iksir=GD.Load<PackedScene>("res://Scenes/iksir.tscn");
		if(GameManager.silah_value.Count==0) SpawnSceneleri.Remove(silah);
		if(GameManager.enemy_value.Count==0) SpawnSceneleri.Remove(enemy);
		if(GameManager.iksir_value.Count==0) SpawnSceneleri.Remove(iksir);
		player=GameManager.playerglobal;
		RandomAtama();
		
	}



	public override void _Process(double delta)
	{
	if(SpawnSceneleri.Count==0) GameManager.gameon=false;
	}

	

}
