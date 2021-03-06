﻿using BrewBot.Interfaces;

namespace BrewBot.CommandParsing.Templates
{
	public abstract class ACommand : ICommand
	{
		/// <summary>
		/// Callback to be executed by the command
		/// </summary>
		/// <param name="sender">User who triggered the callback</param>
		/// <param name="target">Target user of the callback</param>
		/// <param name="output">Default output of the callback</param>
		public delegate void CommandCallback( string sender, string target, string output = null );

		/// <summary>
		/// Create a command
		/// </summary>
		/// <param name="content">Line to create the command with. Must not be null or empty</param>
		/// <param name="sender">Who sent the command</param>
		/// <param name="target">What the command is targeting</param>
		/// <param name="cb">Callback to call</param>
		public ACommand( string content, string sender, string target, CommandCallback cb )
		{
			Content = content;
			Sender = sender;
			Target = target;
			CB = cb;
		}

		/// <summary>
		/// Input string content
		/// </summary>
		internal string Content
		{
			get; set;
		}

		/// <summary>
		/// Name of the user who originated this command
		/// </summary>
		internal string Sender
		{
			get; set;
		}

		/// <summary>
		/// Target of the command
		/// </summary>
		internal string Target
		{
			get; set;
		}

		/// <summary>
		/// Default output of the command
		/// </summary>
		internal string Output
		{
			get; set;
		}

		/// <summary>
		/// Callback to call
		/// </summary>
		internal CommandCallback CB
		{
			get; set;
		}

		/// <summary>
		/// Execute a command
		/// </summary>
		public virtual void ExecuteCommand()
		{
			CB( Sender, Target, Output );
		}
	}
}
