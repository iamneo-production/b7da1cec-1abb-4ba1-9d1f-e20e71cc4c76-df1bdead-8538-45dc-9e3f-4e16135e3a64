#!/bin/bash
export CHROME_BIN=/usr/bin/chromium
if [ -d "/home/coder/project/workspace/angularapp" ]
then
    echo "project folder present"
    cp /home/coder/project/workspace/karma/karma.conf.js /home/coder/project/workspace/angularapp/karma.conf.js;

    # checking for login component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/login" ]
    then
        cp /home/coder/project/workspace/karma/login.component.spec.ts /home/coder/project/workspace/angularapp/src/app/login/login.component.spec.ts;
    else
        echo "Frontend_CreateComponent_LoginComponent FAILED";
        echo "Frontend_call_login_method_on_admin_login_LoginComponent FAILED";
        echo "Frontend_should_call_login_method_on_organizer_login_LoginComponent FAILED";
        echo "Frontend_should_navigate_to_organizer_on_organizer_login_LoginComponent FAILED";
        echo "Frontend_should_have_empty_username_and_password_initially_LoginComponent FAILED";
        echo "Frontend_should_call_login_method_on_form_submission_LoginComponent FAILED";
        echo "Frontend_should_show_username_required_error_message_LoginComponent FAILED";
        echo "Frontend_should_show_password_required_error_message_LoginComponent FAILED";
    fi

    # checking for admin component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/admin" ]
    then
        cp /home/coder/project/workspace/karma/admin.component.spec.ts /home/coder/project/workspace/angularapp/src/app/admin/admin.component.spec.ts;
    else
        echo "Frontend_should_create_Admin_Component FAILED";
    fi

    # checking for organizer component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/organizer" ]
    then
        cp /home/coder/project/workspace/karma/organizer.component.spec.ts /home/coder/project/workspace/angularapp/src/app/organizer/organizer.component.spec.ts;
    else
        echo "Frontend_should_create_the_OrganizerComponent FAILED";
    fi

    # checking for admin-services component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/admin.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/admin.service.spec.ts;
    else
        echo "Frontend_AdminService_should_be_created FAILED";
        echo "Frontend_AdminService_should_retrieve_teams_from_the_backend FAILED";
        echo "Frontend_AdminService_should_retrieve_players_from_the_backend FAILED";
    fi

    # checking for auth-services component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/auth.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/auth.service.spec.ts;
    else
        echo "Frontend_should_create_authServices FAILED";
    fi

    # checking for organizer-services component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/organizer.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/organizer.service.spec.ts;
    else
        echo "Frontend_OrganizerService_should_be_created FAILED";
        echo "Frontend_OrganizerService_should_retrieve_UnsoldPlayers_from_the_backend FAILED";
    fi

    # checking for registrations component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/registration" ]
    then
        cp /home/coder/project/workspace/karma/registration.component.spec.ts /home/coder/project/workspace/angularapp/src/app/registration/registration.component.spec.ts;
    else
        echo "Frontend_should_show_username_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_password_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_password_complexity_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_confirm_password_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_passwords_mismatch_error_message_on_register_page_RegistrationComponent FAILED";
    fi

    # checking for player component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/player" ]
    then
        cp /home/coder/project/workspace/karma/player.component.spec.ts /home/coder/project/workspace/angularapp/src/app/player/player.component.spec.ts;
    else
        echo "Frontend_create_Player_component FAILED";
        echo "Frontend_should_have_edit_buttons_for_each_player_Player_component FAILED";
        echo "Frontend_should_have_delete_buttons_for_each_player_Player_component FAILED";
        echo "Frontend_check_the_bidding_amount_Player_component FAILED";
        echo "Frontend_check_bidding_amount_in_status_div_TwoWayBinding_Player_component FAILED";
        echo "Frontend_should_display_Player_information_by_ngfor_Player_component FAILED";
    fi 

    # checking for PlayerModel 
    if [ -d "/home/coder/project/workspace/angularapp/src/models" ]
    then
        cp /home/coder/project/workspace/karma/player.model.spec.ts /home/coder/project/workspace/angularapp/src/models/player.model.spec.ts;
    else
        echo "Frontend_should_create_Player_instance FAILED";
    fi 

    
    # checking for Team Component 
    if [ -d "/home/coder/project/workspace/angularapp/src/app/team" ]
    then
        cp /home/coder/project/workspace/karma/team.component.spec.ts /home/coder/project/workspace/angularapp/src/app/team/team.component.spec.ts;
    else
        echo "Frontend_create_Team_Component FAILED";
        echo "Frontend_should_have_edit_buttons_for_each_team_TeamComponent FAILED";
        echo "Frontend_should_have_delete_buttons_for_each_team_TeamComponent FAILED";
        echo "Frontend_check_the_Maximumbudget_amount_to_create_teams_TeamComponent FAILED";
        echo "Frontend_check_MaxBudget_amount_in_status_div_to_create_teams_TeamComponent FAILED";
        echo "Frontend_should_display_team_information_by_ngfor_TeamComponent FAILED";
    fi 

    # checking for TeamModel 
    if [ -d "/home/coder/project/workspace/angularapp/src/models" ]
    then
        cp /home/coder/project/workspace/karma/team.model.spec.ts /home/coder/project/workspace/angularapp/src/models/team.model.spec.ts;
    else
        echo "Frontend_should_create_Team_instance FAILED";
    fi 

    # checking for UserModel 
    if [ -d "/home/coder/project/workspace/angularapp/src/models" ]
    then
        cp /home/coder/project/workspace/karma/user.model.spec.ts /home/coder/project/workspace/angularapp/src/models/user.model.spec.ts;
    else
        echo "Frontend_should_create_User_instance FAILED";
    fi    

    if [ -d "/home/coder/project/workspace/angularapp/node_modules" ]; 
    then
        cd /home/coder/project/workspace/angularapp/
        npm test;
    else
        cd /home/coder/project/workspace/angularapp/
        yes | npm install
        npm test
    fi 

