struct StateReturns
{
	public StateBase Next;
	public string Text;
}

abstract class StateBase {
	public abstract StateReturns runState();
}

//// All states ////

class SGoodbye : StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SNever(),
			Text = "goodbye"
		};
	}
}

class SSay: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SGoodbye(),
			Text = "say"
		};
	}
}

class SRun: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SAround(),
			Text = "run"
		};
	}
}

class SAround: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SAnd(),
			Text = "around"
		};
	}
}

class SNever: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SGonna(),
			Text = "Never"
		};
	}
}

class SGonna: StateBase
{
	public override StateReturns runState()
	{
		const string text = "gonna";
		switch (Program.rnd.Next(6))
		{
			case 0:
				return new StateReturns()
				{
					Next = new SSay(),
					Text = text
				};
			case 1:
				return new StateReturns()
				{
					Next = new SRun(),
					Text = text
				};
			case 2:
				return new StateReturns()
				{
					Next = new STell(),
					Text = text
				};
			case 3:
				return new StateReturns()
				{
					Next = new SLet(),
					Text = text
				};
			case 4:
				return new StateReturns()
				{
					Next = new SGive(),
					Text = text
				};
			case 5:
				return new StateReturns()
				{
					Next = new SMake(),
					Text = text
				};
			default:
				throw new Exception("oops");
		}
	}
}

class STell: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SALie(),
			Text = "tell"
		};
	}
}

class SALie: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SAnd(),
			Text = "a lie"
		};
	}
}

class SDown: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SNever(),
			Text = "down"
		};
	}
}

class SCry: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SNever(),
			Text = "cry"
		};
	}
}

class SUp: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SNever(),
			Text = "up"
		};
	}
}

class SYou: StateBase
{
	public override StateReturns runState()
	{
		const string text = "you";
		switch (Program.rnd.Next(4))
		{
			case 0:
				return new StateReturns()
				{
					Next = new SNever(),
					Text = text
				};
			case 1:
				return new StateReturns()
				{
					Next = new SUp(),
					Text = text
				};
			case 2:
				return new StateReturns()
				{
					Next = new SCry(),
					Text = text
				};
			case 3:
				return new StateReturns()
				{
					Next = new SDown(),
					Text = text
				};
			default:
				throw new Exception("oops");
		}
	}
}

class SLet: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SYou(),
			Text = "let"
		};
	}
}

class SGive: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SYou(),
			Text = "give"
		};
	}
}

class SMake: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SYou(),
			Text = "make"
		};
	}
}

class SAnd: StateBase
{
	public override StateReturns runState()
	{
		const string text = "and";
		switch (Program.rnd.Next(2))
		{
			case 0:
				return new StateReturns()
				{
					Next = new SDesert(),
					Text = text
				};
			case 1:
				return new StateReturns()
				{
					Next = new SHurt(),
					Text = text
				};
			default:
				throw new Exception("oops");
		}
	}
}

class SDesert: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SYou(),
			Text = "desert"
		};
	}
}

class SHurt: StateBase
{
	public override StateReturns runState()
	{
		return new StateReturns()
		{
			Next = new SYou(),
			Text = "hurt"
		};
	}
}
