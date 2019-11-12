using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    {
        #region Context Stuff
        ContextDAL _context = new ContextDAL();
        public ContextBLL()
        {
            _context.ConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion Context Stuff
        #region Roles

        public List<RoleBLL> RolesGetAll(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDAL> items = _context.RolesGetAll(skip, take);

            foreach (RoleDAL item in items)
            {
                RoleBLL correctedItem = new RoleBLL(item);
                ProposedReturnValue.Add(correctedItem);
            }

            return ProposedReturnValue;

        }
        public RoleBLL RoleFindByID(int RoleID)
        {
            RoleBLL proposedReturnValue = null;
            RoleDAL item = _context.RoleFindbyID(RoleID);
            if (item != null)
            {
                proposedReturnValue = new RoleBLL(item);
            }
            return proposedReturnValue;
        }
        public int RoleCreate(string RoleName)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.RoleCreate(RoleName);
            return proposedReturnValue;
        }
        public int RoleCreate(RoleBLL role)
        {
            int proposedReturnValue = _context.RoleCreate(role.RoleName);
            return proposedReturnValue;
        }

        public void RoleDelete(int RoleID)
        {
            _context.RoleDelete(RoleID);
        }
        public void RoleDelete(RoleBLL Role)
        {
            _context.RoleDelete(Role.RoleID);
        }
        public void RoleUpdateJust(int RoleID, string RoleName)
        {
            _context.RoleUpdateJust(RoleID, RoleName);
        }
        public void RoleUpdateJust(RoleBLL Role)
        {
            _context.RoleUpdateJust(Role.RoleID, Role.RoleName);
        }
        public int RolesObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.RolesObtainCount();
            return proposedReturnValue;
        }

        #endregion Roles
        #region Users
        public int UserCreate(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.UserCreate(LastName, FirstName, Email, Phone, UserName, Hash, Salt);
            return proposedReturnValue;
        }
        public int UserCreate(UsersBLL User)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.UserCreate(User.LastName, User.FirstName, User.Email, User.Phone, User.UserName, User.Hash, User.Salt);
            return proposedReturnValue;
        }
        public UsersBLL UserFindByID(int UserID)
        {
            UsersBLL proposedReturnValue = null;
            UsersDAL DataLayerObject = _context.UserFindByID(UserID);
            if (null != DataLayerObject)
            {
                proposedReturnValue = new UsersBLL(DataLayerObject);
            }
            return proposedReturnValue;
        }
        public UsersBLL UsersFindByEmail(string Email)
        {
            UsersBLL proposedReturnValue = null;
            UsersDAL DataLayerObject = _context.UsersFindbyEmail(Email);
            if (null != DataLayerObject)
            {
                proposedReturnValue = new UsersBLL(DataLayerObject);
            }
            return proposedReturnValue;
        }
        public UsersBLL UsersFindByUserName(string UserName)
        {
            UsersBLL proposedReturnValue = null;
            UsersDAL DataLayerObject = _context.UsersFindbyUserName(UserName);
            if (null != DataLayerObject)
            {
                proposedReturnValue = new UsersBLL(DataLayerObject);
            }
            return proposedReturnValue;
        }
        public List<UsersBLL> UsersGetAll(int skip, int take)
        {
            List<UsersBLL> proposedReturnValue = new List<UsersBLL>();
            List<UsersDAL> ListofDataLayerObjects = _context.UsersGetAll(skip, take);
            foreach (UsersDAL User in ListofDataLayerObjects)
            {
                UsersBLL BusinessObject = new UsersBLL(User);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public List<UsersBLL> UsersGetAllbyActivityID(int skip, int take, int ActivityID)
        {
            List<UsersBLL> proposedReturnValue = new List<UsersBLL>();
            List<UsersDAL> ListofDataLayerObjects = _context.UsersGetAllbyActivityID(skip, take, ActivityID);
            foreach (UsersDAL User in ListofDataLayerObjects)
            {
                UsersBLL BusinessObject = new UsersBLL(User);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public List<UsersBLL> UsersGetAllbyGroupID(int skip, int take, int GroupID)
        {
            List<UsersBLL> proposedReturnValue = new List<UsersBLL>();
            List<UsersDAL> ListofDataLayerObjects =_context.UsersGetAllbyGroupID(skip, take, GroupID);
            foreach (UsersDAL Users in ListofDataLayerObjects)
            {
                UsersBLL BusinessObject = new UsersBLL(Users);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public void UserUpdateJust(int UserID, string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            _context.UsersUpdateJust(UserID, LastName, FirstName, Email, Phone, UserName, Hash, Salt);
        }
        public void UsersDelete(int UserID)
        {
            _context.UsersDelete(UserID);
        }
        public void UsersDelete (UsersBLL User)
        {
            _context.UsersDelete(User.UserID);
        }
        public int UsersObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.UsersObtainCount();
            return proposedReturnValue;
        }

        #endregion Users
        #region UserGroups

        public int UserGroupsCreate(int UserID, int GroupID, int RoleID)
        {
            int proposedReturnValue = -1;
            proposedReturnValue =_context.UserGroupsCreate(UserID, GroupID,RoleID);
            return proposedReturnValue;
        }
        public List<UserGroupsBLL> UserGroupsGetAll(int skip, int take)
        {
            List<UserGroupsBLL> proposedReturnValue = new List<UserGroupsBLL>();
            List<UserGroupsDAL> ListofDataLayerObjects = _context.UserGroupsGetAll(skip, take);
            foreach (UserGroupsDAL User in ListofDataLayerObjects)
            {
                UserGroupsBLL BusinessObject = new UserGroupsBLL(User);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }

        public void UserGroupsDelete(UserGroupsBLL userGroups)
        {
            _context.UserGroupsDelete(userGroups.UserID, userGroups.GroupID);
        }
        public int UserGroupsObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.UserGroupsObtainCount();
            return proposedReturnValue;
        }
        #endregion UserGroups
        #region GroupActivities
        public void GroupActivitiesCreate(int ActivityID, int GroupID, string ActivityOwner)
        {
            _context.GroupActivitiesCreate(ActivityID, GroupID,ActivityOwner);  
        }

        public void GroupsActivitiesDelete(GroupActivitiesBLL GroupActivities)
        {
            _context.GroupActivitiesDelete(GroupActivities.ActivityID,GroupActivities.GroupID);
        }
        public int GroupActivitiesObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.GroupActivitiesObtainCount();
            return proposedReturnValue;
        }
        #endregion GroupActivities
        #region Groups
        public int GroupsCreate(string GroupName )
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.GroupsCreate(GroupName);
            return proposedReturnValue;
        }
        
        public int GroupsCreate(GroupsBLL groups)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.GroupsCreate( groups.GroupName);
            return proposedReturnValue;
        }
        public GroupsBLL GroupsFindByID(int GroupID)
    {
        GroupsBLL proposedReturnValue = null;
        GroupsDAL DataLayerObject = _context.GroupsFindbyID(GroupID);
            if (null != DataLayerObject)
            {
                proposedReturnValue = new GroupsBLL(DataLayerObject);
            }
            return proposedReturnValue;
    }
        public GroupsBLL GroupsFindByGroupName(string GroupName)
        {
            GroupsBLL proposedReturnValue = null;
            GroupsDAL DataLayerObject = _context.GroupsFindByGroupName(GroupName);
            if (null != DataLayerObject)
            {
                proposedReturnValue = new GroupsBLL(DataLayerObject);
            }
            return proposedReturnValue;
        }
        public List<GroupsBLL> GroupsGetAll(int skip, int take)
        {
            List<GroupsBLL> proposedReturnValue = new List<GroupsBLL>();
            List<GroupsDAL> ListofDataLayerObject = _context.GroupsGetAll(skip, take);
            foreach (GroupsDAL Groups in ListofDataLayerObject)
                {
                GroupsBLL BusinessObject = new GroupsBLL(Groups);
                proposedReturnValue.Add(BusinessObject);
                }
            return proposedReturnValue;
         }
        public List<GroupsBLL> GroupsGetAllbyActivityID(int skip, int take, int ActivityID)
        {
            List<GroupsBLL> proposedReturnValue = new List<GroupsBLL>();
            List<GroupsDAL> ListofDataLayerObjects = _context.GroupsGetAllbyActivityID(skip, take, ActivityID);
            foreach (GroupsDAL Groups in ListofDataLayerObjects)
            {
                GroupsBLL BusinessObject = new GroupsBLL(Groups);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public void GroupsUpdateJust(int GroupID, string GroupName)
        {
            _context.GroupsUpdateJust(GroupID, GroupName);
        }
        public void GroupsDelete(int GroupID)
    {
        _context.GroupsDelete(GroupID);
    }
        public void GroupsDelete(GroupsBLL groups)
    {
            _context.GroupsDelete(groups.GroupID);
    }
        public int GroupsObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.GroupsObtainCount();
            return proposedReturnValue;
        }
        #endregion Groups
        #region UserActivities
        public void UserActivitiesCreate(int UserID, int ActivityID)
        {
            _context.UserActivitiesCreate(UserID, ActivityID);
        }

        public void UserActivitiesDelete(UserActivitiesBLL UserActivities)
        {
            _context.UserActivitiesDelete(UserActivities.UserID,UserActivities.ActivityID);
        }
        public int UserActivitiesObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.UserActivitiesObtainCount();
            return proposedReturnValue;
        }
        #endregion UserActivities
        #region Activities
        public int ActivitiesCreate(string ActivityName, DateTime TimeofActivity, int LocationID)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.ActivitiesCreate(ActivityName, TimeofActivity, LocationID);
            return proposedReturnValue;
        }
        public int ActivitiesCreate(ActivitiesBLL activities)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.ActivitiesCreate(activities.ActivityName,activities.TimeofActivity, activities.LocationID);
            return proposedReturnValue;
        }
        public ActivitiesBLL ActivitiesFindbyID(int ActivityID)
        {
            ActivitiesBLL ProposedReturnValue = null;
            ActivitiesDAL DataLayerObject = _context.ActivitiesFindByID(ActivityID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new ActivitiesBLL(DataLayerObject);
            }
            return ProposedReturnValue;

        }
        public ActivitiesBLL ActivitiesFindbyLocationID(int LocationID)
        {
            ActivitiesBLL ProposedReturnValue = null;
            ActivitiesDAL DataLayerObject = _context.ActivitiesFindbyLocationID(LocationID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new ActivitiesBLL(DataLayerObject);
            }
            return ProposedReturnValue;

        }
        public List<ActivitiesBLL> ActivitiesGetAll(int skip, int take)
        {
            List<ActivitiesBLL> proposedReturnValue = new List<ActivitiesBLL>();
            List<ActivitiesDAL> ListofDataLayerObjects = _context.ActivitiesGetAll(skip, take);
            foreach (ActivitiesDAL activities in ListofDataLayerObjects)
            {
                ActivitiesBLL BusinessObject = new ActivitiesBLL(activities);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public List<ActivitiesBLL> ActivitiesGetAllbyGroupID(int skip, int take, int GroupID)
        {
            List<ActivitiesBLL> proposedReturnValue = new List<ActivitiesBLL>();
            List<ActivitiesDAL> ListofDataLayerObjects = _context.ActivitiesGetAllbyGroupID(skip, take, GroupID);
            foreach (ActivitiesDAL activities in ListofDataLayerObjects)
            {
                ActivitiesBLL BusinessObject = new ActivitiesBLL(activities);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public List<ActivitiesBLL> ActivitiesGetAllbyUserID(int skip, int take, int UserID)
        {
            List<ActivitiesBLL> proposedReturnValue = new List<ActivitiesBLL>();
            List<ActivitiesDAL> ListofDataLayerObjects = _context.ActivitiesGetAllbyUserID(skip, take, UserID);
            foreach (ActivitiesDAL activities in ListofDataLayerObjects)
            {
                ActivitiesBLL BusinessObject = new ActivitiesBLL(activities);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public void ActivitiesUpdateJust(int ActivityID, string ActivityName, DateTime TimeofActivity, int LocationID)
        {
            _context.ActivitiesUpdateJust(ActivityID, ActivityName,  TimeofActivity, LocationID);
        }
        public void ActivitiesUpdateJust(ActivitiesBLL activities)
        {
            _context.ActivitiesUpdateJust(activities.ActivityID, activities.ActivityName, activities.TimeofActivity, activities.LocationID);
        }
        public void ActivitiesDelete(int ActivityID)
        {
            _context.ActivitiesDelete(ActivityID);
        }
        public void ActivitiesDelete(ActivitiesBLL activities)
        {
            _context.ActivitiesDelete(activities.ActivityID);
        }
        public int ActivitiesObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ActivitiesObtainCount();
            return proposedReturnValue;
        }

        #endregion Activities
        #region Locations
        public int LocationCreate(string LocationName, string Address1, string Address2, string City, string State, string Zip)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.LocationsCreate(LocationName, Address1, Address2, City, State, Zip);
            return proposedReturnValue;
        }
        public int LocationCreate(LocationsBLL locations)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.LocationsCreate(locations.LocationName, locations.Address1, locations.Address2, locations.City,locations.State, locations.Zip);
            return proposedReturnValue;
        }
        public LocationsBLL LocationFindbyID(int LocationID)
        {
            LocationsBLL ProposedReturnValue = null;
            LocationsDAL DataLayerObject = _context.LocationFindByID(LocationID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new LocationsBLL(DataLayerObject);
            }
            return ProposedReturnValue;

        }
        public List<LocationsBLL> LocationGetAll(int skip, int take)
        {
            List<LocationsBLL> proposedReturnValue = new List<LocationsBLL>();
            List<LocationsDAL> ListofDataLayerObjects = _context.LocationGetAll(skip, take);
            foreach (LocationsDAL activities in ListofDataLayerObjects)
            {
                LocationsBLL BusinessObject = new LocationsBLL(activities);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public void LocationUpdateJust(int LocationID, string LocationName, string Address1, string Address2, string City, string Zip)
        {
            _context.LocationUpdateJust(LocationID, LocationName, Address1, Address2, Address2, City, Zip);
        }
        public void LocationUpdateJust(LocationsBLL locations)
        {
            _context.LocationUpdateJust(locations.LocationID, locations.LocationName, locations.Address1, locations.Address2, locations.City, locations.State, locations.Zip);
        }
        public void LocationDelete(int LocationID)
        {
            _context.LocationDelete(LocationID);
        }
        public void LocationDelete(LocationsBLL locations)
        {
            _context.ActivitiesDelete(locations.LocationID);
        }
        public int LocatoinsObtainCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.LocationsObtainCount();
            return proposedReturnValue;
        }

        #endregion Locations

        #region GroupRole
        public List<GroupsBLL> GroupsFindByUserID(int skip, int take, int UserID)
        {
            List<GroupsBLL> proposedReturnValue = new List<GroupsBLL>();
            List<GroupsDAL> DataLayerObjects = _context.GroupsFindbyUserID(skip, take, UserID);
            foreach (var item in DataLayerObjects )
            {
                proposedReturnValue.Add(new GroupsBLL(item));
            }
            return proposedReturnValue;
        }
        #endregion
    }
}
