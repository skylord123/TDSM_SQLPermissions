using System;
using tdsm.api.Permissions;
using tdsm.api;
using Sithouse;

namespace Sithous
{
	public sealed class SqlSupplier : tdsm.api.Permissions.IPermissionHandler
	{
		private string _host;
		private int _port;

		private ISql _database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Sithous.SqlSupplier"/> class.
		/// </summary>
		/// <param name="port">Port.</param>
		public SqlSupplier (string host, int port)
		//typically this is a connection string, but for people who have no idea this will make it simple
		{
			this._host = host;
			this._port = port;
		}

		/// <summary>
		/// Prepares the instance ready for use.
		/// </summary>
		public bool Load ()
		{
			//Find the database type
			var fmt = "mysql".ToLower (); //TODO: properties file
			_database = GetFormat (fmt);
			if (null == _database)
			{
				Tools.WriteLine ("Cannot find database format: " + fmt);
				return false;
			}

			//Get a connection
			if (!_database.OpenConnection (_host, _port))
			{
				Tools.WriteLine ("Failed to open a connection to the permission database");
				return false;
			}

			return true;
		}

		/// <summary>
		/// Reload this instance.
		/// </summary>
		public bool Reload ()
		{
			if (null != _database) _database.CloseConnection ();
			return Load ();
		}

		#region "Sql formats"

		private ISql GetFormat (string format)
		{
			//Cycle types in assembly and initialise a match.
			return null;
		}

		#endregion

		#region "TDSM calls"

		public Permission IsPermitted (string node, BasePlayer player)
		{
			//Call sql parameterised

			return Permission.Denied;
		}

		public Permission IsPermittedForGroup (string node, Func<System.Collections.Generic.Dictionary<String, String>, Boolean> whereHas = null)
		{
			//Call sql parameterised
			
			return Permission.Denied;
		}

		#endregion
	}
}

