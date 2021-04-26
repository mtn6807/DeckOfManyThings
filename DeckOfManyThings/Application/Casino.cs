using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using DeckOfManyThings.Models;

namespace DeckOfManyThings.Application
{
    public class Casino
    {
        private IDictionary<string, Table> userTables;
        private IDictionary<string, Table> tables;
        int maxid = 0;
        public Casino()
        {
            userTables = new Dictionary<string, Table>();
            tables = new Dictionary<string, Table>();
        }

        public Table getTable(string user)
        {
            return userTables[user];
        }
        public void addTable(string user)
        {
            Table newTable = new Table(maxid.ToString());
            newTable.addPlayer(new Player(user));
            tables.Add(maxid.ToString(),newTable);
            userTables.Add(user, newTable);
            maxid++;
        }

        public Boolean userExists(string user)
        {
            return userTables.ContainsKey(user);
        }

        public void joinTable(string id,string user)
        {
            Player player = new Player(user);
            tables[id].addPlayer(player);
            userTables.Add(user, tables[id]);
        }

        public ArrayList getTables()
        {
            ArrayList tableIDs = new ArrayList();
            foreach(string id in tables.Keys) { tableIDs.Add(id); }
            return tableIDs;
        }

        public void removeUser(string user)
        {
            Table table = userTables[user];
            userTables.Remove(user);
            table.removePlayer(user);
            if (table.isEmpty())
            {
                tables.Remove(table.getID());
            }
        }
    }
}
