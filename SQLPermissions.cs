using tdsm.api;
using tdsm.api.Command;
using tdsm.api.Plugin;

namespace Sithous
{
	public class SQLPermissions : BasePlugin
	{
		private SqlSupplier _instance;

		public SQLPermissions ()
		{
			this.TDSMBuild = 2;
			this.Version = "1";
			this.Author = "Skylord123 & DeathCradle";
			this.Name = "SQL permissions";
			this.Description = "Allows TDSM to run via permissions in a SQL database";
		}

		protected override void Initialized (object state)
		{
			//Reload the spplier
			if (_instance == null)
			{
				_instance = new SqlSupplier ("", 1234);
				if (_instance.Load ())
				{
					Tools.WriteLine ("Connected to the SQL permission database");
				}
				else
				{
					Tools.WriteLine ("Cannot load permissions");
					return;
				}
			}
			else
			{
				if (!_instance.Reload ())
				{
					Tools.WriteLine ("Cannot reload permissions");
					return;
				}
			}
		}

		protected override void Enabled ()
		{
			base.Enabled ();

			//Get TDSM to swap the current permission handler to our own
			tdsm.api.Permissions.PermissionsManager.SetHandler (_instance);

			Tools.WriteLine ("SQL permissions engaged.");
		}
	}
}

