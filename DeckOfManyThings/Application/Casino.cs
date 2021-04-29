using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using DeckOfManyThings.Models;

namespace DeckOfManyThings.Application
{
    /*
     * Class which is used to track application level functionalities and info.
     */
    public class Casino
    {
        // dictionary which hold usernames and what tables they're at.
        private IDictionary<string, Table> userTables;

        // dictionary which holds tables and their id.
        private IDictionary<string, Table> tables;

        // the current maxid to be used for table ids.
        int maxid = 0;

        /*
         * Constructor for the casino class which initializes the two dictionaries.
         */
        public Casino()
        {
            // initialize the dictionaries.
            userTables = new Dictionary<string, Table>();
            tables = new Dictionary<string, Table>();
        }

        /*
         * Returns the table of a given user.
         * 
         * @param user - the username to find the table of.
         * @return the table the user is at.
         */
        public Table getTable(string user)
        {
            // returns the user's table.
            return userTables[user];
        }

        /*
         * Creates a new table and adds the provided user to the table.
         * 
         * @param user - the user to be added to the new table.
         */
        public void addTable(string user)
        {
            // Creates a new table
            Table newTable = new Table(maxid.ToString());

            // Add the player to that new table.
            newTable.addPlayer(new Player(user));

            // add the table to the correct dictionaries.
            tables.Add(maxid.ToString(),newTable);
            userTables.Add(user, newTable);

            // increment the table id counter.
            maxid++;
        }

        /*
         * Checks if a user is at a table.
         * 
         * @param user - the user to check is at a table.
         * @return a boolean representing if they are in a table.
         */
        public Boolean userExists(string user)
        {
            // return the table a user is in.
            return userTables.ContainsKey(user);
        }

        /*
         * adds a user to a table 
         * 
         * @param id - the id of the table to be added to.
         * @param user - the user to be added to the table.
         */
        public void joinTable(string id,string user)
        {
            // Creates a new player object
            Player player = new Player(user);

            // Add the player to the table with {id}
            tables[id].addPlayer(player);

            //update dictionary to show user is in table.
            userTables.Add(user, tables[id]);
        }

        /*
         * Returns a list of all table ids
         * 
         * @return a list of strings representing the tables.
         */
        public ArrayList getTables()
        {
            // Create new array list for table ids
            ArrayList tableIDs = new ArrayList();

            // add every id to the list
            foreach(string id in tables.Keys) { tableIDs.Add(id); }
            
            // return the arraylist.
            return tableIDs;
        }

        /*
         * removes a user from thee table.
         */
        public void removeUser(string user)
        {
            // gets the table the user is at
            Table table = userTables[user];

            // removes user from the table
            userTables.Remove(user);

            // remove player from the dictionaries
            table.removePlayer(user);
            if (table.isEmpty())
            {
                tables.Remove(table.getID());
            }
        }
    }
}
