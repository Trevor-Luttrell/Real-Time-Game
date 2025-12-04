using Godot;
using System;

public partial class Watergirl : CharacterBody2D
{
	[Export]
	public float speed = 260f;
	[Export]
	public float jumpForce = -400f;
	[Export]
	public float gravity = 800f;
	
	private AnimatedSprite2D head;
	private AnimatedSprite2D body;
	
	public override void _Ready()
	{
		head = GetNode<AnimatedSprite2D>("Head");
		body = GetNode<AnimatedSprite2D>("Body");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		if(!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}
		else if(velocity.Y > 0)
		{
			velocity.Y = 0;
		}
		
		float direction = Input.GetActionStrength("water_right") - Input.GetActionStrength("water_left");
		velocity.X = direction * speed;
		
		if(Input.IsActionJustPressed("water_up") && IsOnFloor())
		{
			velocity.Y = jumpForce;
		}
		
		Velocity = velocity;
		MoveAndSlide();
		UpdateAnimations(velocity);
	}
	
	private void UpdateAnimations(Vector2 velocity)
	{
		if(!IsOnFloor())
		{
			if(velocity.Y > 0)
			{
				PlayHeadAnimation("move_down");
			}
		}
		else
		{
			if(Mathf.Abs(velocity.X) > 5)
			{
				PlayHeadAnimation("move_right");
				PlayBodyAnimation("move_right");
				head.FlipH = body.FlipH = velocity.X < 0;
			}
			else
			{
				PlayHeadAnimation("default");
				PlayBodyAnimation("default");
			}
		}
	}
	
	private void PlayHeadAnimation(string animName)
	{
		if(head.Animation != animName)
			head.Play(animName);
	}
	
	private void PlayBodyAnimation(string animName)
	{
		if(body.Animation != animName)
			body.Play(animName);
	}
	
	public void ResetVelocity()
	{
		Velocity = Vector2.Zero;
	}
}
