using Godot;
using System;

namespace LanetliDeste;
public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D player_anim;
	public int MevcutSilah{get;set;}=0;

	[Export] public int Can{get;set;}
	
	
	public override void _PhysicsProcess(double delta)
	{
		player_anim.Play("idle");
	}
	
	public override void _Ready(){
		
		GameManager.playerglobal=this;
		player_anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		MevcutSilah=GameManager.silahglobal;
		Can=GameManager.canglobal;
	}


	public void CanUpdate(int deger,string mod)
	{
		if(mod=="iksir"){
			Can+=deger;
		}
		if (mod=="enemy"){
			if(MevcutSilah>0){
				if (MevcutSilah > deger)
				{
					MevcutSilah=deger;
					deger=0;
				}
				
				else
				{
					deger-=MevcutSilah;
					MevcutSilah=0;
				}
			}
			Can-=deger;
			GameManager.silahglobal=MevcutSilah;
		}
		if (Can>20){
			Can=20;
		}
		if (Can <=0)
		{
			GetTree().ChangeSceneToFile("res://Scenes/oyunbitti.tscn");
		} 
		GameManager.canglobal=Can;
	}

	public void SilahKusan(int silah)
	{
		MevcutSilah=silah;
		GameManager.silahglobal = MevcutSilah;
	}
	
	
}