else   
    echo "Frontend_CreateComponent_LoginComponent FAILED";
    echo "Frontend_call_login_method_on_admin_login_LoginComponent FAILED";
    echo "Frontend_should_call_login_method_on_organizer_login_LoginComponent FAILED";
    echo "Frontend_should_navigate_to_organizer_on_organizer_login_LoginComponent FAILED";
    echo "Frontend_should_have_empty_username_and_password_initially_LoginComponent FAILED";
    echo "Frontend_should_call_login_method_on_form_submission_LoginComponent FAILED";
    echo "Frontend_should_show_username_required_error_message_LoginComponent FAILED";
    echo "Frontend_should_show_password_required_error_message_LoginComponent FAILED";
    echo "Frontend_should_create_Admin_Component FAILED";
    echo "Frontend_should_create_the_OrganizerComponent FAILED";
    echo "Frontend_AdminService_should_be_created FAILED";
    echo "Frontend_AdminService_should_retrieve_teams_from_the_backend FAILED";
    echo "Frontend_AdminService_should_retrieve_players_from_the_backend FAILED";
    echo "Frontend_should_create_authServices FAILED";
    echo "Frontend_OrganizerService_should_be_created FAILED";
    echo "Frontend_OrganizerService_should_retrieve_UnsoldPlayers_from_the_backend FAILED";
    echo "Frontend_should_show_username_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_password_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_password_complexity_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_confirm_password_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_passwords_mismatch_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_create_Player_component FAILED";
    echo "Frontend_should_have_edit_buttons_for_each_player_Player_component FAILED";
    echo "Frontend_should_have_delete_buttons_for_each_player_Player_component FAILED";
    echo "Frontend_check_the_bidding_amount_Player_component FAILED";
    echo "Frontend_check_bidding_amount_in_status_div_TwoWayBinding_Player_component FAILED";
    echo "Frontend_should_display_Player_information_by_ngfor_Player_component FAILED";
    echo "Frontend_should_create_Player_instance FAILED";
    echo "Frontend_create_Team_Component FAILED";
    echo "Frontend_should_have_edit_buttons_for_each_team_TeamComponent FAILED";
    echo "Frontend_should_have_delete_buttons_for_each_team_TeamComponent FAILED";
    echo "Frontend_check_the_Maximumbudget_amount_to_create_teams_TeamComponent FAILED";
    echo "Frontend_check_MaxBudget_amount_in_status_div_to_create_teams_TeamComponent FAILED";
    echo "Frontend_should_display_team_information_by_ngfor_TeamComponent FAILED";
    echo "Frontend_should_create_Team_instance FAILED";
    echo "Frontend_should_create_User_instance FAILED";
fi
