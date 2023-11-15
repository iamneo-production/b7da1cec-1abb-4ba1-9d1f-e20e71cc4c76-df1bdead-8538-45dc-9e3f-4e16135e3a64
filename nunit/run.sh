#!/bin/bash
if [ -d "/home/coder/project/workspace/dotnetapp/" ]
then
    echo "project folder present"
    # checking for src folder
    if [ -d "/home/coder/project/workspace/dotnetapp/" ]
    then
        cp -r /home/coder/project/workspace/nunit/test/TestProject /home/coder/project/workspace/;
        cp -r /home/coder/project/workspace/nunit/test/dotnetapp.sln /home/coder/project/workspace/dotnetapp/;
        cd /home/coder/project/workspace/dotnetapp || exit;
        dotnet clean;
        dotnet test;
    else
        echo "Backend_Test_Migration_Exists FAILED";
        echo "Backend_ApplicationDbContextContainsDbSetPlayersProperty FAILED";
        echo "Backend_ApplicationDbContextContainsDbSetTeamsProperty FAILED";
        echo "Backend_Player_Properties_Category_ReturnExpectedDataTypes_string FAILED";
        echo "Backend_Player_Properties_Name_ReturnExpectedDataTypes_String FAILED";
        echo "Backend_Player_Properties_Age_ReturnExpectedDataTypes_int FAILED";
        echo "Backend_Player_Properties_BiddingPrice_ReturnExpectedDataTypes_double FAILED";
        echo "Backend_Team_Properties_MaximumBudget_ReturnExpectedDataTypes_double FAILED";
        echo "Backend_GetTeams_Method_AdminController_Exists FAILED";
        echo "Backend_CreatePlayerMethod_AdminController_Exists FAILED";
        echo "Backend_UpdatePlayer_Method_AdminController_Exists FAILED";
        echo "Backend_DeleteTeam_Method_AdminController_Exists FAILED";
        echo "Backend_AssignPlayerToTeam_Method_OrganizerController_Exists FAILED";
        echo "Backend_GetUnsoldPlayers_Method_OrganizerController_Exists FAILED";
        echo "Backend_Register_Method_AuthController_Exists FAILED";
        echo "Backend_Login_Method_AuthController_Exists FAILED";
        echo "Backend_GenerateJwtToken_Method_UserService_Exists FAILED";
        echo "Backend_CreateTeam_ValidTeam_AdminController_CreatesTeam_in_DB FAILED";
        echo "Backend_CreatePlayer_ValidPlayer_AdminController_CreatesPlayer_in_DB FAILED";
        echo "Backend_UpdatePlayer_ValidPlayer_AdminController_UpdatesPlayer_in_DB FAILED";
        echo "Backend_DeletePlayer_ValidPlayer_AdminController_DeletesPlayer_in_DB FAILED";
        echo "Backend_DeleteTeam_ValidTeam_AdminController_DeletesTeam_in_DB FAILED";
        echo "Backend_UpdateTeam_ValidTeam_AdminController_UpdatesTeam_in_DB FAILED";
        echo "Backend_GetTeams_AdminController_ReturnsListOfTeams FAILED";
        echo "Backend_GetPlayers_AdminController_ReturnsListOfPlayers FAILED";
        echo "Backend_Test_GetTeams_EndPoint_Status FAILED";
        echo "Backend_Test_GetPlayers_EndPoint_Status FAILED";
        echo "Backend_Test_GetUnsold_Players_EndPoint_Status FAILED";
        echo "Backend_RegisterAsync_Method_UserService_Exists FAILED";
        echo "Backend_LoginAsync_Method_UserService_Exists FAILED";
    fi
else
    echo "Backend_Test_Migration_Exists FAILED";
    echo "Backend_ApplicationDbContextContainsDbSetPlayersProperty FAILED";
    echo "Backend_ApplicationDbContextContainsDbSetTeamsProperty FAILED";
    echo "Backend_Player_Properties_Category_ReturnExpectedDataTypes_string FAILED";
    echo "Backend_Player_Properties_Name_ReturnExpectedDataTypes_String FAILED";
    echo "Backend_Player_Properties_Age_ReturnExpectedDataTypes_int FAILED";
    echo "Backend_Player_Properties_BiddingPrice_ReturnExpectedDataTypes_double FAILED";
    echo "Backend_Team_Properties_MaximumBudget_ReturnExpectedDataTypes_double FAILED";
    echo "Backend_GetTeams_Method_AdminController_Exists FAILED";
    echo "Backend_CreatePlayerMethod_AdminController_Exists FAILED";
    echo "Backend_UpdatePlayer_Method_AdminController_Exists FAILED";
    echo "Backend_DeleteTeam_Method_AdminController_Exists FAILED";
    echo "Backend_AssignPlayerToTeam_Method_OrganizerController_Exists FAILED";
    echo "Backend_GetUnsoldPlayers_Method_OrganizerController_Exists FAILED";
    echo "Backend_Register_Method_AuthController_Exists FAILED";
    echo "Backend_Login_Method_AuthController_Exists FAILED";
    echo "Backend_GenerateJwtToken_Method_UserService_Exists FAILED";
    echo "Backend_CreateTeam_ValidTeam_AdminController_CreatesTeam_in_DB FAILED";
    echo "Backend_CreatePlayer_ValidPlayer_AdminController_CreatesPlayer_in_DB FAILED";
    echo "Backend_UpdatePlayer_ValidPlayer_AdminController_UpdatesPlayer_in_DB FAILED";
    echo "Backend_DeletePlayer_ValidPlayer_AdminController_DeletesPlayer_in_DB FAILED";
    echo "Backend_DeleteTeam_ValidTeam_AdminController_DeletesTeam_in_DB FAILED";
    echo "Backend_UpdateTeam_ValidTeam_AdminController_UpdatesTeam_in_DB FAILED";
    echo "Backend_GetTeams_AdminController_ReturnsListOfTeams FAILED";
    echo "Backend_GetPlayers_AdminController_ReturnsListOfPlayers FAILED";
    echo "Backend_Test_GetTeams_EndPoint_Status FAILED";
    echo "Backend_Test_GetPlayers_EndPoint_Status FAILED";
    echo "Backend_Test_GetUnsold_Players_EndPoint_Status FAILED";
    echo "Backend_RegisterAsync_Method_UserService_Exists FAILED";
    echo "Backend_LoginAsync_Method_UserService_Exists FAILED";
fi
    