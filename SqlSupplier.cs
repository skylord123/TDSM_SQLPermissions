using System;
using Sithouse;
using TDSM.API.Permissions;
using TDSM.API.Data;
using TDSM.API;

namespace Sithous
{
	public sealed class SqlSupplier : TDSM.API.Permissions.IPermissionHandler
    {
        public const String SQLSafePluginName = "SqlPermissions";

        /// <summary>
        /// Initializes a new instance of the <see cref="Sithous.SqlSupplier"/> class.
        /// </summary>
        public SqlSupplier() { }

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

    public class GroupDatabase
    {
        private class TableDefinition
        {
            public const String TableName = "Groups";

            public static class ColumnNames
            {
                public const String Id = "Id";
                public const String Name = "Name";
                public const String Parent = "Parent";
                public const String Chat_Red = "Chat_Red";
                public const String Chat_Green = "Chat_Green";
                public const String Chat_Blue = "Chat_Blue";
                public const String Chat_Prefix = "Chat_Prefix";
                public const String Chat_Suffix = "Chat_Suffix";
            }

            // `id` int(11) NOT NULL AUTO_INCREMENT,
            // `name` varchar(255) NOT NULL,
            // `parent` int(255) DEFAULT NULL,
            // `chat_color` varchar(11) DEFAULT NULL,
            // `chat_prefix` varchar(255) DEFAULT NULL,
            // `chat_suffix` varchar(255) DEFAULT NULL,
            // PRIMARY KEY(`id`),
            // KEY `restrict_group_parent` (`parent`),
            // CONSTRAINT `restrict_group_parent` FOREIGN KEY(`parent`) REFERENCES `Restrict_Group` (`id`) ON DELETE SET NULL
            //) ENGINE=InnoDB AUTO_INCREMENT = 3 DEFAULT CHARSET = latin1;

            public static readonly TableColumn[] Columns = new TableColumn[]
            {
                new TableColumn(ColumnNames.Id, typeof(Int32), true, true),
                new TableColumn(ColumnNames.Name, typeof(String), 255),
                new TableColumn(ColumnNames.Parent, typeof(String), 255),
                new TableColumn(ColumnNames.Chat_Red, typeof(Byte)),
                new TableColumn(ColumnNames.Chat_Green, typeof(Byte)),
                new TableColumn(ColumnNames.Chat_Blue, typeof(Byte)),
                new TableColumn(ColumnNames.Chat_Prefix, typeof(Byte)),
                new TableColumn(ColumnNames.Chat_Suffix, typeof(Byte))
            };

            public static bool Exists()
            {
                using (var bl = Storage.GetBuilder(SqlSupplier.SQLSafePluginName))
                {
                    bl.TableExists(TableName);

                    return Storage.Execute(bl);
                }
            }

            public static bool Create()
            {
                using (var bl = Storage.GetBuilder(SqlSupplier.SQLSafePluginName))
                {
                    bl.TableCreate(TableName, Columns);

                    return Storage.ExecuteNonQuery(bl) > 0;
                }
            }
        }
    }

    public class NodesTable
    {
        private class TableDefinition
        {
            public const String TableName = "Groups";

            public static class ColumnNames
            {
                public const String Id = "Id";
                public const String Name = "Node";
                public const String Deny = "Deny";
            }

            public static readonly TableColumn[] Columns = new TableColumn[]
            {
                new TableColumn(ColumnNames.Id, typeof(Int32), true, true),
                new TableColumn(ColumnNames.Name, typeof(String), 255),
                new TableColumn(ColumnNames.Deny, typeof(Boolean))
            };

            public static bool Exists()
            {
                using (var bl = Storage.GetBuilder(SqlSupplier.SQLSafePluginName))
                {
                    bl.TableExists(TableName);

                    return Storage.Execute(bl);
                }
            }

            public static bool Create()
            {
                using (var bl = Storage.GetBuilder(SqlSupplier.SQLSafePluginName))
                {
                    bl.TableCreate(TableName, Columns);

                    return Storage.ExecuteNonQuery(bl) > 0;
                }
            }
        }
    }
}

