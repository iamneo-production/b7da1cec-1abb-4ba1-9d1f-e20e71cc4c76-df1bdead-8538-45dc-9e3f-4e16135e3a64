using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using dotnetapp.Controllers;
using dotnetapp.Models;
using dotnetapp.Services;

namespace TestProject
{
    public class Tests
    {
        private ApplicationDbContext _context;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use a unique database name
                .Options;

            _context = new ApplicationDbContext(options);
            var teamData = new Dictionary<string, object>
            {
                { "Name", "Demo1" },
                { "MaximumBudget", 15000 }
            };
            var team = CreateTeamFromDictionary(teamData);
            _context.Teams.Add(team);
            _context.SaveChanges();

            var playerData = new Dictionary<string, object>
            {
                { "Name", "Demo" },
                { "Age", 20 },
                { "Category", "Bowler" },
                { "BiddingPrice", 1000 }
            };
            var player = CreatePlayerFromDictionary(playerData);
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void Backend_Test_Migration_Exists()
        {
            string folderPath = @"/home/coder/project/workspace/dotnetapp/Migrations/"; // Replace with the folder path you want to check
            bool folderExists = Directory.Exists(folderPath);

            Assert.IsTrue(folderExists, "The folder does not exist.");
        }

        [Test]
        public void Backend_ApplicationDbContextContainsDbSetPlayersProperty()
        {
            var propertyInfo = _context.GetType().GetProperty("Players");

            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Player>), propertyInfo.PropertyType);

        }
        [Test]
        public void Backend_ApplicationDbContextContainsDbSetTeamsProperty()
        {
            var propertyInfo = _context.GetType().GetProperty("Teams");

            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Team>), propertyInfo.PropertyType);

        }

        [Test]
        public void Backend_Player_Properties_Category_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Category");
            Assert.IsNotNull(propertyInfo, "The property 'Category' was not found on the Player class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'Category' property is not as expected (string).");
        }

        [Test]
        public void Backend_Player_Properties_Name_ReturnExpectedDataTypes_String()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "The property 'Name' was not found on the Player class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'Name' property is not as expected (string).");
        }

        [Test]
        public void Backend_Player_Properties_Age_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Age");
            Assert.IsNotNull(propertyInfo, "The property 'Age' was not found on the Player class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'Age' property is not as expected (int).");
        }

        [Test]
        public void Backend_Player_Properties_BiddingPrice_ReturnExpectedDataTypes_double()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Player";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("BiddingPrice");
            Assert.IsNotNull(propertyInfo, "The property 'BiddingPrice' was not found on the Player class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(double), propertyType, "The data type of 'BiddingPrice' property is not as expected (double).");
        }

        [Test]
        public void Backend_Team_Properties_MaximumBudget_ReturnExpectedDataTypes_double()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Team";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("MaximumBudget");
            Assert.IsNotNull(propertyInfo, "The property 'MaximumBudget' was not found on the Team class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(double), propertyType, "The data type of 'MaximumBudget' property is not as expected (double).");
        }


        [Test]
        public void Backend_GetTeams_Method_AdminController_Exists()
        {
            var controllerType = typeof(AdminController);
            MethodInfo method = controllerType.GetMethod("GetTeams");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_CreatePlayerMethod_AdminController_Exists()
        {
            var controllerType = typeof(AdminController);
            MethodInfo method = controllerType.GetMethod("CreatePlayer");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_UpdatePlayer_Method_AdminController_Exists()
        {
            var controllerType = typeof(AdminController);
            MethodInfo method = controllerType.GetMethod("UpdatePlayer");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_DeleteTeam_Method_AdminController_Exists()
        {
            var controllerType = typeof(AdminController);
            MethodInfo method = controllerType.GetMethod("DeleteTeam");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_AssignPlayerToTeam_Method_OrganizerController_Exists()
        {
            var controllerType = typeof(OrganizerController);
            MethodInfo method = controllerType.GetMethod("AssignPlayerToTeam");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_GetUnsoldPlayers_Method_OrganizerController_Exists()
        {
            var controllerType = typeof(OrganizerController);
            MethodInfo method = controllerType.GetMethod("GetUnsoldPlayers");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_Register_Method_AuthController_Exists()
        {
            var controllerType = typeof(AuthController);
            MethodInfo method = controllerType.GetMethod("Register");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_Login_Method_AuthController_Exists()
        {
            var controllerType = typeof(AuthController);
            MethodInfo method = controllerType.GetMethod("Login");
            Assert.IsNotNull(method);
        }

        [Test]
        public void Backend_GenerateJwtToken_Method_UserService_Exists()
        {
            Type userServiceType = typeof(UserService);
            MethodInfo methodInfo = userServiceType.GetMethod("GenerateJwtToken", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(methodInfo, "GenerateJwtToken method should exist in UserService.");
        }

        [Test]
        public void Backend_CreateTeam_ValidTeam_AdminController_CreatesTeam_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo method = controllerType.GetMethod("CreateTeam", new[] { typeof(Team) });
            var teamData = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "MaximumBudget", 100 }
            };
            var team = CreateTeamFromDictionary(teamData);
            var result = method.Invoke(controller, new object[] { team });
            Assert.IsNotNull(result);
            Type playerModelType = typeof(Team);
            var idProperty = playerModelType.GetProperty("Id");
            if (idProperty != null)
            {
                var allPlayers = _context.Teams.ToList();
                var team1 = allPlayers.FirstOrDefault(r => (long)r.GetType().GetProperty("Id").GetValue(r) == 2);
                Assert.IsNotNull(team1);
                var MaximumBudgetPropertyInfo = playerModelType.GetProperty("MaximumBudget");
                Assert.AreEqual(100, MaximumBudgetPropertyInfo.GetValue(team1));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Backend_CreatePlayer_ValidPlayer_AdminController_CreatesPlayer_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo method = controllerType.GetMethod("CreatePlayer", new[] { typeof(Player) });
            var playerData = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "Age", 30 },
                { "Category", "Batsman" },
                { "BiddingPrice", 1500 }
            };
            var player = CreatePlayerFromDictionary(playerData);
            var result = method.Invoke(controller, new object[] { player });
            Assert.IsNotNull(result);
            Type playerModelType = typeof(Player);
            var idProperty = playerModelType.GetProperty("Id");
            if (idProperty != null)
            {
                var allPlayers = _context.Players.ToList();
                var player1 = allPlayers.FirstOrDefault(r => (long)r.GetType().GetProperty("Id").GetValue(r) == 2);
                Assert.IsNotNull(player1);

                var biddingPricePropertyInfo = playerModelType.GetProperty("BiddingPrice");
                var categoryPropertyInfo = playerModelType.GetProperty("Category");

                Assert.AreEqual(1500, biddingPricePropertyInfo.GetValue(player1));
                Assert.AreEqual("Batsman", categoryPropertyInfo.GetValue(player1));
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Backend_UpdatePlayer_ValidPlayer_AdminController_UpdatesPlayer_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo updateMethod = controllerType.GetMethod("UpdatePlayer", new[] { typeof(long), typeof(Player) });
            var updatedPlayerData = new Dictionary<string, object>
            {
                { "Name", "John Doe1" },
                { "Age", 30 },
                { "Category", "Batsman" },
                { "BiddingPrice", 1500 }
            };
            var player1 = CreatePlayerFromDictionary(updatedPlayerData);
            var updateResult = updateMethod.Invoke(controller, new object[] { 1, player1 }); // Assuming player with ID 1 exists
            Assert.IsNotNull(updateResult);
        }

        [Test]
        public void Backend_DeletePlayer_ValidPlayer_AdminController_DeletesPlayer_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo deleteMethod = controllerType.GetMethod("DeletePlayer", new[] { typeof(long) });

            Type playerModelType = typeof(Player);
            var idProperty = playerModelType.GetProperty("Id");

            if (idProperty != null)
            {
                // Fetch the player to be deleted from the database using SQL
                var playerId = 1; // Set the ID of the player to be deleted
                var playerToDelete = _context.Players.FromSqlRaw($"SELECT * FROM Players WHERE Id = {playerId}").FirstOrDefault();
                Assert.IsNotNull(playerToDelete, $"Player with ID {playerId} should exist before deletion");

                // Delete the player using the controller method
                var deleteResult = deleteMethod.Invoke(controller, new object[] { playerId });
                Assert.IsNotNull(deleteResult, "Deletion should return a result");

                // Attempt to retrieve the player after deletion
                var player1 = _context.Players.FromSqlRaw($"SELECT * FROM Players WHERE Id = {playerId}").FirstOrDefault();
                Assert.IsNull(player1, $"Player with ID {playerId} should not exist after deletion");
            }
            else
            {
                Assert.Fail();
            }
        }




        [Test]
        public void Backend_DeleteTeam_ValidTeam_AdminController_DeletesTeam_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo deleteMethod = controllerType.GetMethod("DeleteTeam", new[] { typeof(long) });

            Type playerModelType = typeof(Team);
            var idProperty = playerModelType.GetProperty("Id");

            if (idProperty != null)
            {
                // Fetch the team to be deleted from the database using SQL
                var teamId = 1; // Set the ID of the team to be deleted
                var teamToDelete = _context.Teams.FromSqlRaw($"SELECT * FROM Teams WHERE Id = {teamId}").FirstOrDefault();
                Assert.IsNotNull(teamToDelete, $"Team with ID {teamId} should exist before deletion");

                // Delete the team using the controller method
                var deleteResult = deleteMethod.Invoke(controller, new object[] { teamId });
                Assert.IsNotNull(deleteResult, "Deletion should return a result");

                // Attempt to retrieve the team after deletion
                var team1 = _context.Teams.FromSqlRaw($"SELECT * FROM Teams WHERE Id = {teamId}").FirstOrDefault();
                Assert.IsNull(team1, $"Team with ID {teamId} should not exist after deletion");
            }else { Assert.Fail(); }
        }


        [Test]
        public void Backend_UpdateTeam_ValidTeam_AdminController_UpdatesTeam_in_DB()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo updateMethod = controllerType.GetMethod("UpdateTeam", new[] { typeof(long), typeof(Team) });
            var updatedteamData = new Dictionary<string, object>
            {
                { "Name", "Team1" },
                { "MaximumBudget", 30000 }
            };
            var team1 = CreateTeamFromDictionary(updatedteamData);
            var updateResult = updateMethod.Invoke(controller, new object[] { 1, team1 }); // Assuming player with ID 1 exists
            Assert.IsNotNull(updateResult);
        }

        [Test]
        public async Task Backend_GetTeams_AdminController_ReturnsListOfTeams()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo getTeamsMethod = controllerType.GetMethod("GetTeams");
            var actionResult = await (Task<IActionResult>)getTeamsMethod.Invoke(controller, null);
            var objectResult = actionResult as OkObjectResult;
            var teams = objectResult?.Value as IEnumerable<Team>;
            Assert.IsNotNull(teams, "Returned teams list should not be null");
            Assert.IsTrue(teams.Any(), "At least one team should be returned");
        }

        [Test]
        public async Task Backend_GetPlayers_AdminController_ReturnsListOfPlayers()
        {
            var controllerType = typeof(AdminController);
            var controller = Activator.CreateInstance(controllerType, _context);
            MethodInfo getPlayersMethod = controllerType.GetMethod("GetPlayers");
            var actionResult = await (Task<IActionResult>)getPlayersMethod.Invoke(controller, null);
            var objectResult = actionResult as OkObjectResult;
            var players = objectResult?.Value as IEnumerable<Player>;
            Assert.IsNotNull(players, "Returned Players list should not be null");
            Assert.IsTrue(players.Any(), "At least one Player should be returned");
        }

        [Test]
        public async Task Backend_Test_GetTeams_EndPoint_Status()
        {
            // Send an HTTP GET request to the API endpoint.
            HttpResponseMessage response = await _httpClient.GetAsync("api/admin/teams");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }

        [Test]
        public async Task Backend_Test_GetPlayers_EndPoint_Status()
        {
            // Send an HTTP GET request to the API endpoint.
            HttpResponseMessage response = await _httpClient.GetAsync("api/admin/players");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }

        [Test]
        public async Task Backend_Test_GetUnsold_Players_EndPoint_Status()
        {
            // Send an HTTP GET request to the API endpoint.
            HttpResponseMessage response = await _httpClient.GetAsync("api/organizer/unsold-players");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }

        [Test]
        public void Backend_RegisterAsync_Method_UserService_Exists()
        {
            Type userServiceType = typeof(UserService);
            MethodInfo methodInfo = userServiceType.GetMethod("RegisterAsync", new[] { typeof(User) });
            Assert.IsNotNull(methodInfo, "RegisterAsync method should exist in UserService.");
        }

        [Test]
        public void Backend_LoginAsync_Method_UserService_Exists()
        {
            Type userServiceType = typeof(UserService);
            MethodInfo methodInfo = userServiceType.GetMethod("LoginAsync", new[] { typeof(string), typeof(string) });
            Assert.IsNotNull(methodInfo, "LoginAsync method should exist in UserService.");
        }



        public Player CreatePlayerFromDictionary(Dictionary<string, object> data)
        {
            var player = new Player();
            foreach (var kvp in data)
            {
                var propertyInfo = typeof(Player).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(player, kvp.Value);
                }
            }
            return player;
        }
        public Team CreateTeamFromDictionary(Dictionary<string, object> data)
        {
            var team = new Team();
            foreach (var kvp in data)
            {
                var propertyInfo = typeof(Team).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(team, kvp.Value);
                }
            }
            return team;
        }

        public User CreateUserFromDictionary(Dictionary<string, object> data)
        {
            var user = new User();
            foreach (var kvp in data)
            {
                var propertyInfo = typeof(User).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(user, kvp.Value);
                }
            }
            return user;
        }

    }
}