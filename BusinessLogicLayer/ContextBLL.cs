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
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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

        #endregion Roles
        #region Users
        public int UserCreate(string LastName, string FirstName, string Email, string Phone, string UserName, string Hash, string Salt)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.UsersCreate(LastName, FirstName, Email, Phone, UserName, Hash, Salt);
            return proposedReturnValue;
        }
        public int UserCreate(UsersBLL User)
        {
            int proposeReturnValue = -1;
            proposeReturnValue = _context.UsersCreate(User.LastName, User.FirstName, User.Email, User.Phone, User.UserName, User.Hash, User.Salt);
            return proposeReturnValue;
        }
        public UsersBLL UsersFindByEmail(string Email)
        {
            UsersBLL proposedReturnValue = null;
            UsersDAL DataLayerObject = _context.UsersFindByEmail(Email);
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
        public List<UsersBLL> UsersGetAllbyGroupId(int skip, int take, int GroupID)
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
        public void UsersDelete (UsersBLL User)
        {
            _context.UsersDelete(User.UserID);
        }    
        #endregion Users
        #region UserGroups

        public void UserGroupsCreate(int UserID, int GroupID, int RoleID)
        {
            _context.UserGroupsCreate(UserID,GroupID,RoleID);
        }
        public void UserGroupsCreate(UserGroupsBLL userGroups)
        {
        _context.UserGroupsCreate(userGroups.UserID,userGroups.GroupID, userGroups.RoleID);
        }
        public void UserGroupsDelete(UserGroupsBLL userGroups)
        {
            _context.UserGroupsDelete(userGroups.UserID, userGroups.GroupID);
        }
        #endregion UserGroups
        #region GroupActivities
        public void GroupActivitiesCreate(int ActivityID, int GroupID, string ActivityOwner)
        {
            _context.GroupActivitiesCreate(ActivityID, GroupID,ActivityOwner);  
        }

        public void GroupActivitiesDelete(GroupActivitiesBLL GroupActivities)
        {
            _context.GroupActivitiesDelete(GroupActivities.ActivityID,GroupActivities.GroupID);
        }
        #endregion GroupActivities
        #region Groups
        public int GroupsCreate(int GroupID, string GroupName )
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.GroupsCreate(GroupName);
            return proposedReturnValue;
        }
        
        public int GroupsCreate(GroupsBLL groups)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.GroupsCreate(groups.GroupName);
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
        #endregion UserActivities
        #region Activities
        public int ActivitiesCreate(string ActivityName, string Approveby, DateTime TimeofActivity, int LocationID, DateTime ApproveTime)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.ActivitiesCreate(ActivityName, Approveby, TimeofActivity, LocationID, ApproveTime);
            return proposedReturnValue;
        }
        public int ActivitiesCreate(ActivitiesBLL activities)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.ActivitiesCreate(activities.ActivityName,activities.Approveby,activities.TimeofActivity, activities.LocationID, activities.ApproveTime);
            return proposedReturnValue;
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
                ActivitiesDAL BusinessObject = new ActivitiesDAL(activities);
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
                ActivitiesDAL BusinessObject = new ActivitiesDAL(activities);
                proposedReturnValue.Add(BusinessObject);
            }
            return proposedReturnValue;
        }
        public void ActivitiesUpdateJust(int ActivityID, string ActivityName, string Approveby, DateTime TimeofActivity, int LocationID, DateTime ApproveTime)
        {
            _context.ActivitiesUpdateJust(ActivityID, ActivityName, Approveby, TimeofActivity, LocationID, ApproveTime);
        }
        public void ActivitiesUpdateJust(ActivitiesBLL activities)
        {
            _context.ActivitiesUpdateJust(activities.ActivityID, activities.ActivityName, activities.Approveby, activities.TimeofActivity, activities.LocationID, activities.ApproveTime);
        }
        public void ActivitiesDelete(int ActivityID)
        {
            _context.ActivitiesDelete(ActivityID);
        }
        public void ActivitiesDelete(ActivitiesBLL activities)
        {
            _context.ActivitiesDelete(activities.ActivityID);
        }

        #endregion Activities
        #region Locations
        #endregion Locations
    }
}
