using TDSM.API.Plugin;

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

		}

		protected override void Enabled ()
		{
			base.Enabled ();
        }

        [Hook]
        void OnStateChange(ref HookContext ctx, ref HookArgs.ServerStateChange args)
        {
            if (args.ServerChangeState == TDSM.API.ServerState.Initialising)
            {
                //Data connectors must have loaded by now
                //Get TDSM to swap the current permission handler to our own
                TDSM.API.Permissions.PermissionsManager.SetHandler(_instance);
            }
        }
    }
}

