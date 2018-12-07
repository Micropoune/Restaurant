using System;

namespace Restaurant
{
	internal class RConceptDataContext
	{
		internal object compte;
		internal object comptes;
		private object connectionString;

		public RConceptDataContext(object connectionString)
		{
			this.connectionString = connectionString;
		}

		internal void SubmitChanges()
		{
			throw new NotImplementedException();
		}

	}
}