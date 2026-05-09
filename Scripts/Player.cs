using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D player_anim;
	const int speed = 100;
	Vector2 velocity;
	
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		player_Deneme(delta);
	}
	
	public override void _Ready(){
		player_anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	public void player_Deneme(double delta){
		
		if (Input.IsActionPressed("ui_right")){
			velocity.X=speed;
			velocity.Y=0;
			player_anim.Play("run");
		}
		
		else if(Input.IsActionPressed("ui_left")){
			velocity.X=-speed;
			velocity.Y=0;
		}
		
		else if(Input.IsActionPressed("ui_down")){
			velocity.X=0;
			velocity.Y=speed;
		}
		
		else if(Input.IsActionPressed("ui_up")){
			velocity.X=0;
			velocity.Y=-speed;
		}
		
		else{
			velocity.X=0;
			velocity.Y=0;
			player_anim.Play("idle");
		}
		
		Velocity=velocity;
		MoveAndSlide();
		
	}
	
}
