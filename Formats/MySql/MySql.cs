using System;

namespace Sithouse
{
	public class MySql : ISql
	{
		string ISql.GetFormat ()
		{
			return "mysql";
		}

		bool ISql.OpenConnection (string host, int port)
		{
			return false;
		}

		bool ISql.CloseConnection ()
		{
			return false;
		}

		bool ISql.CheckConnection ()
		{
			return false;
		}
	}
}

