namespace BlazorApp.Models
{
    public static class ServersRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server { ServerId = 1, Name = "Server1", City = "Los Angeles" },
            new Server { ServerId = 2, Name = "Server2", City = "Los Angeles" },
            new Server { ServerId = 3, Name = "Server3", City = "New York City" },
            new Server { ServerId = 4, Name = "Server4", City = "New York City" },
            new Server { ServerId = 5, Name = "Server5", City = "New York City" },
            new Server { ServerId = 6, Name = "Server6", City = "Charlotte" },
            new Server { ServerId = 7, Name = "Server7", City = "Charlotte" },


        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerId);
            server.ServerId = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == id);
            if (server != null)
            {
                return new Server
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }
            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}