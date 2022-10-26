namespace State{
	struct Returns
	{
		public Base Next;
		public string Text;
	}

	abstract class Base {
		public abstract Returns runState();
	}

	abstract class SimpleBase : Base{
		protected Returns runSimple(Type next, string text)
		{	/*
			Function is more complicated than it needs to be, the final return could be sufficient.
			However, c# warns about possible nulls, coming from CreateInstance.
			This could happen if:
			- runSimple is called with "null" explicitly
			- MultiBase random logic had a bug, or bad parameters
			both of which are unlikely. But just suppressing the error feels wrong.
			*/
			
			object? next_NullableObj = Activator.CreateInstance(next);
			// Cast later, since the cast would warn about possible null.
			Base next_Base = (Base)(next_NullableObj ?? new SNever());
			return new Returns()
			{
				Next = next_Base,
				Text = text
			};
		}
	}

	abstract class MultiBase : SimpleBase {
		protected Returns runMulti(Type[] nextList, string text)
		{
			Type result = nextList[
				Program.rnd.Next(nextList.Count())
			];
			return runSimple(result, text);
		}
	}

	//// All states ////

	class SGoodbye : SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SNever), "goodbye");
		}
	}

	class SSay: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SGoodbye), "say");
		}
	}

	class SRun: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SAround), "run");
		}
	}

	class SAround: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SAnd), "around");
		}
	}

	class SNever: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SGonna), "Never");
		}
	}

	class SGonna: MultiBase
	{
		public override Returns runState()
		{
			return runMulti(
				nextList: new Type[]{
					typeof(SSay),
					typeof(SRun),
					typeof(STell),
					typeof(SLet),
					typeof(SGive),
					typeof(SMake)
				}, 
				text: "gonna"
			);
		}
	}

	class STell: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SALie), "tell");
		}
	}

	class SALie: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SAnd), "a lie");
		}
	}

	class SDown: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SNever), "down");
		}
	}

	class SCry: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SNever), "cry");
		}
	}

	class SUp: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SNever), "up");
		}
	}

	class SYou: MultiBase
	{
		public override Returns runState()
		{
			return runMulti(
				nextList: new Type[]{
					typeof(SNever),
					typeof(SUp),
					typeof(SCry),
					typeof(SDown)
				}, 
				text: "you"
			);
		}
	}

	class SLet: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SYou), "let");
		}
	}

	class SGive: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SYou), "give");
		}
	}

	class SMake: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SYou), "make");
		}
	}

	class SAnd: MultiBase
	{
		public override Returns runState()
		{
			return runMulti(
				nextList: new Type[]{
					typeof(SDesert),
					typeof(SHurt)
				}, 
				text: "and"
			);
		}
	}

	class SDesert: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SYou), "desert");
		}
	}

	class SHurt: SimpleBase
	{
		public override Returns runState()
		{
			return runSimple(typeof(SYou), "hurt");
		}
	}
}
