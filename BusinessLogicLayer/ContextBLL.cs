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
        public List<UsersBLL> UsersFindByUserName(string UserName)
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
            List<UsersBLL> BusinessObject = new List<UsersBLL>();
            List<UsersDAL> ListofDataLayerObjects = _context.UsersGetAllbyActivityID(skip, take);
            foreach (UserDAL User in ListofDataLayerObjects)
            {

            }
        }

            
        #endregion Users
        #region UserGroups
        #endregion UserGroups
        #region GroupActivities
        #endregion GroupActivities
        #region Groups
        #endregion Groups
        #region UserActivities
        #endregion UserActivities
        #region Activities
        #endregion Activities
        #region Locations
        #endregion Locations
    }
}
